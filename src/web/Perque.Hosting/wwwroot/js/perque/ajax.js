(function (pq) {
    pq.ajax = pq.ajax || {};
    pq.ajax = {
        get: function (url, callback) {
            axiosInstance({
                method: 'get',
                url: url,
                responseType: 'application/json'
            }).then(function (response) {
                callback(response.data);
            });
        }
    };
    var axiosInstance = axios.create({
        baseURL: 'http://localhost:5000/api',
        timeout: 5000
    });
})(pq);