function toggleIcon() {
    const button = document.getElementById("iconButton");
    const icon = button.querySelector("i");
    const showChatbot = document.getElementById("showChatbot");

    if (icon.classList.contains("icon-chat_bubble")) {
        icon.classList.remove("icon-chat_bubble");
        icon.classList.add("icon-close");
        showChatbot.classList.remove("d-none");
    } else {
		icon.classList.remove("icon-close");
        icon.classList.add("icon-chat_bubble");
        showChatbot.classList.add("d-none");
    }
}
function syncQuantity() {
    const quantityValue = document.getElementById('quantity').value;
    document.getElementById('hiddenQuantity').value = quantityValue;
}
function moreQuantity() {
    const quantityInput = document.getElementById('quantity').value;
    quantityInput.value += 1;
    syncQuantity();
}
function lessQuantity() {
    const quantityInput = document.getElementById('quantity').value;
    quantityInput.value -= 1;
    syncQuantity();
}