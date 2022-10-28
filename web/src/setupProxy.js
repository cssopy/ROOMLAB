const { createProxyMiddleware } = require("http-proxy-middleware");

module.exports = function (app) {
  app.use(
    createProxyMiddleware("/back", {
      // target: "http://localhost:8000",
      target: "https://k7d101.p.ssafy.io",
      pathRewrite: {
        "^/back": "",
      },
      changeOrigin: true,
    })
  );

  // app.use(
  //   createProxyMiddleware('/다른context', {
  //     target: 'https://다른호스트',
  //     pathRewrite: {
  //       '^/지우려는패스':''
  //     },
  //     changeOrigin: true
  //   })
  // )
};
