var loginVm = new Vue({
    el: "#loginForm",
    data: {
        username: "",
        password: ""
    },
    methods: {
        send: function () {
            var data = {
                userName: this.username,
                password: this.password
            };
            pq.ajax.post("account/token", data, function (data) {
                sessionStorage.setItem("token", data);
            });
        }
    }
});