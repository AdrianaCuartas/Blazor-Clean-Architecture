export const getPositionAsync = () => {
    return new Promise((resolve, reject) =>  {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                returnPosition, returnError);
        }

        function returnPosition(position) {
            resolve({
                latitude: position.coords.latitude,
                longitude: position.coords.longitude
            });
        }

        function returnError(error) {
            let errorMessage;
            switch (error.code) {
                case error.PERMISSION_DENIED:
                    errorMessage = "User denied the request for Geolocation"
                    break;
                case error.POSITTION.UNAVAILABLE:
                    errorMessage = "Location information is unavailable"
                    break;
                case error.TIMEOUT:
                    errorMessage = "The request to get user location timed out"
                    break;
                case error.UNKNOWN_ERROR:
                    errorMessage = "An unknown error occurred"
                    break;
            }
            reject(errorMessage);
        }
    })
}