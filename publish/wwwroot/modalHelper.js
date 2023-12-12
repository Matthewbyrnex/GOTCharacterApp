function updateModalContent(contentHtml) {
    var modalBody = document.querySelector('#detailsModal .modal-body');
    modalBody.innerHTML = contentHtml;
    $('#detailsModal').modal('show');
}
