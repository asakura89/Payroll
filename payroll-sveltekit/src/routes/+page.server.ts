import { redirect } from "@sveltejs/kit";
import type { PageServerLoad } from "./$types";

export const load: PageServerLoad =async (params: object) => {
    throw redirect(302, "/home/login");
}

export const prerender = false;
export const ssr = true;
export const csr = false;