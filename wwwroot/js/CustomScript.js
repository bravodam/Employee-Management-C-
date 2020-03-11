console.log("connected");

const deleteData = (id, confirm) => {
    const deleteSpan = `#deleteSpan_${id}`;
    const confirmDeleteSpan = `#confirmDeleteSpan_${id}`;
    console.log(confirm);
    if (confirm) {
        $(deleteSpan).hide();
        $(confirmDeleteSpan).show();
    } else {
        $(deleteSpan).show();
        $(confirmDeleteSpan).hide();
    }
}
