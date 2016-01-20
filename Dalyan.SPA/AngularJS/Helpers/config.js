var config = {
    apiurl: "http://localhost:1001/Dalyan.WebApi/",
    weburl: "http://localhost:1001/Dalyan.SPA/",

    generateApiUrl: function (serviceUrl) {
        return config.apiurl + serviceUrl;
    }
}