import type { RequestHandler } from './$types';
import { getStores } from '$app/stores';

export const GET: RequestHandler = async () => {
    return new Response();
};

export const POST: RequestHandler = async (request: object) => {
    return new Response();
};