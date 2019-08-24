var leftMenu = new Vue({
    el: "#shop-categories",
    data: {
        title: "Kategoriler",
        categories: []
    },
    mounted() {
        var self = this;
        pq.ajax.get("categories", function (data) {
            self.categories = data;
            setTimeout(function () {
                $(".has-children .sub-menu-toggle").click(function (b) {
                    var c = this,
                        d = $(c).parent().parent().parent(),
                        e = $(c).parents(".menu");
                    return d.addClass("off-view"), $(c).parent().parent().find("> .offcanvas-submenu").addClass("in-view"), e.css("height", $(c).parent().parent().find("> .offcanvas-submenu").height()), b.preventDefault(), !1
                });

                $(".offcanvas-menu .offcanvas-submenu .back-btn").on("click", function (b) {
                    var c = this,
                        d = $(c).parent(),
                        e = $(c).parent().parent().siblings().parent(),
                        g = $(c).parents(".menu");
                    d.removeClass("in-view"), e.removeClass("off-view"), "menu" === e.attr("class") ? g.css("height", f) : g.css("height", e.height()), b.preventDefault()
                })
            }, 500);
            
        });
    }
});