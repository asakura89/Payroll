import { PrismaClient } from "@prisma/client";
import jsonData from "./seeddata.json" assert { type: "json" };

/*
-- 1: Admin, 2: Manager
INSERT INTO m_User VALUES
    ('admin', 'ISMvKXpXpadDiUoOSoAfww==', 1),
    ('manager', 'HQJYwkQKjRnnFikrIx4xkA==', 2)
*/

let prisma = new PrismaClient();

async function main() {
    console.log("Db seeding started . . .");

    for (let m_User of jsonData.m_Users) {
        let createdUser = await prisma.m_User.create({
            data: {
                Username: m_User.username,
                Password: m_User.password,
                Category: m_User.category
            }
        });

        console.log(`Created user with Username: ${createdUser.Username}`);
    }

    console.log("Db seeding finished . . .");
}

main()
    .then(async () => {
        await prisma.$disconnect();
    })
    .catch(async (ex) => {
        console.error(ex);
        await prisma.$disconnect();
        process.exit(1);
    });