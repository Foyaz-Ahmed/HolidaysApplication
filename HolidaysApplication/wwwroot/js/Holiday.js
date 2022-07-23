var datas = new Array();
$(document).ready(function () {
    $(function () {
        $("#fromDate").datepicker({ dateFormat: 'mm/dd' });
    });
    $(function () {
        $("#toDate").datepicker({ dateFormat: 'mm/dd' });
    });
    GetAllCountry();
    loadDataTable();
});

function submitHolidays() {

    var countryCode = $('#ddlCountryList option:selected').val();
    var year = $('#ddlYear option:selected').val();

    $.ajax({
        type: "GET",
        url: `https://date.nager.at/api/v3/PublicHolidays/${year}/${countryCode}`,
        dataType: "json",
        success: function (data) {
            var datas = data;
            SaveHolidaysData(datas);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}

var count1 = 0;
function FilterByCountry() {
    count1++;
    if (count1 != 1) {
        reload();
    }

}

function SaveHolidaysData(datas) {
    var DATA = datas;
    $.ajax({
        url: '/Holiday/AddHolidays',
        data: { "prm": DATA },
        type: "POST",
        dataType: "json",
        async: true,
        success: function (result) {
            alert('Successfully Added to the Database');
            $('#tblData').DataTable().ajax.reload();
        },
        error: function () {
            alert('Failed to receive the Data');
        }
    });
}

function GetAllCountry() {
    var select = $("#ddlCountryList");
    $.ajax({

        type: "GET",
        url: "https://date.nager.at/api/v3/AvailableCountries",

        dataType: "json",
        success: function (data) {
            var datavalue = data;
            var serverResponse = datavalue;
            contentType: "application/json";
            $.each(serverResponse, function (i, serverResponse) {
                select.append("<option value='" + serverResponse.countryCode + "'>" + serverResponse.name + "</option>")
            });
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}
var count = 0;
function loadHolidays() {
    count++;
    if (count != 1) {
        reload();
    }
}

function loadDataTable() {

    var countryCode = $('#ddlCountryList option:selected').val();
    var year = $('#ddlYear option:selected').val();
    var toDate = $('#toDate').val();
    var fromDate = $('#fromDate').val();

        $('#tblData').DataTable({
            "ajax": {
                "url": "Holiday/GetAll",
                "dataSrc": '',
                "data": { 'countryCode': countryCode, 'year': year, 'fromDate': fromDate, 'toDate': toDate}
            },
            dom: 'Bfrtip',
            buttons: [
                'copy', 'excel', 'csv', 'pdf'
            ],
            "columns": [
                { "data": "date" },
                { "data": "localName" },
                { "data": "name" },
                { "data": "countryCode" },
                { "data": "fixed" },
                { "data": "global" },
                { "data": "counties" },
                { "data": "launchYear" }
            ],
            //columnDefs: [
            //    /*{ "targets": 1, "width": "12%", render: $.fn.dataTable.render.moment('Do MMM YYYYY')  },*/
            //]
        });
}

function reload() {
    setTimeout(function () {
        debugger;
        $('#tblData').DataTable().destroy();
        loadDataTable();
        $('#tblData').DataTable().ajax.reload();
    }, 2000);
}
