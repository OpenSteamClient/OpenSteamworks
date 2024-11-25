#include <sstream>
#include <tier1/cvar.h>
#include <tier0/dbg.h>
#include <string>

ConCommandBase *ConCommandBase::s_pConCommandBases = nullptr;
IConCommandBaseAccessor	*ConCommandBase::s_pAccessor = nullptr;

bool CCommand::Tokenize(CUtlString &commandName)
{
    std::istringstream stream(m_fullCommand.String());

    std::string token;

    CUtlVector<CUtlString> tokens;

    while (stream >> std::ws) {
        char c = stream.peek();
        if (c == EOF)
        {
            break;
        } else if (c == '"' || c == '\'') {
            stream.get();
            std::getline(stream, token, c);
        } else {
            stream >> token;
        }

        tokens.AddToTail(token.c_str());
    }

    if (tokens.Count() == 0)
        return false;

    commandName.Set(tokens[0]);
    for (int i = 1; i < tokens.Count(); ++i)
    {
        printf("%s\n", tokens[i].String());
        m_args.AddToTail(tokens[i]);
    }

    return true;
}


ConCommandBase::~ConCommandBase()
{
}

bool ConCommandBase::IsFlagSet(uint flag) const
{
    return (static_cast<uint>(m_nFlags) & flag) != 0;
}

void ConCommandBase::AddFlags(uint flags)
{
    m_nFlags |= static_cast<uint64>(flags);
}

uint64 ConCommandBase::GetFlagsRaw() const
{
    return m_nFlags;
}

uint32 ConCommandBase::GetFlags() const
{
    return static_cast<uint32>(m_nFlags);
}

const char* ConCommandBase::GetName() const
{
    return m_pszName;
}

const char* ConCommandBase::GetHelpText() const
{
    return m_pszDescription;
}

bool ConCommandBase::BRegistered() const
{
    return m_bRegistered;
}

void ConCommandBase::Register()
{
    if (s_pAccessor != nullptr && this->m_bRegistered == false)
    {
        s_pAccessor->RegisterConCommandBase(this);
        this->m_bRegistered = true;
    }
}

void CConCommandBaseAccessor::LinkConCommand(ConCommandBase* pVar)
{
    pVar->SetNext(ConCommandBase::s_pConCommandBases);
    ConCommandBase::s_pConCommandBases = pVar;
}

const ConCommand* CConCommandBaseAccessor::FindConCommand(const char* pName)
{
    auto cmdBase = FindCommandBase(pName);
    if (!cmdBase)
        return nullptr;

    if (!cmdBase->BIsCommand())
    {
        fprintf(stderr, "Tried to look up variable %s as if it were a command.\n", pName);
        return nullptr;
    }

    return static_cast<const ConCommand*>(cmdBase);
}

ConVar* CConCommandBaseAccessor::FindConVar(const char* pName)
{
    auto cmdBase = FindCommandBase(pName);
    if (!cmdBase)
        return nullptr;

    if (cmdBase->BIsCommand())
    {
        fprintf(stderr, "Tried to look up command %s as if it were a variable.\n", pName);
        return nullptr;
    }

    return static_cast<ConVar*>(cmdBase);
}

ConCommandBase* CConCommandBaseAccessor::FindCommandBase(const char* pName)
{
    ConCommandBase* cur = ConCommandBase::s_pConCommandBases;
    while (cur != nullptr)
    {
        if (strcmp(cur->GetName(), pName) == 0)
            return cur;

        cur = cur->GetNext();
    }

    return nullptr;
}


bool CConCommandBaseAccessor::RegisterConCommandBase(ConCommandBase *pBase)
{
    if (pBase->BRegistered())
        return false;

    auto name = pBase->GetName();
    auto pBaseExisting = FindCommandBase(name);
    if (!pBaseExisting)
    {
        LinkConCommand(pBase);
        return true;
    }

    if (pBaseExisting->BIsCommand() || pBase->BIsCommand())
    {
        printf("WARNING: unable to link %s and %s because one or more is a ConCommand.\n", name, pBaseExisting->GetName());
        return false;
    }

    auto pExisting = reinterpret_cast<ConVar *>(pBaseExisting);
    auto pCVar = reinterpret_cast<ConVar *>(pBase);

    pCVar->SetParent(pExisting);

    return true;
}

ConCommandBase::ConCommandBase(const char *pszName, uint32 nFlags, const char *pszDescription)
{
    Assert(pszName);
    this->m_pszName = pszName;
    this->m_nFlags = nFlags;
    this->m_pszDescription = pszDescription;
}

bool ConCommand::BIsCommand() const
{
    return true;
}

int ConCommand::RunCompletion(const CCommand &args, CUtlVector<CUtlString> &results) const
{
    Assert(m_fnCompletionCallback);
    return m_fnCompletionCallback(args, results);
}

void ConCommand::SetCompletionCallback(FnCommandCompletionCallback_t pFnCompletionCallbackFunc)
{
    this->m_bHasCompletionCallback = true;
    this->m_fnCompletionCallback = pFnCompletionCallbackFunc;
}

bool ConCommand::BHasCompletionCallback() const
{
    return this->m_bHasCompletionCallback;
}

void ConCommand::Invoke(const CCommand& args) const
{
    if (this->m_pFnInvoke)
    {
        this->m_pFnInvoke(args);
        return;
    }

    Assert(0);
}

ConVar::~ConVar()
{
    m_currentValue.Clear();
    m_replicatedWaitingString.Clear();

    m_vecCallbacks.RemoveAll();

    m_decimalValue.Clear();
    m_utlString.Clear();
}

bool ConVar::BIsCommand() const
{
    return false;
}


bool ConVar::SetValue(const char* value)
{
    if (!this->m_bIsReplicatedAndSet && !m_pParent->IsFlagSet(FCVAR_REPLICATED))
    {
        m_pParent->InternalSetValue(value);
        return true;
    }

    fprintf(stderr, "Attempted to change replicated CVar when you are not the GM\n");
    return false;
}

bool ConVar::SetValue(float value)
{
    if (!this->m_bIsReplicatedAndSet && !m_pParent->IsFlagSet(FCVAR_REPLICATED))
    {
        m_pParent->InternalSetValue(value);
        return true;
    }

    fprintf(stderr, "Attempted to change replicated CVar when you are not the GM\n");
    return false;
}

bool ConVar::SetValue(int value)
{
    if (!this->m_bIsReplicatedAndSet && !m_pParent->IsFlagSet(FCVAR_REPLICATED))
    {
        m_pParent->InternalSetValue(value);
        return true;
    }

    fprintf(stderr, "Attempted to change replicated CVar when you are not the GM\n");
    return false;
}

bool ConVar::SetValue(int64 value)
{
    if (!this->m_bIsReplicatedAndSet && !m_pParent->IsFlagSet(FCVAR_REPLICATED))
    {
        m_pParent->InternalSetValue(value);
        return true;
    }

    fprintf(stderr, "Attempted to change replicated CVar when you are not the GM\n");
    return false;
}

bool ConVar::SetValue(uint64 value)
{
    if (!this->m_bIsReplicatedAndSet && !m_pParent->IsFlagSet(FCVAR_REPLICATED))
    {
        m_pParent->InternalSetValue(value);
        return true;
    }

    fprintf(stderr, "Attempted to change replicated CVar when you are not the GM\n");
    return false;
}

bool ConVar::SetValue(double value)
{
    if (!this->m_bIsReplicatedAndSet && !m_pParent->IsFlagSet(FCVAR_REPLICATED))
    {
        m_pParent->InternalSetValue(value);
        return true;
    }

    fprintf(stderr, "Attempted to change replicated CVar when you are not the GM\n");
    return false;
}

void ConVar::Unk1()
{
    Assert(false);
}

void ConVar::Validate(CValidator&)
{
    Assert(false);
}

bool ConVar::BIsDefaultValue()
{
    return this->m_bIsDefaultValue;
}

void ConVar::SetIsDefaultValue()
{
    this->m_bIsDefaultValue = true;
}

void ConVar::SetIsNotDefaultValue()
{
    this->m_bIsDefaultValue = false;
}

bool ConVar::BIsReplicatedValueSet()
{
    return this->m_bIsReplicatedSet;
}

bool ConVar::BGetUnk3()
{
    return this->m_bUnkBool3;
}

void ConVar::SetUnk3_True()
{
    this->m_bUnkBool3 = true;
}

void ConVar::SetUnk3_False()
{
    this->m_bUnkBool3 = false;
}

void ConVar::SetReplicatedWaitingValue(const char* pszString, bool bSetValue, bool bIsNotDefault)
{
    if (!this->m_bIsReplicatedSet && bSetValue)
    {
        this->m_bIsReplicatedSet = false;
        this->InternalSetValue(pszString);

        if (bIsNotDefault)
        {
            SetIsNotDefaultValue();
        } else
        {
            SetIsDefaultValue();
        }
    }

    int len = strlen(pszString);
    len += 1;
    if (this->m_iReplicatedWaitingStringLength < len)
    {
        this->m_iReplicatedWaitingStringLength = len;
    }

    m_replicatedWaitingString.SetDirect(pszString, len - 1);
}

void ConVar::SetUnkUtlStr(const char* pszString)
{
    this->InternalSetValue(pszString);
    this->m_utlString.SetValue(pszString);
    this->m_bUtlStringSet = true;
}

void ConVar::InternalSetValue(const char* pszString)
{
    Assert(m_pParent == this);
    AssertMsg(pszString, "ConVar::InternalSetValue: called with NULL");

    if (*pszString == '=')
    {
        printf("\nHey, you just set %s\'s number values to be 0. Is that what you wanted?\n\nIf you do `%s = 123`, you will set the convar to `= 123` which becomes `0` for numeric uses.\nDid you mean to do `%s %s` instead?\n", GetName(), GetName(), GetName(), pszString);
    }

    double dVal = strtod(pszString, nullptr);
    float fVal = static_cast<float>(dVal);

    const char *valStr = pszString;

    char szVal[64];
    if (ClampValue(fVal))
    {
        V_snprintf(szVal, sizeof(szVal), "%f", fVal);

        // This is technically not compliant with how ValveSteam does it, as they only set iVal and llVal with downcasting from fVal,
        // This does make more sense, though.
        dVal = static_cast<double>(fVal);
        valStr = szVal;
    }

    int64 llVal = strtol(valStr, nullptr, 10);
    uint64 ullVal = std::stoull(valStr);

    this->m_dblValue = dVal;
    this->m_flValue = fVal;
    this->m_iValue = llVal;
    this->m_llValue = llVal;
    this->m_ullValue = ullVal;

    //TODO: This is where the array stuff would go

    if (!IsFlagSet(FCVAR_NEVER_AS_STRING))
    {
        ChangeStringValue(pszString);
    }

    this->m_bIsDefaultValue = false;
}

void ConVar::InternalSetValue(float flValue)
{
    Assert(m_pParent == this);
    ClampValue(flValue);

    this->m_dblValue = flValue;
    this->m_flValue = flValue;
    this->m_iValue = flValue;
    this->m_llValue = flValue;
    this->m_ullValue = flValue;

    if (!IsFlagSet(FCVAR_NEVER_AS_STRING))
    {
        char szVal[64];
        V_snprintf(szVal, sizeof(szVal), "%f", flValue);
        ChangeStringValue(szVal);
    } else
    {
        Assert(m_vecCallbacks.Count() == 0);
    }

    this->m_bIsDefaultValue = false;
}

void ConVar::InternalSetValue(int iValue)
{
    Assert(m_pParent == this);

    float flValue = iValue;
    if (ClampValue(flValue))
    {
        iValue = static_cast<int>(flValue);
    }

    this->m_dblValue = iValue;
    this->m_flValue = flValue;
    this->m_iValue = iValue;
    this->m_llValue = iValue;
    this->m_ullValue = iValue;

    if (!IsFlagSet(FCVAR_NEVER_AS_STRING))
    {
        char szVal[32];
        V_snprintf(szVal, sizeof(szVal), "%d", iValue);
        ChangeStringValue(szVal);
    } else
    {
        Assert(m_vecCallbacks.Count() == 0);
    }

    this->m_bIsDefaultValue = false;
}

void ConVar::InternalSetValue(int64 llValue)
{
    Assert(m_pParent == this);

    float flValue = llValue;
    if (ClampValue(flValue))
    {
        llValue = static_cast<int64>(flValue);
    }

    this->m_dblValue = llValue;
    this->m_flValue = flValue;
    this->m_iValue = llValue;
    this->m_llValue = llValue;
    this->m_ullValue = llValue;

    if (!IsFlagSet(FCVAR_NEVER_AS_STRING))
    {
        char szVal[32];
        V_snprintf(szVal, sizeof(szVal), "%lld", llValue);
        ChangeStringValue(szVal);
    } else
    {
        Assert(m_vecCallbacks.Count() == 0);
    }

    this->m_bIsDefaultValue = false;
}

void ConVar::InternalSetValue(uint64 ullValue)
{
    Assert(m_pParent == this);

    float flValue = ullValue;
    if (ClampValue(flValue))
    {
        ullValue = static_cast<uint64>(flValue);
    }

    this->m_dblValue = ullValue;
    this->m_flValue = flValue;
    this->m_iValue = ullValue;
    this->m_llValue = ullValue;
    this->m_ullValue = ullValue;

    if (!IsFlagSet(FCVAR_NEVER_AS_STRING))
    {
        char szVal[32];
        V_snprintf(szVal, sizeof(szVal), "%llu", ullValue);
        ChangeStringValue(szVal);
    } else
    {
        Assert(m_vecCallbacks.Count() == 0);
    }

    this->m_bIsDefaultValue = false;
}

void ConVar::InternalSetValue(double dValue)
{
    Assert(m_pParent == this);

    float flValue = dValue;
    if (ClampValue(flValue))
    {
        dValue = static_cast<double>(flValue);
    }

    this->m_dblValue = dValue;
    this->m_flValue = flValue;
    this->m_iValue = dValue;
    this->m_llValue = dValue;
    this->m_ullValue = dValue;

    if (!IsFlagSet(FCVAR_NEVER_AS_STRING))
    {
        char szVal[360];
        V_snprintf(szVal, sizeof(szVal), "%lf", dValue);
        ChangeStringValue(szVal);
    } else
    {
        Assert(m_vecCallbacks.Count() == 0);
    }

    this->m_bIsDefaultValue = false;
}

bool ConVar::ClampValue(float& flValue)
{
    if (m_bHasMin && (flValue < m_fMinVal))
    {
        flValue = m_fMinVal;
        return true;
    }

    if (m_bHasMax && (flValue > m_fMaxVal))
    {
        flValue = m_fMaxVal;
        return true;
    }

    return false;
}

void ConVar::ChangeStringValue(const char* pszString)
{
    Assert( !( m_nFlags & FCVAR_NEVER_AS_STRING ) );

    m_currentValue.SetValue(pszString);

    for (auto callback : m_vecCallbacks)
    {
        callback(this, pszString);
    }
}

void ConVar::InstallChangeCallback(FnChangeCallback_t callback)
{
    if (!callback)
        return;

    // This also isn't compliant.

    m_vecCallbacks.AddToTail(callback);
    callback(this, GetStringValue());
}

void ConVar::RemoveChangeCallback(FnChangeCallback_t callback)
{
    if (!callback)
        return;

    m_vecCallbacks.FindAndRemove(callback);
}

ConVar::ConVar(const char* pName, const char* pDefaultValue, uint32 flags, const char* pHelpString, bool bHasMax, float maxValue, bool bHasMin, float minValue, FnChangeCallback_t changeCallback):
    ConCommandBase(pName, flags, pHelpString)
{
    Assert(pDefaultValue);

    this->m_pParent = this;
    this->m_bIsDefaultValue = true;
    this->m_bIsReplicatedAndSet = false;
    this->m_bIsReplicatedSet = false;
    this->m_bUnkBool3 = false;
    this->m_bUtlStringSet = false;

    ConVar::SetValue(pDefaultValue);

    this->m_bHasMin = bHasMin;
    this->m_bHasMax = bHasMax;
    this->m_fMinVal = minValue;
    this->m_fMaxVal = maxValue;

    // Make sure this flag is set after setting the value
    this->m_bIsDefaultValue = true;

    // Register.
    ConCommandBase::Register();

    InstallChangeCallback(changeCallback);
}

ConVar::ConVar(const char* pName, const char* pDefaultValue, uint32 flags, const char* pHelpString, float maxValue, float minValue, FnChangeCallback_t changeCallback)
    : ConVar(pName, pDefaultValue, flags, pHelpString, maxValue != 0, maxValue, minValue != 0, minValue, changeCallback)
{
}

ConVar::ConVar(const char* pName, const char* pDefaultValue, uint32 flags, const char* pHelpString, FnChangeCallback_t changeCallback)
    : ConVar(pName, pDefaultValue, flags, pHelpString, false, 0, false, 0, changeCallback)
{
}

ConVar::ConVar(const char* pName, const char* pDefaultValue, uint32 flags, FnChangeCallback_t changeCallback)
    : ConVar(pName, pDefaultValue, flags, "", false, 0, false, 0, changeCallback)
{
}

ConVar::ConVar(const char* pName, const char* pDefaultValue, FnChangeCallback_t changeCallback)
    : ConVar(pName, pDefaultValue, 0, changeCallback)
{
}

ConVar::ConVar(const char* pName, const char* pDefaultValue, const char* pHelpString)
    : ConVar(pName, pDefaultValue, 0, pHelpString, nullptr)
{
}

ConVar::ConVar(const char* pName, FnChangeCallback_t changeCallback)
    : ConVar(pName, "", 0, changeCallback)
{
}

ConCommand::ConCommand(const char* pszName, uint32 nFlags, const char* pszDescription, FnCommandCallback_t fnCallback, FnCommandCompletionCallback_t fnCompletionCallback):
    ConCommandBase(pszName, nFlags, pszDescription)
{
    this->m_pFnInvoke = fnCallback;

    if (fnCompletionCallback != nullptr)
        ConCommand::SetCompletionCallback(fnCompletionCallback);

    ConCommand::Register();
}

ConCommand::ConCommand(const char* pszName, uint32 nFlags, const char* pszDescription, FnCommandCallback_t fnCallback)
    : ConCommand(pszName, nFlags, pszDescription, fnCallback, nullptr)
{
}

ConCommand::ConCommand(const char* pszName, uint32 nFlags, FnCommandCallback_t fnCallback)
    : ConCommand(pszName, nFlags, "", fnCallback)
{
}

ConCommand::ConCommand(const char* pszName, FnCommandCallback_t fnCallback)
    : ConCommand(pszName, 0, fnCallback)
{
}

