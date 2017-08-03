const path = require('path');

const sourcePath = path.join(__dirname, '../src');
const outputPath = path.join(sourcePath, '/build');
const devServerPath = 'http://localhost:3000';
const apiPath = 'http://localhost:13695';

module.exports = {
  sourcePath,
  outputPath,
  devServerPath,
  apiPath,
};
