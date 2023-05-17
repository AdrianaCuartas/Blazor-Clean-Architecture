import * as L from "./leaflet-src.esm.js"

const maps = new Map();     // new Dictionary<string, object> in c#

export const createMap = (mapId, point, zoomLevel) => {
    let map = L.map(mapId)
        .setView([point.latitude, point.longitude], zoomLevel);

    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: zoomLevel,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright" target="_blank">OpenStreetMap</a>'
    }).addTo(map);
    map.addedMarkers = [];      // Attibuto nuevo personalizado, se esta creando un atributo nuevo

    maps.set(mapId, map);

    /*
    Otra forma de guardar el objecto map:
    var element = document.getElementById(mapId);
    element.Map = map;
    */

    console.info(`map ${mapId} created.`);
}

export const deleteMap = (mapId) => {
    var map = maps.get(mapId);
    map.remove(); //se elimina al Leaflet 
    maps.delete(mapId);  //se elimina del diccionario
   
    console.info(`map ${mapId} removed.`);
}

//establecer el punto de vision del mapa:
export const setView = (mapId, point) => {
    var  map = maps.get(mapId);
    map.setView([point.latitude, point.longitude]);
}

/*** AddMarker ***/
export const setMarkerHelper = (mapId, markerHelper, dragendHandler) => {
    var map = maps.get(mapId); //se obtiene el mapa relacionado con el mapid
    map.markerHelper = {
        dotNetObjectReference: markerHelper,
        dragendHandler: dragendHandler
    }
}

export const addMarker = (mapId, point, title, popupDescription, iconUrl) => {
    var options = buildMarkerOptions(title, iconUrl);
    return addMarkerWithOptions(mapId, point, popupDescription, options);

}

export const addDraggableMarker = (mapId, point, title, popupDescription, iconUrl) => {
    var options = buildMarkerOptions(title, iconUrl, true);
    let markerid = addMarkerWithOptions(mapId, point, popupDescription, options);

    var map = maps.get(mapId) //recuperar el mapa
    var marker = map.addedMarkers[markerid];

    //con ON agrega un listener para el evento dragend del marcador 
    marker.on('dragend', (e) => {
        let point = marker.getLatLng();
        console.log(point);
        let dragendMarkerEventArgs = {
            markerid: markerid,
            position: {
                latitude: point.lat,
                Longitude:point.lng
            }
        }
        //el nombre del helper que invocara al metodo de C#
        let dotNetObjectReference = map.markerHelper.dotNetObjectReference;
        //obtene el nombre del metodo de C#
        let dragendHandler = map.markerHelper.dragendHandler;

        dotNetObjectReference.invokeMethodAsync(dragendHandler, dragendMarkerEventArgs);
        
      
    });
    return markerid;
}

export const buildMarkerOptions = (title, iconUrl, draggable) => {
    var options = {
        title: title
    };
    if (iconUrl) {
        options.icon = L.icon({ iconUrl: iconUrl, iconSize: [32, 32], iconAnchor: [16, 16] });
    }
    if (draggable) {
        options.draggable = true;
    }
    return options;
}
export const addMarkerWithOptions = (mapId, point, popupDescription, options) => {

    var map = maps.get(mapId);
   
    var marker = L.marker([point.latitude, point.longitude], options) //1:24 video 13
        .bindPopup(popupDescription)
        .addTo(map);
    let markerId = map.addedMarkers.push(marker) - 1;     
    return markerId;  // Devuelve el indice del elemento insertado

}

/***End  AddMarker ***/
export const removeMarkers = (mapId) => {
    var map = maps.get(mapId);
    map.addedMarkers.forEach(marker => marker.removeFrom(map));
    map.addedMarkers = [];
}

export const drawCircle = (mapId, center,  lineColor,fillColor, fillOpacity, radius) => {
    var map = maps.get(mapId);
    var circle= L.circle([center.latitude, center.longitude], {
        color: lineColor,
        fillColor: fillColor,
        fillOpacity: fillOpacity,
        radius: radius
    }).addTo(map);
    //optionalmente, guardar el circulo
}

export const moveMarker = (mapId, markerId, newPoint) => {
    var map = maps.get(mapId);
    var marker = map.addedMarkers[markerId];
    marker.setLatLng([newPoint.latitude, newPoint.longitude]);
}
/*Actualizar el popup: ej: cuando se arrastra la ubicacion */
export const setPopupMarkerContent = (mapId, markerId, content) => {
    var map = maps.get(mapId);
    var marker = map.addedMarkers[markerId];
    //modifica el contenido
    marker.setPopupContent(content);
    //abre el popup
    marker.openPopup();
}

const getMarker = (mapId, markerId) =>
    maps.get(mapId)
        .addedMarkers[markerId];