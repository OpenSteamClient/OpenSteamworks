import fs from 'fs';
import { ClientManifest } from '../manifest';
import { ClientInterface } from '../dump';
export class InterfaceConstsCpp {
    static CreateInterfaceConstsFileFromManifest(path: string, interfaces: ClientInterface[]): void {
        var functionNames: string[] = [];
        var interfaceIDs: string[] = [];
        var functionIDs: string[] = [];
        var functionFenceposts: string[] = [];

        for (let index = 0; index < interfaces.length; index++) {
            const iface = interfaces[index];
            var hasinterfaceid: boolean = false;
            for (let funcindex = 0; funcindex < iface.functions.length; funcindex++)
            {
                const func = iface.functions[funcindex];
                if (func.interfaceid != "0" && !hasinterfaceid) {
                    interfaceIDs.push(`   EIPCInterfaceID_${iface.name} = ${func.interfaceid},`);
                    hasinterfaceid = true;
                }
                
                var functionFullName = `${iface.name}_${func.name}_A${func.serializedargs.length}_R${func.serializedreturns.length}`;
                var existingLen = functionNames.filter((f) => f == functionFullName).length;
                functionNames.push(functionFullName);
                if (existingLen != 0) {
                    functionFullName += "_DUP_" + existingLen;
                }
                
                functionIDs.push(`   EIPCFunctionID_${functionFullName} = ${func.functionid},`);
                functionFenceposts.push(`   EIPCFencepost_${functionFullName} = ${func.fencepost},`);
            }
        }
        
        var fullText = "";
        fullText += "// DO NOT EDIT; AUTOGENERATED FILE BY OSWUPDATER\n"
        fullText += "#pragma once"
        fullText += "\n";
        fullText += "#include <stdint.h>\n";
        fullText += "\n";

        fullText += "enum EIPCInterfaceID : uint8_t\n"
        fullText += "{\n";
        interfaceIDs.forEach(line => {
            fullText += line + "\n";
        });
        fullText += "};\n"

        fullText += "enum EIPCFunctionID : uint32_t\n"
        fullText += "{\n";
        functionIDs.forEach(line => {
            fullText += line + "\n";
        });
        fullText += "};\n"

        fullText += "enum EIPCFencepost : uint32_t\n"
        fullText += "{\n";
        functionFenceposts.forEach(line => {
            fullText += line + "\n";
        });
        fullText += "};\n"

        fs.writeFileSync(path, fullText);
    }
}