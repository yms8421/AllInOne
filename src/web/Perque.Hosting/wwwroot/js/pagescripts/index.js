var indexVm = new Vue({
    el: "#index",
    data: {
        best: [],
        top: [],
        news: [],
        featured : []
    },
    mounted() {
        var self = this;
        pq.ajax.get("products/best", function (data) {
            self.best = data;
        });

        pq.ajax.get("products/top", function (data) {
            self.top = data;
        });

        pq.ajax.get("products/new", function (data) {
            self.news = data;
        });

        pq.ajax.get("products/featured", function (data) {
            self.featured = data;

            //sayfadaki carousel için gerekli
            setTimeout(function () {
                $('.owl-carousel').owlCarousel({
                    loop: true,
                    margin: 10,
                    nav: true,
                    responsive: {
                        0: {
                            items: 4
                        }
                    }
                })
            }, 100);
        });
    }
});