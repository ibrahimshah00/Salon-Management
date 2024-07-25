


function renderChart(chartId, data, options) {
    var ctx = document.getElementById(chartId).getContext('2d');
    new Chart(ctx, {
        type: 'bar',
        data: data,
        options: options
    });
}

