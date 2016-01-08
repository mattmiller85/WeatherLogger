var viewModel = {
    Temperature: ko.observable(),
    Humidity: ko.observable()
}
$(document).ready(function () {
    ko.applyBindings(viewModel, $("#latest-weather")[0]);
    getLatestWeatherEntry();
    setInterval(function () {
        getLatestWeatherEntry();
    }, 5000);

});

function getLatestWeatherEntry() {
    $.getJSON("api/weather/1", function (response) {
        if (!response || response.length === 0)
            return;
        var latest = response[0];
        viewModel.Temperature(latest.Temperature);
        viewModel.Humidity(latest.Humidity);
    });
}