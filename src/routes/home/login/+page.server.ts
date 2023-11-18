import type { PageServerLoad } from './$types';

export const load = (async () => {
    return {
        title: "Login"
    };
}) satisfies PageServerLoad;

export const prerender = true;
export const ssr = true;
export const csr = true;