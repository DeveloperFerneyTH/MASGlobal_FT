function getEmployee() {
    var name = $("#txtName").val();

    $.ajax({
        url: "Employee/GetEmployee",
        data: { name: name },
        method: "GET",
        success: function (result) {
            if (result.Success) {
                $("#dvResult").show("slow");
                $("#tbEmployee > tBody").html("");
                console.log(result);
                if (result.Data.length > 1) {
                    $.each(result.Data, function (i, emp) {
                        $("#tbEmployee > tbody").append("<tr><td>" + emp.Name +
                            "</td><td>" + emp.ContractTypeName +
                            "</td><td>" + emp.AnualSalary + "</td></tr>");
                    });
                }
                else {
                    $("#tbEmployee > tbody").append("<tr><td>" + result.Data.Name +
                        "</td><td>" + result.Data.ContractTypeName +
                        "</td><td>" + result.Data.AnualSalary + "</td></tr>");
                }
            }
            else {
                swal("Ooops", result.Message, "error");
            }
        }
    })
}