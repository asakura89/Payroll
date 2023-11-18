import { createHash } from "crypto";

export const hashString = (string2Hash: string): string => {
    return createHash("md5")
        .update(string2Hash)
        .digest("base64");
};