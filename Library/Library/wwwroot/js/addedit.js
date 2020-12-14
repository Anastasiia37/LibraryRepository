var BookAddEditHandler = function (options) {
    /*
     * Variables accessible
     * in the class
     */
    var vars = {
        urlBooks: ''
    };


    /*
     * Can access this.method
     * inside other methods using
     * root.method()
     */
    var root = this;

    /*
     * Constructor
     */
    this.construct = function (options) {
        $.extend(vars, options);
    };

    /*
     * Public method
     * Can be called outside class
     */
    root.GetBook = async function (id) {
        const response = await fetch("/api/book/" + id, {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        if (response.ok === true) {
            const book = await response.json();
            $("#title").val(book.title);
            $("#releaseDate").val(book.releaseDate.substr(0, 10));
        }
    };

    root.AddUpdateBook = async function () {
        var idval = $("#idtxt").attr("value");
        var method = idval == 0 ? "POST" : "PUT";
        const response = await fetch("/api/book/", {
            method: method,
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: idval,
                title: $("#title").val(),
                releaseDate: $("#releaseDate").val(),
                publisherId: 2
            })
        });
        if (response.ok === true) {
            alert("The book was saved successfully!");
            //$(location).attr("href", "../../BookMvc/Books");
            $(location).attr("href", urlBooks);
        }
    }

    /*
     * Pass options when class instantiated
     */
    root.construct(options);
}

document.bookForm.save.addEventListener("click", e => {
    e.preventDefault();
    bookAddEditHandler.AddUpdateBook();
});
