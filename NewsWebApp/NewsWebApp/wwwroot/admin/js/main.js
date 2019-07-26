$(document).ready(function () {
    // Hide Show Search Menu
    var searchInput = document.querySelector(".searchInput .form-control");
    var searchButton = document.querySelector(".searchButton");
    var searchIcon = document.querySelector(".searchButton i")
    // On Click Search input add Css to showing search Input


    // If you clicked another place hide search input
    document.addEventListener("click", function (e) {
        if (event.target.tagName != "INPUT") {
            hideSearchInput();
        }
    })

    searchInput.addEventListener("click", function (e) {
        showSearchInput();
    });


    // Show And Hide searchInput functions
    function showSearchInput() {
        // ADD CSS TO SEARCHiNPUT (border bgColor animation);
        searchInput.style.backgroundColor = "white";
        searchInput.style.border = "1px solid white";
        searchInput.style.animationName = "show";
        searchInput.style.animationDuration = "0.25s";
        // SearchButton Css (bgColor Animation Border)
        searchButton.style.backgroundColor = "#00bdd5";
        searchButton.style.border = "1px solid #00bdd5";
        searchButton.style.animationName = "show";
        searchButton.style.animationDuration = "0.25s";
        searchIcon.style.opacity = "1";

    }
    function hideSearchInput() {
        searchInput.style.animationName = "hide";
        searchButton.style.animationName = "hide";
        searchInput.style.border = "0px";
        searchInput.style.backgroundColor = "transparent";
        searchInput.style.animationDuration = "0.25s";

        searchButton.style.backgroundColor = "transparent";
        searchButton.style.border = "0px";
        searchIcon.style.opacity = "0";
        searchButton.style.animationDuration = "0.25s";
    }
    // Slide Toggle List Items( Side Bar Drop Down)
    $(".list-items.dropList").click(function () {
        $(this).toggleClass("active");

        if ($("#mainContainer").hasClass("hide")) {
            $("#sideBar").removeClass("hide");
            $("#mainContainer").removeClass("hide");
            $("#mainContainer").addClass("show");
            $(".navTop").removeClass("hide");
            $(".navTop").addClass("show");

            $(".list-items").removeClass("hide");
            $(".list-items").addClass("show");

            $(".downIcon").removeClass("hide");
            $(".percent").removeClass("hide");
            $(".board").removeClass("hide");
            $(".logo span").removeClass("font");

        }
        if ($(this).next().hasClass("dropDown")) {
            $(this).next().slideToggle();
        }
    });
    //   Hide Side Menu
    $(".icon").click(function () {
        //   Add active class to change color
        $(this).toggleClass("active");
        $(".list-items").removeClass("active");
        $(".dropList").next().slideUp();
        //   hide side menu and container
        $("#sideBar").toggleClass("hide");
        // OPen And Close Main Container
        if ($("#mainContainer").hasClass("show")) {
            $("#mainContainer").removeClass("show");
            $("#mainContainer").addClass("hide");
        } else {
            $("#mainContainer").removeClass("hide");
            $("#mainContainer").addClass("show");
        }

        if ($(".navTop").hasClass("show")) {
            $(".navTop").removeClass("show");
            $(".navTop").addClass("hide");
        } else {
            $(".navTop").removeClass("hide");
            $(".navTop").addClass("show");
        }



        // animation for list items's span
        if ($(".list-items").hasClass("hide")) {
            $(".list-items").removeClass("hide");
            $(".list-items").addClass("show");
        } else {
            $(".list-items").addClass("hide");
            $(".list-items").removeClass("show");
        }
        //  right 10% for down Icon
        $(".downIcon").toggleClass("hide");
        // Hide progress bar's percent
        $(".percent").toggleClass("hide");
        //   Hide brand
        $(".board").toggleClass("hide");
        $(".logo span").toggleClass("font");
    })
    // Nav Top Drop Menu
    $(".navLeft-items").click(function () {
        if ($(this).next().hasClass("dropDown")) {
            $(this).next().slideToggle();
        }
    })

    $(".navRight-items").click(function () {
        if ($(this).next().hasClass("dropDown")) {
            $(this).next().slideToggle();
        }
    })
    // Project Fedd Drop Donwn
    $("#feed .feeds .row").click(function () {
        $(this).last().next().slideToggle();
    })
    // Create Project Feed
    $(".plus").click(function () {
        $("#project").toggleClass("project");
    })

    // Change Color of project input
    $("#project .form-control").click(function () {
        $(this).addClass("active");
    })
    $(document).click(function (e) {
        if (e.target.tagName != "INPUT") {
            $("#project .form-control").removeClass("active");
        }
    })
    // project feed drop down
    $(".openFile").click(function () {
        $(".openFile").toggleClass("active");
        $(".filesDropDown").slideToggle();
    })
    // colors scale
    $(".colors div").click(function () {
        $(".colors div").removeClass("active");
        $(this).toggleClass("active");
    })
    // range input insert percent to text
    $(".range input").mouseup(function () {
        var percent = $(".range input").val();
        $(".range p").text(percent + "%");
    })
    //    close create feed
    $("#project .close").click(function () {

        $("#project").css("animation-name", "feed");
        setTimeout(function () {
            $("#project").removeClass("project");
            $("#project").css("animation-name", "project");
        }, 300)
    })
    //    change active class about SALES STATICS

    $("#statics .time span").click(function () {
        $("#statics .time span").removeClass("active");
        $(this).addClass("active");
    });



    var checkBoxes = document.querySelectorAll("#tasks .checkbox");
    for (var checkBox of checkBoxes) {
        //    there is checked attribute or not
        if (checkBox.hasAttribute("checked")) {
            checkBox.nextElementSibling.style.textDecoration = "line-through";
        }
        checkBox.addEventListener("click", function () {
            if (this.hasAttribute("checked")) {
                this.removeAttribute("checked");
                this.nextElementSibling.style.textDecoration = "none";
            } else {
                this.setAttribute("checked", "");
                this.nextElementSibling.style.textDecoration = "line-through";
            }
        })
    }
    // task list drop down
    var iconsDown = document.querySelectorAll("#tasks .downIcon");
    for (iconDown of iconsDown) {
        iconDown.addEventListener("click", function () {
            var dropTask = this.parentElement.nextElementSibling;
            if (dropTask.style.display == "none") {
                dropTask.style.display = "block"
            } else {
                dropTask.style.display = "none"
            }
        })
    }

    // TOOLTIP


    // tooltip input
    $(".tooltipPage input").mouseover(function () {
        $(".tooltip-input").addClass("active");
    });

    $(".tooltipPage input").mouseout(function () {
        $(".tooltip-input").removeClass("active");
    });

    // tooltip button
    $(".tooltipPage button").mouseover(function () {
        $(".tooltip-button").addClass("active");
    });

    $(".tooltipPage button").mouseout(function () {
        $(".tooltip-button").removeClass("active");
    });

    // tooltip checkbox
    $(".tooltipPage label").mouseover(function () {
        $(".tooltip-label").addClass("active");
    });

    $(".tooltipPage label").mouseout(function () {
        $(".tooltip-label").removeClass("active");
    });



    // Tooltips top,right,left,bottom
    $(".placementTooltip .top").mouseover(function () {
        $(".tooltip-top").addClass("active");
    });

    $(".placementTooltip .top").mouseout(function () {
        $(".tooltip-top").removeClass("active");
    });

    $(".placementTooltip .bottom").mouseover(function () {
        $(".tooltip-bottom").addClass("active");
    });

    $(".placementTooltip .bottom").mouseout(function () {
        $(".tooltip-bottom").removeClass("active");
    });

    $(".placementTooltip .left").mouseover(function () {
        $(".tooltip-left").addClass("active");
    });

    $(".placementTooltip .left").mouseout(function () {
        $(".tooltip-left").removeClass("active");
    });

    $(".placementTooltip .right").mouseover(function () {
        $(".tooltip-right").addClass("active");
    });

    $(".placementTooltip .right").mouseout(function () {
        $(".tooltip-right").removeClass("active");
    });

    // POPOVER
    $(".popoverPage .btn").click(function () {
        $(".popoverPage .popover").toggleClass("active");
    })


    $(".placementPopover .top").click(function () {
        $(".popover-top").toggleClass("active");
    })
    $(".placementPopover .bottom").click(function () {
        $(".popover-bottom").toggleClass("active");
    })
    $(".placementPopover .left").click(function () {
        $(".popover-left").toggleClass("active");
    })
    $(".placementPopover .right").click(function () {
        $(".popover-right").toggleClass("active");
    })


    $(".placementPopover .default").click(function () {
        $(".popover-default").toggleClass("active");
    })
    $(".placementPopover .dismisible").click(function () {
        $(".popover-dismisible").addClass("active");
    })


    // Modals
    $(".modalLg").click(function () {
        $("#large-modal").fadeIn();
        setTimeout(function () {
            $("#large-modal .modal-dialog").animate({
                top: "40px"
            });
        }, 100);

    })

    $(".modalMd").click(function () {
        $("#default-modal").fadeIn();
        setTimeout(function () {
            $("#default-modal .modal-dialog").animate({
                top: "40px"
            });
        }, 100);

    })

    $(".modalSm").click(function () {
        $("#small-modal").fadeIn();
        setTimeout(function () {
            $("#small-modal .modal-dialog").animate({
                top: "40px"
            });
        }, 100);

    })

    $(".fixModal .modal-dialog .close").click(function () {
        $(".fixModal .modal-dialog").animate({
            top: "-40px",
        })
        setTimeout(function () {
            $(".fixModal").fadeOut();
        }, 100);
    })

    $(".fixModal .modal-dialog .closeButton").click(function () {
        $(".fixModal .modal-dialog").animate({
            top: "-40px",
        })
        setTimeout(function () {
            $(".fixModal").fadeOut();
        }, 100);
    })

    //    Button Page DropDown
    $("button.dropdown-toggle").click(function () {
        $(this).next().fadeToggle();
    })
})