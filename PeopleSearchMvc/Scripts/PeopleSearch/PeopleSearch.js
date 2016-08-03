(function($) {
    $(function() {
        $(".peopleSearchSubmit, .peopleSearchBox")
            .on("click keyup",
                function (e) {
                    //trigger the search when the user hits enter or click on the search button
                    if ((e.type == "click" && e.currentTarget.className == "peopleSearchSubmit") ||
                    (e.type == "keyup" && e.keyCode == 13 && e.currentTarget.className == "peopleSearchBox")) {
                        var $searchBox = $(".peopleSearchBox");
                        var searchStringModel = { searchStringModel: { searchString: $searchBox.val() } };
                        var searchStringModelJsonString = JSON.stringify(searchStringModel);
                        var $busy = $("#busydiv");

                        //setup to displaying the processing gif
                        $.ajaxSetup({
                            beforeSend: function() {
                                $busy.show();
                            },
                            complete: function() {
                                $busy.hide();
                            }
                        });

                        //ajax with post type and jason as response data type.
                        $.ajax({
                            url: "/Home/SearchPeople",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            data: searchStringModelJsonString,
                            success: function(data) {
                                $(".peopleList").html(data.viewResult);
                            }
                        });
                    }
                });
    });
})(jQuery)