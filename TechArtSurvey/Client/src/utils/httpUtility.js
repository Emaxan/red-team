import { isString } from 'lodash';

import {
  OK,
  BAD_REQUEST,
} from 'http-status';

async function prepareResponse (responseInfo) {
  const statusCode = responseInfo.status;
  const data = await responseInfo.json();

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
      headers,
      body : data,
    });

    return await prepareResponse(responseInfo);
  },

  get : async (url, headers) => {
    const responseInfo = await fetch(url, {
      method : 'GET',
      headers,
    });

    return await prepareResponse(responseInfo);
  },
};
