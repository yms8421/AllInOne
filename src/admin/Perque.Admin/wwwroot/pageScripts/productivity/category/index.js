var listVM = new Vue({
    el: "#categoryList",
    data: {
        items : []
    },
    methods: {
        selectRow: function (category) {
            alert(category.id);
        }
    },
    mounted() {
        //bu instance yüklendiğinde
        var self = this;
        pq.ajax.get("categories", function (data) {
            self.items = data.map(function (i) {
                return {
                    id : i.id,
                    name: i.name,
                    subs: i.children.map(function (j) {
                        return j.name;
                    }).join(', ')
                }
            });
        });
    }
});