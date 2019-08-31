var catvM = new Vue({
    el: "#categoryContainer",
    data: {
        name: "",
        subName: "",
        subCategories: []
    },
    methods: {
        save: function () {
            var data = {
                id : 0, //şart değil
                name: this.name,
                subCategories: this.subCategories.map(function (s) {
                    return { name: s, id: 0 }; //id şart değil çünkü olmayan veriler api tarafında default değere atanır
                })
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
        },
        addSub: function () {
            this.subCategories.push(this.subName);
            this.subName = "";
        },
        removeSub: function (c) {
            //pq.js'ye bakınız
            this.subCategories = this.subCategories.remove(c);
        }
    },
});


Array.prototype.remove = function (item) {
    var index = this.indexOf(item);
    var array = [];
    for (var i = 0; i < this.length; i++) {
        if (i != index) {
            array.push(this[i]);
        }
    }
    return array;
}