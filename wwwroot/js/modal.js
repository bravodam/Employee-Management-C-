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

// Class for Project

class Project {
    constructor(title, description, gitUrl, id) {
        this.title = title;
        this.description = description;
        this.gitUrl = gitUrl;
        this.studentId = id;
    }
}

// Class for Payment Detail

class PaymentDetail {
    constructor(amountPaid, date, studentId, paymentId) {
        this.amountPaid = amountPaid;
        this.date = date;
        this.studentId = studentId;
        this.paymentId = paymentId;
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

const saveProject = (e) => {
    e.preventDefault();
    let title = document.querySelector('#projectTitle').value;
    let description = document.querySelector('#description').value;
    let gitUrl = document.querySelector('#gitUrl').value;
    let studentId = document.querySelector('#student-id').value;

    const project = new Project(title, description, gitUrl, studentId);
    storeInDb(project, "/project/saveajax");
    closeModal();
}

// SAVE PAYMENT DETAIL
const savePaymentDetail = (e) => {
    e.preventDefault();
    let amountPaid = document.querySelector('#amountPaid').value;
    let date = document.querySelector('#date').value;
    let paymentId = document.querySelector('#paymentId').value;
    let studentId = document.querySelector('#student_id').value;

    const pd = new PaymentDetail(amountPaid, date, studentId, paymentId);
    storeInDb(pd, "/paymentdetails/saveajax");
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
                    } else if (res.type === "project") {
                        getStudentProjects(res.id);
                    } else if (res.type === "details") {
                        getStudentPaymentDetails(res.id);
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

// Display Student Projects
const listProjects = (obj, studentId) => {
    document.querySelector('#projectsDiv').innerHTML = "";

    let elem = document.createElement('ul');
    elem.classList.add('list-group');

    if (obj.data.length > 0) {
        obj.data.forEach(itm => {
            let li = document.createElement('li');
            li.classList.add('list-group-item');
            li.innerHTML = `<a href="/project/details/${itm.projectId}" class="h4 mr-4">${itm.title}</a> <span><a href="${itm.gitUrl}" target="_blank">${itm.gitUrl}</a></span> <span class="btn btn-danger float-right p-0" onclick="deleteProject(${studentId}, ${itm.projectId})">X</span>`;
            elem.appendChild(li);
        });
        document.querySelector('#projectsDiv').appendChild(elem);
    } else {
        document.querySelector('#projectsDiv').innerHTML = "<h6>None at the moment</h6>";
    }
}

// Display Student Payment Details
const listPaymentDetails = (obj, studentId) => {
    const tbody = document.querySelector('#detailsBody');
    tbody.innerHTML = "";

    if (obj.data.length > 0) {
        obj.data.forEach(itm => {
            let tr = document.createElement('tr');
            tr.innerHTML = `
                            <td>${itm.amountPaid}</td>
                            <td>${itm.date}</td>
                            <td><i class="p-0 fa fa-trash text-danger" onclick="deletePaymentDetail(${itm.id}, ${itm.paymentId}, ${studentId})"></i></td>
                           `;
            tbody.appendChild(tr);
        });
        //document.querySelector('#detailBody').appendChild(elem);
    } else {
        document.querySelector('#detailsBody').innerHTML = "<h6>None at the moment</h6>";
    }
}

// Delete Student Payment Details

const deletePaymentDetail = (id, paymentId, studentId) => {
    swal({
        title: "Are you sure?",
        text: "You are removing one of the student's course!",
        buttons: true,
        icon: "warning",
        danger: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: "/paymentdetails/clear/?" + $.param({ id: id, paymentId: paymentId }),
                method: "DELETE",
                dataType: "json",
                success: function (res) {
                    console.log(res);
                    if (res.success) {
                        //e.target.remove();
                        toastr.success(res.message);
                        getStudentPaymentDetails(paymentId, studentId);
                    } else {
                        toastr.error(res.message);
                    }
                }
            });
        }
    });
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

const getStudentProjects = (studentId) => {
    console.log("projects");
    $.ajax({
        url: "/project/studentprojects/" + studentId,
        method: "GET",
        datatype: "json",
        success: function (res) {
            console.log(res);
            listProjects(res, studentId);
        },
        error: function (err) {
            console.log(err);
        }
    })
}

const getStudentPaymentDetails = (paymentId, studentId) => {
    console.log("payment details");
    $.ajax({
        url: "/paymentdetails/studentpaymentdetails/" + paymentId,
        method: "GET",
        datatype: "json",
        success: function (res) {
            console.log(res);
            listPaymentDetails(res, studentId);
        },
        error: function (err) {
            console.log(err);
        }
    })
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

// Delete Student Project

const deleteProject = (studentId, projectId) => {
    swal({
        title: "Are you sure?",
        text: "You are removing a project for this student!",
        buttons: true,
        icon: "warning",
        danger: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: "/project/clear/?" + $.param({ studentId: studentId, projectId: projectId }),
                method: "DELETE",
                dataType: "json",
                success: function (res) {
                    console.log(res);
                    if (res.success) {
                        toastr.success(res.message);
                        getStudentProjects(studentId);
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
        const inputs = document.querySelectorAll('input');
        Array.from(inputs).forEach(input => {
            if (!input.hasAttribute('disabled')) {
                input.innerHTML = '';
                console.log(input.innerHTML);
            }
        })
        $("#createGuarantor").modal("hide");
        $("#createCourse").modal("hide");
        $("#createProject").modal("hide");
        $("#addPaymentDetail").modal("hide");
    });
}