// Example console command parsing implementation.

#include "console.h"

#include <tier1/cvar.h>

void RunUserInput(const char* pszUserInput)
{
    Assert(ConCommandBase::s_pAccessor);

    CUtlString commandName;
    CCommand cmd(pszUserInput, commandName);

    auto cmdBase = CConCommandBaseAccessor::FindCommandBase(commandName);
    if (!cmdBase)
    {
        printf(">>> command not found: %s\n", commandName.String());
        return;
    }

    if (cmdBase->BIsCommand())
    {
        // Simple case, we have a command so execute it with the args we parsed earlier
        static_cast<const ConCommand*>(cmdBase)->Invoke(cmd);
        return;
    }

    auto cVar = static_cast<ConVar*>(cmdBase);

    if (cmd.Argc() > 0)
    {
        cVar->SetValue(cmd.Arg(1));
    }

    printf("\"%s\" = \"%s\"\n", commandName.String(), cVar->GetStringValue());
}

