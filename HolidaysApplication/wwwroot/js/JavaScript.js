var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function GetAllCountry() {
    var select = $("#ddlCountryList");
    $.ajax({

        type: "GET",
        url: "https://date.nager.at/api/v3/AvailableCountries",

        dataType: "json",
        success: function (data) {
            var datavalue = data;
            console.warn(data.length);
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

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "https://date.nager.at/api/v3/AvailableCountries"
            
        },
        "columns": [
            { "data": "name", "width": "15%" },

            //{
            //    "data": "name",
            //    "render": function (data) {
            //        return `
            //                <div class="text-center">
            //                    <a href="/Admin/Company/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
            //                        <i class="fas fa-edit"></i>
            //                    </a>
            //                    <a onclick=Delete("/Admin/Company/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
            //                        <i class="fas fa-trash-alt"></i>
            //                    </a>
            //               </div>`;

            //    }, "width": "40%"
            //}
        ]
    });
}