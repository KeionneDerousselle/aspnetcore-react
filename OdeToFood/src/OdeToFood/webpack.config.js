var path = require('path');
var webpack = require('webpack');

module.exports = {
  entry: [
    'whatwg-fetch',
    './index'
  ],

  output: {
    path: path.join(__dirname, 'wwwroot'),
    filename: 'main.js',
    libraryTarget: 'commonjs2'
  },

  target: 'web',

  plugins: [
    new webpack.ProvidePlugin({
      $: 'jquery',
      jQuery: 'jquery',
      jquery: 'jquery',
      'window.jQuery': 'jquery',
      'window.jquery': 'jquery',
      'window.$': 'jquery',
    })
  ],

  module: {
    loaders: [
      {
        test: /\.jsx?$/,
        loaders: ['babel-loader'],
        exclude: /node_modules/
      },
      {
        test: /\.css$/,
        loaders: [
            'style-loader',
            'css-loader?sourceMap'
        ]
      },
      {
        test: /\*\.css$/,
        loaders: [
            'style-loader',
            'css-loader?modules&sourceMap&importLoaders=1&localIdentName=[name]__[local]___[hash:base64:5]'
        ]
      },
      {
        test: /\.(eot|woff|woff2|ttf|svg)$/,
        loader: 'file-loader'
      }
    ]
  },

  resolve: {
    extensions: ['.js', '.jsx'],
    //packageMains: ['webpack', 'browser', 'web', 'browserify', ['jam', 'main'], 'main']
  }
};