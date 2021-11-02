const {
    createProxyMiddleware
} = require('http-proxy-middleware');

module.exports = function (app) {
    app.use(
        '/api1',
        createProxyMiddleware({
            target: 'http://localhost:5002',
            changeOrigin: true,
            pathRewrite: {
              "^/api1": "",
            },
        })
    );
    app.use(
        '/api2',
        createProxyMiddleware({
            target: 'http://localhost:5011/',
            changeOrigin: true,
            pathRewrite: {
              "^/api2": "",
            },
        })
    );
};
