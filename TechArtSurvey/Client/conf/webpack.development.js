import webpack from 'webpack';
import Config from 'webpack-config';

import OpenBrowserPlugin from 'open-browser-webpack-plugin';
import StyleLintPlugin from 'stylelint-webpack-plugin';

import {
  apiPath,
  devServerPath,
} from './paths';

export default new Config()
  .extend('conf/webpack.common.js')
  .merge({
    devtool : 'source-map',

    devServer : {
      hot: true,
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
      new StyleLintPlugin(),
      new OpenBrowserPlugin({
        url : devServerPath,
      }),
      new webpack.LoaderOptionsPlugin({
        options : {
          eslint : {
            failOnWarning : false,
            failOnError : true,
            fix : false,
          },
        },
      }),
      new webpack.DefinePlugin({
        'process.env': {
          NODE_ENV : JSON.stringify('development'),
        },
      }),
    ],
  });
