var BookHandler = function () {    
    /*
     * Can access this.method
     * inside other methods using
     * root.method()
     */
    var root = this;

    /*
     * Constructor
     */
    root.construct = function () {
        //$.extend(vars, options);
    };

    /*
     * Public method
     * Can be called outside class
     */
    root.GetAll = async function () {
        const response = await fetch("/api/book", {
            method: "GET",
            headers: { "Accept": "application/json" }
        });

        if (response.ok === true) {
            // Get data
            const books = await response.json();
            let rows = document.querySelector("tbody");
            books.forEach(book => {
                rows.append(rowMethod(book));
            });
        }
    };

    root.SearchBook = async function (title, releaseDate) {
        const response = await fetch("/api/book/search", {
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "title": title,
                "releaseDate": releaseDate == '' ? null : releaseDate
            })
        });
        if (response.ok === true) {
            const books = await response.json();
            $("tbody").children().remove();
            let rows = document.querySelector("tbody");
            books.forEach(book => {
                rows.append(rowMethod(book));
            });
        }
    }

    root.DeleteBook = async function (id) {
        const response = await fetch("/api/book/" + id, {
            method: "DELETE",
            headers: { "Accept": "application/json" }
        });
        if (response.ok === true) {
            const id = await response.json();
            document.querySelector("tr[data-rowid='" + id + "']").remove();
        }
    }

    /*
     * Private method
     * Can only be called inside class
     */
    var rowMethod = function (book) {

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
        editLink.setAttribute("href", "/BookMvc/AddEdit/"+book.id);
        editLink.setAttribute("style", "cursor:pointer;padding:15px;");
        editLink.append("Edit");
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

    /*
     * Pass options when class instantiated
     */
    //this.construct(options);
    root.construct();
}



document.bookForm.search.addEventListener("click", e => {
    e.preventDefault();
    const title = document.bookForm.title.value;
    const releaseDate = document.bookForm.releaseDate.value;
    bookHandler.SearchBook(title, releaseDate);
});

// reset form
document.bookForm.reset.addEventListener("click", e => {
    e.preventDefault();
    const form = document.bookForm;
    form.id.value = 0;
    form.title.value = "";
    form.releaseDate.value = null;
    $("tbody").children().remove();
    bookHandler.GetAll();
});