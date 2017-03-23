// Write your Javascript code.

function DeleteFunction() {
    var txt;
    var r = confirm("Are you sure you want to delete this user?");
    if (r == true) {
        txt ='<input style="background: none;border:none;color:red" type="submit" value="Delete">';
    } else {
        txt = "The user will not be deleted";
    }
    document.getElementById("demo").innerHTML = txt;
}
