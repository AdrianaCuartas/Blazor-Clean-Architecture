namespace Leaflet.Blazor;
//los datos que se  necesitan de javascript para enviarlos a C#
public class DragendMarkerEventArgs : EventArgs
{
    public int MarkerId { get; set; }
    public LeafletLatLong Position { get; set; }
}
