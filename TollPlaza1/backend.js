$(document).ready(function() {
    var vehicles = JSON.parse(localStorage.getItem('vehicles')) || [];

    $('#submit').click(function() {
        var serialNumber = parseInt(localStorage.getItem("serialNumber")) || 0;
        serialNumber++;
        localStorage.setItem("serialNumber", serialNumber);
        var vehicleRegNo = $('#vehicleNumber').val();
        var vehicleType = $('#vehicleType').val();
        var vehicleAmt = $('#amount').val();
        vehicles.push({ Sno:serialNumber, regNo: vehicleRegNo, type: vehicleType ,amt:vehicleAmt });
        localStorage.setItem('vehicles', JSON.stringify(vehicles));
       
    });

    $('#searchByNumber').click(function () {
       
    });
    $('#searchByType').click(function () {
       
    });
    
});