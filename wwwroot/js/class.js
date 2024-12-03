document.addEventListener("DOMContentLoaded", function () {
    const showCreateFormBtn = document.getElementById("show-create-form");
    const formContainer = document.getElementById("form-container");

    showCreateFormBtn.addEventListener("click", function () {
        fetch("/Class/NewClass")
            .then(response => {
                if (!response.ok) throw new Error("Erro ao carregar o formulário");
                return response.text();
            })
            .then(html => {
                formContainer.innerHTML = html;
                setupCancelButton();
            })
            .catch(error => console.error(error));
    });

    function setupCancelButton() {
        const cancelBtn = document.getElementById("cancel-create");
        if (cancelBtn) {
            cancelBtn.addEventListener("click", function () {
                formContainer.innerHTML = ""; // Esconde o formulário
            });
        }
    }
});
