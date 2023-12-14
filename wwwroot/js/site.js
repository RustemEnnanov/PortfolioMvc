function AddCommunication() {
    var node = document.createElement('input');
    node.type = "text";
    node.name = "Communications";
    node.setAttribute("class", "form-control");

    $('#CommunicationBlock').append(node);
}