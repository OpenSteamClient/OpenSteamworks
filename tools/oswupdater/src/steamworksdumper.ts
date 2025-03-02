import fs from "fs"
import { downloadAndSaveAsync, execWrap, mkdir } from "./util";

export class SteamworksDumper {
    constructor() {
       
    }
    isSetup(): boolean {
        return fs.existsSync("SteamworksDumper.Standalone");
    }
    async dump(clientpath: string, outpath: string): Promise<void> {
        if (!this.isSetup()) {
            throw "SteamworksDumper not setup";
        }
        
        if (outpath.length == 0) {
            throw "outpath cannot be empty";
        }
        if (clientpath.length == 0) {
            throw "clientpath cannot be empty"
        }

        mkdir(clientpath, true);
        try {
            await execWrap(`SteamworksDumper.Standalone "${clientpath}" "${outpath}"`, {});
        } catch (error) {
            throw "Failed to execute binary: " + error;
        } finally {
            return;
        }
    }
    async setup(): Promise<void> {
        if (fs.existsSync("SteamworksDumper.Standalone")) {
            fs.rmSync("SteamworksDumper.Standalone")
        }
        
        console.info("Downloading SteamworksDumper.Standalone")
        try {
            await downloadAndSaveAsync("https://github.com/OpenSteamClient/SteamworksDumper/releases/latest/download/SteamworksDumper.Standalone", "SteamworksDumper.Standalone");
            await execWrap("chmod +x SteamworksDumper.Standalone", {});
        } catch (e) {
            throw "Failed to download SteamworksDumper.Standalone " + e;
        } finally {
            console.log("Downloaded SteamworksDumper.Standalone successfully");
        }
    }
}