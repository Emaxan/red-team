const Config = require('webpack-config');

const webpack = require('webpack');
const BabiliPlugin = require('babili-webpack-plugin');
var OptimizeCssAssetsPlugin = require('optimize-css-assets-webpack-plugin');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

const { outputPath, apiPath } = require('./paths');

module.exports = new Config.Config()
  .extend('conf/webpack.common.js')
  .merge({
    devServer : {
      hot : true,
      port : 3000,
      historyApiFallback : true,
      proxy : {
        '/api' : {
          target : apiPath,
        },
        '/token' : {
          target : apiPath,
        },
      },
    },
    output : {
      path : outputPath,
      publicPath : '/',
    },
    plugins : [
      new ExtractTextPlugin('bundle.css'),
      new OptimizeCssAssetsPlugin({
        cssProcessorOptions: { discardComments: {removeAll: true } },
      }),
      new webpack.DefinePlugin({
        'process.env': {
          NODE_ENV: JSON.stringify('production'),
        },
      }),
      new BabiliPlugin(),
    ],
  });
