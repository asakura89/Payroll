import { redirect } from '@sveltejs/kit';
import type { Actions, PageServerLoad, RequestEvent } from './$types';

export const load = (async () => {
    console.log("home/login/+page.server.ts");

    // const user = await db.getUserFromSession(cookies.get('sessionid'));
    // return { user };

    return {
        title: "Login"
    };
}) satisfies PageServerLoad;

export const actions = {
    default: async (event: RequestEvent) => {
        console.log(event);

        const form = await event.request.formData();
        const username = form.get("username-textbox");
        const password = form.get("password-textbox");

        // const user = await db.getUser(email);
        // cookies.set('sessionid', await db.createSession(user));

        //return { success: true };
        throw redirect(302, "/dashboard");
    }
} satisfies Actions;

export const prerender = false;
export const ssr = true;
export const csr = true;


/*

RequestEvent

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
  route: { id: '/home/login' },
  setHeaders: [Function: setHeaders],
  url: URL {
    href: 'http://127.0.0.1:5173/home/login',
    origin: 'http://127.0.0.1:5173',
    protocol: 'http:',
    username: '',
    password: '',
    host: '127.0.0.1:5173',
    hostname: '127.0.0.1',
    port: '5173',
    pathname: '/home/login',
    search: '',
    searchParams: URLSearchParams {},
    hash: ''
  },
  isDataRequest: false,
  isSubRequest: false
}

*/