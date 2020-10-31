// Write your JavaScript code.

function getPcStatsAjaxEveryFiveSec() {

    getPcStatsAjax();
    setTimeout(getPcStatsAjaxEveryFiveSec, 5000);
}

function getPcStatsAjax() {

    $.ajax({
        type: 'GET',
        url: '/Home/GetPcStats',
        data: { }
    })
        .done(function (result) {
            $("#PcStatsOutput").html(result);
        })

        .fail(function (xhr, status, error) {
            $("#PcStatsOutput").text("Error, No data was found.");
        });
}
