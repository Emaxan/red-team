const Config = require('webpack-config');

const webpack = require('webpack');

const { outputPath } = require('./paths');

module.exports = new Config.Config()
  .extend('conf/webpack.common.js')
  .merge({
    output : {
      path : outputPath,
    },
    plugins : [
      new webpack.optimize.OccurrenceOrderPlugin(true),
      new webpack.optimize.UglifyJsPlugin({
        mangle : true,
        output : {
          comments : false,
        },
        compress : {
          warnings : false,
        },
      }),
    ],
  });
