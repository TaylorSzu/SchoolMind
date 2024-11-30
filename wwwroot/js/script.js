// Seleciona os elementos principais pelos IDs
const containerLogin = document.getElementById('loginContainer');
const containerRegister = document.getElementById('registerContainer');

// Seleciona os links de troca
const linkToRegister = document.getElementById('linkToRegister');
const linkToLogin = document.getElementById('linkToLogin');

// Função para mostrar a tela de registro com animação lateral
linkToRegister.addEventListener('click', (e) => {
  e.preventDefault(); // Evita recarregar a página
  containerLogin.classList.add('hidden-left'); // Move o login para a esquerda
  containerRegister.classList.add('show-register'); // Traz o registro para o centro
});

// Função para voltar para a tela de login com animação lateral
linkToLogin.addEventListener('click', (e) => {
  e.preventDefault(); // Evita recarregar a página
  containerRegister.classList.remove('show-register'); // Move o registro para a direita
  containerLogin.classList.remove('hidden-left'); // Traz o login de volta
});
