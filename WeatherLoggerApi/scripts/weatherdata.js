//@ts-check

const viewModel = {
    Temperature: ko.observable(""),
    Humidity: ko.observable(""),
    TimeStamp: ko.observable(""),
    RelativeDate: ko.observable("")
};

ko.applyBindings(viewModel, document.querySelector("#latest-weather"));

showLoading();

getLatestWeatherEntry();

setInterval(function () {
    getLatestWeatherEntry();
}, 30000);

function showLoading() {
    viewModel.Temperature("Loading...");
    viewModel.Humidity("Loading...");
    viewModel.TimeStamp("Loading...");
    viewModel.RelativeDate("Refreshing");
}

function getLatestWeatherEntry() {
    showLoading();
    fetch("api/weather/1").then(response => {
        if (!response)
            return;
        response.json().then(resp => {
            let latest = resp[0];
            viewModel.Temperature(latest.Temperature);
            viewModel.Humidity(latest.Humidity);
            viewModel.TimeStamp(latest.TimeStamp);
            //@ts-ignore
            viewModel.RelativeDate(moment(latest.TimeStamp).add(2, 'hours').fromNow())    
            
        });
    });
}