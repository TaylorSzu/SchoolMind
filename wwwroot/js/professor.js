function toggleDropdown(id) {
    document.getElementById(id).classList.toggle("show-dropdown");
}

function closePop(id) {
    document.getElementById(id).style.display = 'none';
}

function openPop(event, id) {
    event.preventDefault();
    document.getElementById(id).style.display = 'block';
}

function aparecerConteiner(conteinerId) {
    const conteiner = document.getElementById(conteinerId);
    conteiner.style.display = (conteiner.style.display === 'flex') ? 'none' : 'flex';
}

function aparecerConteiner2(conteinerId) {
    const conteiner = document.getElementById(conteinerId);
    conteiner.style.display = (conteiner.style.display === 'block') ? 'none' : 'block';
}

function toggleMaterialType() {
    const tipo = document.getElementById('tipoMaterial').value;
    const campos = {
        arquivo: document.getElementById('campoArquivo'),
        texto: document.getElementById('campoTexto'),
        link: document.getElementById('campoLink')
    };

    Object.values(campos).forEach(campo => campo.style.display = 'none');
    if (campos[tipo]) campos[tipo].style.display = 'block';
}

function toggleGerenciarTurma() {
    const gerenciarTurma = document.getElementById('gerenciarTurma');
    const gerenciarTurmaAluno = document.getElementById('turmaAluno');
    
    if (gerenciarTurma.style.display === 'none') {
        gerenciarTurma.style.display = 'block';
        gerenciarTurmaAluno.style.display = 'none';
    } else {
        gerenciarTurma.style.display = 'none';
        gerenciarTurmaAluno.style.display = 'block';
    }
}