import fs from "fs"
import path from "path"

export namespace Project {
    var cachedProjectDir: string = "";
    export function GetProjectDirectory(): string {
        if (cachedProjectDir != "")
            return cachedProjectDir;

        // Go up recursively until we find OSW_PROJECT_ROOT
        var found: boolean = false;
        var currentPath: string = __dirname;
        while (!found) {
            found = fs.existsSync(currentPath + "/OSW_PROJECT_ROOT");
            if (!found) {
                currentPath = path.resolve(currentPath + "/../");
                if (currentPath == "/") {
                    throw "Couldn't find OSW_PROJECT_ROOT in parent directories of this script. "
                }
            }
        }
        cachedProjectDir = currentPath;
        return currentPath;
    }
}