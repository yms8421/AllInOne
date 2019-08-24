var index = new Vue({
    el: "#indexMain",
    data: {
        number: 0
    },
    methods: {
        increase: function () {
            this.number++;
        },
        decrease: function () {
            this.number--;
        }
    }
});