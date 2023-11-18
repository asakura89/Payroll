import prisma from "$lib/prisma";
import { hashString } from "./securityService";

export async function isUserValid (username: string, userpass: string) : Promise<boolean> {
    let hashedPwd: string = hashString(userpass);
    let m_User = await prisma.m_User.findMany({
        where: {
            Password: hashedPwd
        }
    });

    return (m_User.length > 0);
}

// export async function createSession (params:type) => {
    
// }

// export async function getUserFromSession (params:type) => {
    
// }