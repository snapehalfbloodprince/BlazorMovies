function myFunction(message) {
    console.log("from Utilities.js " + message);
}

function dotNetStaticInvokation() {
    DotNet.invokeMethodAsync("BlazorMovies.Client", "GetCurrentCount")
        .then(result => {
            console.log("count from javascript " + result);
        })
}