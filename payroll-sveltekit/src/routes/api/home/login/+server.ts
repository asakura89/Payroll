import type { RequestHandler } from '../../../home/login/$types';
import prisma from '$lib/prisma';
import * as crypto from "crypto";

export const POST: RequestHandler = async (request: object) => {
    console.log("api/home/login/+server.ts");
    console.log(request);
    return new Response();
};

// move to loginService.ts
async function isUserValid (username: string, userpass: string) : Promise<boolean> {
    let hashedPwd: string = hashString(userpass);
    let m_User = await prisma.m_User.findMany({
        where: {
            Password: hashedPwd
        }
    });

    return (m_User.length > 0);
}

// move to securityService.ts
function hashString(string2Hash: string): string {
    return crypto
        .createHash("md5")
        .update(string2Hash)
        .digest("base64");
};


/*

{
  cookies: {
    get: [Function: get],
    getAll: [Function: getAll],
    set: [Function: set],
    delete: [Function: delete],
    serialize: [Function: serialize]
  },
  fetch: [AsyncFunction (anonymous)],
  getClientAddress: [Function: getClientAddress],
  locals: {},
  params: {},
  platform: undefined,
  request: Request {
    [Symbol(realm)]: { settingsObject: [Object] },
    [Symbol(state)]: {
      method: 'POST',
      localURLsOnly: false,
      unsafeRequest: false,
      body: [Object],
      client: [Object],
      reservedClient: null,
      replacesClientId: '',
      window: 'client',
      keepalive: false,
      serviceWorkers: 'all',
      initiator: '',
      destination: '',
      priority: null,
      origin: 'client',
      policyContainer: 'client',
      referrer: 'client',
      referrerPolicy: '',
      mode: 'cors',
      useCORSPreflightFlag: true,
      credentials: 'same-origin',
      useCredentials: false,
      cache: 'default',
      redirect: 'follow',
      integrity: '',
      cryptoGraphicsNonceMetadata: '',
      parserMetadata: '',
      reloadNavigation: false,
      historyNavigation: false,
      userActivation: false,
      taintedOrigin: false,
      redirectCount: 0,
      responseTainting: 'basic',
      preventNoCacheCacheControlHeaderModification: false,
      done: false,
      timingAllowFailed: false,
      headersList: [HeadersList],
      urlList: [Array],
      url: [URL]
    },
    [Symbol(signal)]: AbortSignal { aborted: false },
    [Symbol(headers)]: HeadersList {
      cookies: null,
      [Symbol(headers map)]: [Map],
      [Symbol(headers map sorted)]: null
    }
  },
  route: { id: '/api/home/login' },
  setHeaders: [Function: setHeaders],
  url: URL {
    href: 'http://127.0.0.1:5173/api/home/login',
    origin: 'http://127.0.0.1:5173',
    protocol: 'http:',
    username: '',
    password: '',
    host: '127.0.0.1:5173',
    hostname: '127.0.0.1',
    port: '5173',
    pathname: '/api/home/login',
    search: '',
    searchParams: URLSearchParams {},
    hash: ''
  },
  isDataRequest: false,
  isSubRequest: false
}

*/