export const httpUtility = {
  post : async (url, headers, data) => {
    const responseInfo = await fetch(url, {
      method : 'POST',
      headers,
      body : JSON.stringify(data),
    });

    return {
      statusCode : responseInfo.status,
      data : await responseInfo.json(),
    };
  },

  get : async (url, headers) => {
    const responseInfo = await fetch(url, {
      method : 'GET',
      headers,
    });

    return {
      statusCode : responseInfo.status,
      data : await responseInfo.json(),
    };
  },
};
