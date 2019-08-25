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

            pq.ajax.post("categories", data, function (data) {
                toastr.options = {
                    closeButton: true,
                    progressBar: false,
                    showMethod: 'slideDown',
                    timeOut: 4000
                };
                if (data) {
                    toastr.success("İşlem başarılı", 'Kayıt tamamlandı');
                }
                else {
                    toastr.error("Hatalı işlem", 'Kayıt başarısız');
                }
            });
        }
    }
});