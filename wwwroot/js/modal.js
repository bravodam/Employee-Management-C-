const guarantorDiv = document.querySelector('#guarantorDiv');

var x = $('#addPage');
console.log(x);
class Guarantor {
    constructor(name, studentId, phone, docUrl) {
        this.name = name;
        this.studentId = studentId;
        this.phone = phone;
        this.docUrl = docUrl;
    }
}

const saveGuarantor = (e, id) => {

    e.preventDefault();
    let name = document.querySelector('#name').value;
    let studentId = document.querySelector('#studentId').value;
    let phone = document.querySelector('#phone').value;
    let docUrl = document.querySelector('#docUrl').value;

    const guarantor = new Guarantor(name, studentId, phone, docUrl);

    storeInDb(guarantor);
    manage();
}

function manage() {
    $(document).ready(function () {
        $("#createGuarantor").modal("toggle");
    });
}

const populate = (obj, id) => {
    console.log(guarantorDiv);

    if (obj.data.length > 0) {
        obj.data.forEach(obj => {
            //let elem = document.createElement('a');

            let elem = document.createElement('p');
            let text = `<a href="/guarantor/details/${obj.guarantorId}">${obj.name} <span class="btn btn-danger float-right" onclick="return confirm('Are you sure?')">X</span></a> <br />`;
            //elem.textContent = obj.name;
            //elem.setAttribute('href', '/guarantor/details/' + id);

            elem.innerHTML = text;
            guarantorDiv.appendChild(elem);
            //guarantorDiv.appendChild(elem);
            //guarantorDiv.appendChild(document.createElement('br'));
            console.log("appended");
        })
    } else {
        guarantorDiv.innerHTML = "<h5>None at the moment</h5>";
    }
}

const storeInDb = (obj) => {
    $(document).ready(function () {
        $.ajax({
            url: "/guarantor/create",
            method: "POST",
            dataType: "json",
            data: obj,
            success: function (res) {
                if (res.success) {
                    getAllGuarantors(res.id);
                }
            }
        });
    });
    console.log("done");
}

const getAllGuarantors = (id) => {
    console.log("hello");
    $(document).ready(function () {
        $.ajax({
            url: "/guarantor/studentguarantors/"+id,
            method: "GET",
            dataType: "json",
            success: function (res) {
                console.log(res);
                guarantorDiv.innerHTML = "";
                populate(res, id);
            }
        });
        console.log("done");
    });
}


