import { isString } from 'lodash';
import {
  OK,
  BAD_REQUEST,
  GATEWAY_TIMEOUT,
} from 'http-status';

import AuthService from '../auth/authService';

const prepareHeaders = (headers) => {
  return {
    ...headers,
    'Accept' : 'application/json',
    'Authorization' : `${AuthService.getTokenType()} ${AuthService.getToken()}`,
  };
};

async function prepareResponse (responseInfo) {
  const statusCode = responseInfo.status;
  let data;

  try {
    data = await responseInfo.json();
  } catch (error) {
    throw {
      statusCode : GATEWAY_TIMEOUT,
      data : [ 'Sorry, we have some technical issues. Try your request later' ],
    };
  }

  switch (responseInfo.status) {
  case OK:
    return {
      statusCode,
      data : isString(data) ? JSON.parse(data) : data,
    };

  case BAD_REQUEST:
    throw {
      statusCode,
      data : isString(data) ? JSON.parse(data) : data,
    };

  default:
    throw {
      statusCode,
      data : responseInfo.statusText,
    };
  }
}

export const httpUtility = {
  post : async (url, headers, data) => {
    const responseInfo = await fetch(url, {
      method : 'POST',
      headers : prepareHeaders(headers),
      body : isString(data) ? data : JSON.stringify(data),
    });

    return await prepareResponse(responseInfo);
  },

  get : async (url, headers) => {
    const responseInfo = await fetch(url, {
      method : 'GET',
      headers : prepareHeaders(headers),
    });

    return await prepareResponse(responseInfo);
  },
};

export const buildQueryStringByObject = (obj) => {
  return Object.keys(obj).map(key => `${encodeURIComponent(key)}=${encodeURIComponent(obj[key])}`).join('&');
};
