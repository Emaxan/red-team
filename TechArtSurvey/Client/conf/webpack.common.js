import webpack from 'webpack';
import Config from 'webpack-config';
import cssnano from 'cssnano';
import path from 'path';

import HtmlWebpackPlugin from 'html-webpack-plugin';
import ExtractTextPlugin from 'extract-text-webpack-plugin';

import {
  sourcePath,
  devServerPath,
} from './paths';

export default new Config()
  .merge({
    entry : path.join(sourcePath, '/Root.jsx'),

    output : {
      publicPath : devServerPath + '/',
      filename : 'bundle.js',
    },

    context : path.resolve(__dirname, '../'),

    resolve : {
      extensions : [ '.js', '.jsx' ],
    },

    module : {
      rules : [
        {
          test : /\.jsx?$/,
          exclude : /node_modules/,
          loader : 'babel-loader',
        },
        {
          enforce : 'pre',
          test : /\.jsx?$|\.json$/,
          exclude : /node_modules/,
          loader : 'eslint-loader',
          options : {
            emmitError : true,
            fix : true,
          },
        },
        {
          test : /\.(scss|css)$/,
          use : [
            {
              loader : 'style-loader',
            },
            {
              loader : 'css-loader',
              options : { importLoaders: 1 },
            },
            {
              loader : 'sass-loader',
            }],
        },


        {
          test : /\.(svg|png|jpe?g|gif)$/,
          use : [{
            loader : 'url-loader',
            options : {
              limit : 8192,
            },
          }],
        },
        {
          test : /\.(eot|svg|ttf|woff|woff2)$/,
          use : [
            {
              loader : 'file-loader',
            }],
        },
        {
          test : /\.woff2?$|\.ttf$|\.eot$|\.svg$|\.png$|\.jpg$|\.gif$/,
          loader : 'file-loader',
        },
      ],
    },

    plugins : [
      new webpack.ProvidePlugin({
        $ : 'jquery',
        jQuery : 'jquery',
      }),
      new ExtractTextPlugin('bundle.css'),
      new webpack.NoEmitOnErrorsPlugin(),
      new webpack.HotModuleReplacementPlugin(),
      new HtmlWebpackPlugin({
        filename : 'index.html',
        inject : false,
        template : require('html-webpack-template'),
        appMountId : 'container',
        devServer : devServerPath,
        minify : {
          collapseWhitespace : true,
          preserveLineBreaks : true,
        },
        mobile : true,
        lang : 'en-US',
        title : `TechArt Survey${process.env.NODE_ENV === 'development' ? ' Dev' : ''}`,
      }),
      new webpack.LoaderOptionsPlugin({
        postcss : [
          cssnano({
            autoprefixer : {
              add : true,
              remove : true,
              browsers : ['last 2 versions'],
            },
            discardComments : {
              removeAll : true,
            },
            discardUnused : false,
            mergeIdents : false,
            reduceIdents : false,
            safe : true,
            sourcemap : true,
          }),
        ],
      }),
    ],
  });
