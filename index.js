const http = require("http");
const fs = require("fs");
const path = require("path");

const mime = {
  ".html": "text/html; charset=utf-8",
  ".js": "application/javascript; charset=utf-8",
  ".wasm": "application/wasm",
  ".data": "application/octet-stream",
  ".json": "application/json; charset=utf-8",
  ".png": "image/png",
  ".ico": "image/x-icon",
  ".css": "text/css; charset=utf-8",
  ".webmanifest": "application/manifest+json; charset=utf-8",
};

http.createServer((req, res) => {
  const file = req.url === "/" ? "index.html" : req.url.slice(1);
  const filePath = path.join(__dirname, "docs", file);
  const ext = path.extname(filePath).toLowerCase();
  const type = mime[ext] || "application/octet-stream";

  fs.readFile(filePath, (err, data) => {
    if (err) {
      res.writeHead(404);
      return res.end("Not found");
    }
    res.writeHead(200, { "Content-Type": type });
    res.end(data);
  });
}).listen(3007);