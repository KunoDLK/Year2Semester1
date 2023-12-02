// When page has loaded
$(document).ready(function () {

    $('#MovieId').prop("disabled", true);

    loadDirector();

    $('#DirectorId').change(function () {
        alert(this.value);
        loadMovies(this.value);
    });

});


function loadDirector() {
    $.ajax({
        url: "https://localhost:7182/api/People",
        type: "GET",
        crossDomain: true,
        success: function (result) {
            $('#DirectorId').html('');       // Empty select list
            var options = '';
            options += '<option value="Select">Select</option>';
            for (var i = 0; i < result.length; i++) {
                options += '<option value="' + result[i].personId + '">' +
                    result[i].lastName + ", " + result[i].firstName +
                    '</option>';
            }
            $('#DirectorId').append(options);
        },
        error: function () {
            alert("Unable to load people list.");
        }

    });
}

function loadMovies(directorId) {
    $.ajax({
        url: "https://localhost:7182/api/movies/director/" + directorId,
        type: "GET",
        success: function (result) {
            $('#MovieId').html('');     // Empty select list
            var options = '';
            options += '<option value="Select">Select</option>';
            for (var i = 0; i < result.length; i++) {
                options += '<option value="' + result[i].id + '">' +
                    result[i].title +
                    '</option>';
            }
            $('#MovieId').append(options);
            $('#MovieId').removeAttr("disabled")
        },
        error: function () {
            alert("Unable to load movies list.");
        }
    });
}


