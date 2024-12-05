document.addEventListener("DOMContentLoaded", function () {
    const showCreateFormBtn = document.getElementById("show-create-form");
    const formContainer = document.getElementById("form-container");
    const cancelBtn = document.getElementById("cancel-create");

    showCreateFormBtn.addEventListener("click", function () {
        formContainer.style.display = "block"; // Mostrar o formulário
    });

    cancelBtn.addEventListener("click", function () {
        formContainer.style.display = "none"; // Esconder o formulário
    });
});
