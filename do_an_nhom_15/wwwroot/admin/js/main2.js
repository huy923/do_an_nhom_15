
document.addEventListener('keydown', function (event) {
    if (event.key === '/') {
        event.preventDefault();
        document.querySelector('input[name="searchTerm"]').focus();
    }
});
function updateImage() {
    const fileInput = document.getElementById('file_input').value;
    const preview = document.getElementById('preview');

    preview.src = fileInput; 
    //if (imageUrl) {
    //    preview.style.display = 'block'; // Hiển thị ảnh
    //} else {
    //    preview.style.display = 'none'; // Ẩn ảnh nếu không có URL
    //}
}

