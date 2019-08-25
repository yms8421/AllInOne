var catvM = new Vue({
    el: "#categoryContainer",
    data: {
        name: "",
        description : ""
    },
    methods: {
        save: function() {
            var data = {
                name: this.name,
                description: this.description
            }
        }
    }
});