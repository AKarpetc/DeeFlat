const {
    createProxyMiddleware
} = require('http-proxy-middleware');

module.exports = function (app) {
    app.use(
        '/admin',
        createProxyMiddleware({
            target: 'http://localhost:5002',
            changeOrigin: true,
            pathRewrite: {
                "^/admin": "",
            },
        })
    );
    app.use(
        '/dicthttp',
        createProxyMiddleware({
            target: 'http://localhost:5006',
            changeOrigin: true,
            pathRewrite: {
                "^/dicthttp": "",
            },
        }));
};
