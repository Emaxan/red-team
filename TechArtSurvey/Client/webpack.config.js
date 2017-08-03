const Config = require('webpack-config');

module.exports = (env = 'development') => {
  process.env.NODE_ENV = env;
  return new Config.Config()
    .extend(`conf/webpack.${env}.js`);
};
