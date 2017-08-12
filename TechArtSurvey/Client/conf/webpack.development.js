const Config = require('webpack-config');

const webpack = require('webpack');

const OpenBrowserPlugin = require('open-browser-webpack-plugin');
const StyleLintPlugin = require('stylelint-webpack-plugin');

const {
  apiPath,
  devServerPath,
} = require('./paths');

module.exports = new Config.Config()
  .extend('conf/webpack.common.js')
  .merge({
    devtool : 'source-map',
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
    plugins : [
      new webpack.DefinePlugin({
        'process.env': {
          NODE_ENV: JSON.stringify('development'),
        },
      }),
      new StyleLintPlugin(),
      new OpenBrowserPlugin({ url : devServerPath }),
      new webpack.LoaderOptionsPlugin({
        options : {
          eslint : {
            // Fail only on errors
            failOnWarning : false,
            failOnError : true,

            // Toggle autofix
            fix : false,
          },
        },
      }),
    ],
  });
