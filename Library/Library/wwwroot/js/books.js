// Get all books
async function GetAll() {
    const response = await fetch("/api/book", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        // Get data
        const books = await response.json();
        let rows = document.querySelector("tbody");
        books.forEach(book => {
            rows.append(row(book));
        });
    }
}



async function GetBook(id) {
    const response = await fetch("/api/book/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        //const book = await response.json();
        //const form = document.forms["bookForm"];
    }
}


async function SearchBook(title, releaseDate) {
    const response = await fetch("/api/book/title=" + title + "&releaseDate=" + releaseDate, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const books = await response.json();
        $("tbody").children().remove();
        let rows = document.querySelector("tbody");
        books.forEach(book => {
            rows.append(row(book));
        });
    }
}



async function DeleteBook(id) {
    const response = await fetch("/api/book/" + id, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const id = await response.json();
        document.querySelector("tr[data-rowid='" + id + "']").remove();
    }
}



function reset() {
    const form = document.bookForm;
    form.reset();
    form.id.value = 0;
    form.title.value = "";
    form.releaseDate.value = null;
}


function row(book) {

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", book.id);

   const idTd = document.createElement("td");
    idTd.append(book.id);
    tr.append(idTd);

    const titleTd = document.createElement("td");
    titleTd.append(book.title);
    tr.append(titleTd);

    const publisherTd = document.createElement("td");
    if (book.publisher != null) {
        publisherTd.append(book.publisher.name);
    }
    tr.append(publisherTd);

    const linksTd = document.createElement("td");

    const editLink = document.createElement("a");
    editLink.setAttribute("data-id", book.id);
    editLink.setAttribute("style", "cursor:pointer;padding:15px;");
    editLink.append("Edit");
    editLink.addEventListener("click", e => {

        e.preventDefault();
        GetBook(book.id);
    });
    linksTd.append(editLink);

    const removeLink = document.createElement("a");
    removeLink.setAttribute("data-id", book.id);
    removeLink.setAttribute("style", "cursor:pointer;padding:15px;");
    removeLink.append("Delete");
    removeLink.addEventListener("click", e => {

        e.preventDefault();
        DeleteBook(book.id);
    });

    linksTd.append(removeLink);
    tr.appendChild(linksTd);

    return tr;
}

// reset form
document.getElementById("reset").click(function (e) {
    e.preventDefault();
    reset();
})



document.bookForm.search.addEventListener("click", e => {
    e.preventDefault();
    const title = document.bookForm.title.value;
    const releaseDate = document.bookForm.releaseDate.value;
    SearchBook(title, releaseDate);
});

GetAll();
