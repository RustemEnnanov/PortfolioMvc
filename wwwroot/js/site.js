function AddCommunication() {
    var node = document.createElement('input');
    node.type = "text";
    node.name = "Communications";
    node.setAttribute("class", "form-control");

    $('#CommunicationBlock').append(node);
}
function ClosePostCareerProfile()
{
    $('.form_post_active').attr('class', 'form_post_hidden');
}
function onAddExperiencePost() {
    var tag = this.document.createElement('div');
    tag.setAttribute("class", "item");
    tag.innerHTML = "<div class=\"meta\">" +
        "<div class=\"upper-row\">" +
        "<h3 class=\"job-title\"> Lead Developer </h3>" +
        "<div class=\"time\">2015 - Present</div>" +
        "</div>" +
        "<div class=\"company\">Startup Hubs, San Francisco</div>" +
        "<div class=\"details\">" +
        "<p>Describe your role here lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo.</p>" +
        "<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. </p>" +
        "</div>";
    var section = this.document.getElementById("experiences-post");
    section.append(tag);
}
function onEditePost()
{
    $('.form_post_hidden').attr('class','form_post_active');
}
function sendPostFormData() {
    const myForm = document.getElementById('form-data-edit');

        // Получаем данные из формы
        const formData = new FormData(myForm);
    var user = '@HttpContext.Session.GetJson<ViewHome>("ViewHome")'
        // Отправляем данные на сервер
        fetch('/Home/EditePost', {
            method: 'POST',
            body: formData,
        })
            .then((response) => {
                // Обрабатываем ответ от сервера
                console.log(response);
            })
            .catch((error) => {
                // Обрабатываем ошибку
                console.error(error);
            });
}