var catVm = new Vue({
    el: "#catdetail",
    data: {
        name: "",
        subCategories : []
    },
    mounted() {
        var path = window.location.href;
        var id = parseInt(path.substring(path.lastIndexOf('/') + 1));
        var self = this;
        pq.ajax.get("categories/" + id, function (data) {
            self.subCategories = data.children.map(function (c) {
                return c.name;
            });
            self.name = data.name;
        });
    }
});