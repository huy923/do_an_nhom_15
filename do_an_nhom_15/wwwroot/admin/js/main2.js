function loadEmployeeData(EmployeeId, FirstName, LastName, Email, PhoneNumber, Position, Salary, Status) {
    document.getElementById("inputfirstName").value = FirstName;
    document.getElementById("inputlastName").value = LastName;
    document.getElementById("inputemail").value = Email;
    document.getElementById("inputphoneNumber").value = PhoneNumber;
    document.getElementById("inputposition").value = Position;
}
document.addEventListener('keydown', function (event) {
    if (event.key === '/') {
        event.preventDefault();
        document.querySelector('input[name="searchTerm"]').focus();
    }
});