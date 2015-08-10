$(document).ready(function () {

    // process the form
    $('form').submit(function (event) {

        // get the form data
        // there are many ways to get this data using jQuery (you can use the class or id also)
        var formData = {
            'Id': 0,
            'TradeShowName': $('input[name=TradeShowName]').val(),
            'LeadName': $('input[name=LeadName]').val(),
            'EmailAddress': $('input[name=EmailAddress]').val(),
            'Telephone': $('input[name=EmailAddress]').val()
        };

        // process the form
        $.ajax({
            type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
            url: 'http://sampatdarshan-prod.apigee.net/ILS/v1/LeadManagement?apikey=d2ZUIIdKE893NHt5dsRHe9zKeUSNdN3a', // the url where we want to POST
            data: formData, // our data object
            dataType: 'json', // what type of data do we expect back from the server
            encode: true,
            success: window.location.href('http://sampatdarshan-prod.apigee.net/ILS/v1/LeadManagement?apikey=d2ZUIIdKE893NHt5dsRHe9zKeUSNdN3a')
        })
           
        // stop the form from submitting the normal way and refreshing the page
        event.preventDefault();
    });

});

$(document).ready(function () {
    $("#TestDel").click(function () {
        $.ajax({
            url: "http://sampatdarshan-prod.apigee.net/ILS/v1/LeadManagement?apikey=d2ZUIIdKE893NHt5dsRHe9zKeUSNdN3a",
            type: "DELETE",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        })
    });
});