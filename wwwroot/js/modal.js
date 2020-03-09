const guarantorDiv = document.querySelector('#guarantorDiv');

class Guarantor {
    constructor(name, studentId, phone, docUrl) {
        this.name = name;
        this.studentId = studentId;
        this.phone = phone;
        this.docUrl = docUrl;
    }
}

// Class for Course
class Course {
    constructor(title, level, id) {
        this.title = title;
        this.level = level;
        this.studentId = id;
    }
}

// Function To Add A Guarantor
const saveGuarantor = (e, id) => {

    e.preventDefault();
    let name = document.querySelector('#name').value;
    let studentId = document.querySelector('#studentId').value;
    let phone = document.querySelector('#phone').value;
    let docUrl = document.querySelector('#docUrl').value;

    const guarantor = new Guarantor(name, studentId, phone, docUrl);

    storeInDb(guarantor, "/guarantor/create");
    closeModal();
}

// Function To Add A Course
const saveCourse = (e) => {
    e.preventDefault();
    let title = document.querySelector('#title').value;
    let level = document.querySelector('#level').value;
    let studentId = document.querySelector('#studentId').value;

    const course = new Course(title, level, studentId);
    console.log(course);

    storeInDb(course, "/course/saveajax");
    closeModal();
}


// Send To Database

const storeInDb = (obj, url) => {
    $(document).ready(function () {
        $.ajax({
            url: url,
            method: "POST",
            dataType: "json",
            data: obj,
            success: function (res) {
                if (res.success) {
                    if (res.type === "guarantor") {
                        getAllGuarantors(res.id);
                    } else if (res.type === "course") {
                        getStudentCourses(res.id);
                    }
                }
            }
        });
    });
}

// Update View

const populate = (obj) => {
    guarantorDiv.innerHTML = "";
    if (obj.data.length > 0) {
        obj.data.forEach(obj => {
            //let elem = document.createElement('a');

            let elem = document.createElement('p');
            let text = `<span><a href="/guarantor/details/${obj.guarantorId}">${obj.name}</a></span> <span class="btn btn-danger float-right p-0" onclick="totalCount(${obj.id}, ${obj.studentId})">X</span> <br />`;

            elem.innerHTML = text;
            guarantorDiv.appendChild(elem);
            
        })
    } else {
        guarantorDiv.innerHTML = "<h5>None at the moment</h5>";
    }
}

// Display Student COurses

const listCourse = (obj, studentId) => {
    document.querySelector('#coursesDiv').innerHTML = "";

    let elem = document.createElement('ul');
    elem.classList.add('list-group');

    if (obj.data.length > 0) {
        obj.data.forEach(itm => {
            let li = document.createElement('li');
            li.classList.add('list-group-item');
            li.innerHTML = `<a href="/course/details/${itm.courseId}">${itm.title}</a> <span class="btn btn-danger float-right p-0" onclick="deleteCourse(${studentId}, ${itm.courseId})">X</span>`;
            elem.appendChild(li);
            console.log(elem);
        });
        document.querySelector('#coursesDiv').appendChild(elem);
    } else {
        document.querySelector('#coursesDiv').innerHTML = "<h6>None at the moment</h6>";
    }
}

//Get Guarantors Of A Student

const getAllGuarantors = (id) => {
    console.log("hello");
    $(document).ready(function () {
        $.ajax({
            url: "/guarantor/studentguarantors/" + id,
            method: "GET",
            dataType: "json",
            success: function (res) {
                console.log(res);
                populate(res);
            }
        });
        console.log("done");
    });
}


//Get Courses Of A Student

const getStudentCourses = (studentId) => {
    console.log("hello");
    $(document).ready(function () {
        $.ajax({
            url: "/course/studentcourses/"+studentId,
            method: "GET",
            dataType: "json",
            success: function (res) {
                console.log(res);
                listCourse(res, studentId);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(errorThrown);
            } 
        });
        console.log("done");
    });
}

// Delete Student Course

const deleteCourse = (studentId, courseId) => {
    swal({
        title: "Are you sure?",
        text: "You are removing one of the student's course!",
        buttons: true,
        icon: "warning",
        danger: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: "/course/clear/?" + $.param({ studentId: studentId, courseId: courseId }),
                method: "DELETE",
                dataType: "json",
                success: function (res) {
                    console.log(res);
                    if (res.success) {
                        toastr.success(res.message);
                        getStudentCourses(studentId);
                    } else {
                        toastr.error(res.message);
                    }
                }
            });
        }
    });
}

const totalCount = (guarantorId, studentId) => {
    $(document).ready(function () {
        let resource;
        $.ajax({
            url: "/guarantor/allstudentguarantors",
            method: "GET",
            dataType: "json",
            success: function (res) {
                console.log("all");
                console.log(res);
                resources = res.data.find(x => x.studentId === studentId && x.guarantorId === guarantorId);
                console.log(resource);
            }
        });
        let url = "/guarantor/clear/" + "?" + $.param({ studentId: studentId, guarantorId: guarantorId });
        Clear(url, studentId);
        console.log("done");
    });
}


function Clear(url, studentId) {
    swal({
        title: "Are You Sure",
        text: "Once deleted, you will not be able to recover",
        buttons: true,
        icon: "warning",
        danger: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        $.ajax({
                            url: "/guarantor/studentguarantors/" + studentId,
                            method: "GET",
                            dataType: "json",
                            success: function (res) {
                                populate(res);
                            }
                        });
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

// Close Modal on Submit
function closeModal() {
    $(document).ready(function () {
        console.log('Enters');
        const inputs = document.querySelectorAll('input');
        Array.from(inputs).forEach(input => {
            if (!input.hasAttribute('disabled')) {
                input.innerHTML = '';
                console.log(input.innerHTML);
            }
        })
        $("#createGuarantor").modal("hide");
        $("#createCourse").modal("hide");
    });
}