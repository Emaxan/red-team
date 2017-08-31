const Config = require('webpack-config');

const webpack = require('webpack');
const path = require('path');
const cssnano = require('cssnano');

const HtmlWebpackPlugin = require('html-webpack-plugin');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

const {
  sourcePath,
  devServerPath,
} = require('./paths');

module.exports = new Config.Config()
  .merge({
    context : path.join(__dirname, '../'),
    output : {
      filename : 'bundle.js',
      library : '[name]',
      publicPath : devServerPath + '/',
    },
    entry : {
      bundle : path.join(sourcePath, '/Root.jsx'),
    },
    resolve : {
      extensions : [ '.js', '.jsx', '.scss' ],
    },
    module : {
      rules : [
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
          test : /\.jsx?$/,
          exclude : /node_modules/,
          use : 'babel-loader',
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
