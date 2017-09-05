import Config from 'webpack-config';

export default (env) => {
  process.env.NODE_ENV = env;
  return new Config().extend(`conf/webpack.${env}.js`)
};