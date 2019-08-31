var indexVm = new Vue({
    el: "#index",
    data: {
        best: [],
        top: [],
        new: [],
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
            self.new = data;
        });

        pq.ajax.get("products/featured", function (data) {
            self.featured = data;
        });
    }
});