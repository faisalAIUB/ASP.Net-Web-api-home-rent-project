$(function () {

    var load = function () {
        $('#main').show();
        $('#logindiv').hide();
        $('#signupdiv').hide();
        $('#profilemanubar').hide();

    }
    load();
    $.ajax({
        url: 'http://localhost:5213/api/rentads',
        header: 'Content-Type: application/json',
        complete: function (xmlhttp) {
            if (xmlhttp.status == 200)
            {
                var rentAds = xmlhttp.responseJSON;
                var outputStr = '';
                for (var i = 0; i < rentAds.length; i++)
                {
                    //outputStr += 'Flat no:' + rentAds[i].flatNo + 'Road No:' + rentAds[i].roadNo+'<br/>';
                    outputStr += '<P>'+'Flat NO:' + rentAds[i].flatNo + 'Road NO:' + rentAds[i].roadNo + '</p>';
                    
                }
                $("#showall").html(outputStr);
            }
            else {
                $('#msg').html(xmlhttp.status + ":" + xmlhttp.statusText);
            }
        }
    });
    var logIn = function () {
        $('#main').hide();
        $('#logindiv').show();
        $('#signupdiv').hide();
        
    }
    var Profile = function () {
        $('#main').hide();
        $('#logindiv').hide();
        $('#signupdiv').hide();
        $('#mainmanubar').hide();
        $('#profilediv').show();
        $('#profilemanubar').show();
    }
    $('#profile').click(function(){
        Profile();
    });
    $('#login').click(function () {
        logIn();
    });
    $('#home').click(function () {
        $('#main').show();
        $('#logindiv').hide();
        $('#signupdiv').hide();
       
    });
    $('#signup').click(function () {
        $('#signupdiv').show();
        $('#logindiv').hide();
        $('#main').hide();
    });

    $('#btnsignup').click(function(){
        $.ajax({
            url: 'http://localhost:5213/api/user',
            method: 'POST',
            header: 'Content-Type: application/json',
            data: {
                userName: $('#userName').val(),
                email: $('#email').val(),
                phone: $('#phone').val(),
                password: $('#password').val(),
                gender: $('#gender').val(),
                dob: $('#dob').val(),
                deactive: $('#deactive').val()
            },
            complete: function (xmlhttp) {
                if (xmlhttp.status == 201) {
                    logIn();
                }
                else {
                    $('#msgsignup').html(xmlhttp.status + ":" + xmlhttp.statusText);
                }
            },
        });

    });
    //var id;
    var credentialLoad = function () {
        var emailLogin = $('#emaillogin').val();
        var passwordLogin = $('#passwordlogin').val();
        //var credential = btoa('shakil@gmail.com:1234');
        var credential = btoa(emailLogin + ':' + passwordLogin);

        $.ajax({
            url: 'http://localhost:5213/api/user',
            headers: {
                Authorization: 'Basic ' + credential
            },
            complete: function (xmlhttp) {
                if (xmlhttp.status == 200) {
                    //id = xmlhttp.responseJSON;
                    Profile();
                }
                else {
                    $('#msglogin').html(xmlhttp.status + ":" + xmlhttp.statusText);
                }
            }
        });
    }
    $('#btnlogin').click(credentialLoad);
});