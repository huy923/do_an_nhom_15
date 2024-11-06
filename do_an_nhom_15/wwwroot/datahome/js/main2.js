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
