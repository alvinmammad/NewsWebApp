$(document).ready(function () {


    //Fill Subcategories by Categories
    $("#categories").change(function () {
        var value = $(this).val();

        $("#subcategories option").remove();

        $.ajax({
            url: "/Admin/News/FillCategories/" + value,
            type: "post",
            dataType: "json",
            success: function (response) {
                if (response.status == 200) {
                    for (var i = 0; i < response.data.length; i++) {
                        var option = `<option value="${response.data[i].id}">${response.data[i].name}</option>`
                        $("#subcategories").append(option);
                    }
                } else {
                    $(".subcategory_error_message").text(response.message);
                }
            }
        })
    })


    //------------------Photo Upload --------------------------//
    var array = [];

    $("#Photo").change(function () {

        array = [];
        $(".photos li").remove();

        var files = $(this).get(0).files;
        for (var file of files) {
            array.push(file);
        }

        var formData = new FormData();
        for (var arr of array) {
            formData.append("Photos[]", arr);
        }

        $.ajax({
            url: "/Admin/News/AddPhoto/",
            data: formData,
            cache: false,
            processData: false,
            contentType: false,
            dataType: "json",
            type: "post",
            success: function (response) {
                if (response.status == 200) {
                    for (var i = 0; response.data.length; i++) {
                        var listItem = `<li><i class="fas fa-times"></i><img src="${response.data[i].src}" data-name="${response.data[i].name}"></li>`
                        var option = `<option selected value="${response.data[i].name}">${response.data[i].name}</option>`
                        $("select[name='PhotoNames']").append(option);
                        $(".photos").append(listItem);
                    }
                }
            }
        })
    })


    $(".photos").on("click", "li i", function () {

        //find list and img
        var listItem = $(this).parent();
        var obj = {
            filename: $(listItem.find("img")).data("name")
        };

        //remove from array
        for (var i = 0; i < array.length; i++) {
            if (array[i].name == $(listItem.find("img")).data("name")) {
                array.splice(i, 1);
            }
        }


        //delete from view (img)
        $(this).parent().remove();

        $("select[name='PhotoNames'] option[value='" + $(listItem.find("img")).data("name") + "']").remove();

        //delete from server
        $.ajax({
            url: "/Admin/News/DeletePhoto/",
            data: obj,
            dataType: "json",
            type: "post",
            success: function (response) {
                if (response.status == 200) {
                    alert("Sekil silindi");
                } else {
                    alert("sekil silinmedi mal! Gerizekali")
                }
            }
        })
    })
})