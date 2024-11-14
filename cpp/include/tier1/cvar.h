#pragma once
#include <tier0/basetypes.h>
#include <tier1/utlvector.h>
#include <tier1/utlstring.h>
#include <tier1/utlbuffer.h>

class CValidator;
class ConCommandBase;
class ConVar;
class ConCommand;

enum ConCommandFlags_t : uint32
{
    FCVAR_NEVER_AS_STRING = (1 << 0),
    FCVAR_UNK1 = (1 << 1),
    FCVAR_REPLICATED = (1 << 2),
    FCVAR_UNK2 = (1 << 3),
    FCVAR_UNK3 = (1 << 4)
};

class IConCommandBaseAccessor
{
public:
    virtual bool RegisterConCommandBase( ConCommandBase *pVar ) = 0;
};

class CConCommandBaseAccessor : public IConCommandBaseAccessor
{
public:
    [[nodiscard]] static ConVar *FindConVar(const char *pName);
    [[nodiscard]] static const ConCommand *FindConCommand(const char *pName);

    static void LinkConCommand(ConCommandBase *pVar);
    [[nodiscard]] static ConCommandBase *FindCommandBase( const char *pName );
    bool RegisterConCommandBase( ConCommandBase *pVar ) override;
};


// A list of command arguments for ConCommand purposes.
class CCommand
{
private:
    CUtlString m_fullCommand;
    CUtlVector<CUtlString> m_args;

public:
    ~CCommand()
    {
        m_args.Purge();
        m_fullCommand.Clear();
    }

    bool Tokenize(CUtlString& commandName);

    explicit CCommand(const char *fullCommand, CUtlString &commandNameOut) : m_fullCommand(fullCommand)
    {
        Tokenize(commandNameOut);
    }

    [[nodiscard]] int Argc() const
    {
        return m_args.Count();
    }

    // Get an argument from the list. Starts counting at 1.
    [[nodiscard]] const char *Arg(int iArgIdx) const
    {
        return m_args.Element(iArgIdx - 1).String();
    }

    [[nodiscard]] const char *FullCommand() const
    {
        return m_fullCommand.String();
    }
};

typedef void (*FnCommandCallback_t)(const CCommand&);

//TODO: These are not 100% known
typedef int  (*FnCommandCompletionCallback_t)(const CCommand&, CUtlVector<CUtlString> &commands);
typedef void (*FnChangeCallback_t)(ConVar *cVar, const char *pszCurrentValue);

class ConCommandBase
{
public:
    static ConCommandBase* s_pConCommandBases;
    static IConCommandBaseAccessor* s_pAccessor;
    
protected:
    ConCommandBase *m_pNext = nullptr;
    bool m_bRegistered = false;
    const char *m_pszName;
    const char *m_pszDescription;
    uint64 m_nFlags;
protected:
    ConCommandBase(const char *pszName, uint32 nFlags, const char *pszDescription);

public:
    // Internal use only! Get the next ConCommandBase in the global list.
    [[nodiscard]] ConCommandBase *GetNext() const
    {
        return m_pNext;
    }

    // Internal use only! Set the next ConCommandBase in the global list.
    void SetNext(ConCommandBase *pNext)
    {
        m_pNext = pNext;
    }

public:
    virtual ~ConCommandBase();
    [[nodiscard]] virtual bool BIsCommand() const = 0;
    [[nodiscard]] virtual bool IsFlagSet(uint flag) const;
    virtual void AddFlags(uint flags);
    [[nodiscard]] virtual uint64 GetFlagsRaw() const;
    [[nodiscard]] virtual uint32 GetFlags() const;
    [[nodiscard]] virtual const char *GetName() const;
    [[nodiscard]] virtual const char *GetHelpText() const;
    [[nodiscard]] virtual bool BRegistered() const;
    virtual void Register();
};

class ConCommand : public ConCommandBase
{
private:
    FnCommandCallback_t m_pFnInvoke = nullptr;
    int unk1{};
    FnCommandCompletionCallback_t m_fnCompletionCallback = nullptr;
    bool m_bHasCompletionCallback = false;

public:
    ConCommand(const char *pszName, uint32 nFlags, const char *pszDescription, FnCommandCallback_t fnCallback, FnCommandCompletionCallback_t fnCompletionCallback);
    ConCommand(const char *pszName, uint32 nFlags, const char *pszDescription, FnCommandCallback_t fnCallback);
    ConCommand(const char *pszName, uint32 nFlags, FnCommandCallback_t fnCallback);
    ConCommand(const char *pszName, FnCommandCallback_t fnCallback);

public:
    [[nodiscard]] bool BIsCommand() const override;

    virtual int RunCompletion(const CCommand &args, CUtlVector<CUtlString> &commands) const;
    virtual void SetCompletionCallback(FnCommandCompletionCallback_t pFnCompletionCallbackFunc);
    virtual bool BHasCompletionCallback() const;
    virtual void Invoke(const CCommand &args) const;
};

// Define the start of a concommand,
// Using this macro is optional.
// You must end the function with END_CONCOMMAND.
// Inside the function, "cmd" is available for command parsing.
#define DEFINE_CONCOMMAND(x) ConCommand x(#x, 0, [](const CCommand& cmd)
#define END_CONCOMMAND );

// Access convars.
class ConVar : public ConCommandBase
{
protected:
    ConVar *m_pParent = this;
    CUtlString m_pszDefaultValue;

    // Purpose unknown.
    CUtlString m_utlString;
    bool m_bUtlStringSet = false;

    // Purpose unknown, other than possibly having something to do with replicated vars. Don't seem to do anything important.
    CUtlString m_replicatedWaitingString;
    int m_iReplicatedWaitingStringLength = 0;

    CUtlString m_currentValue;
    int m_iCurrentValueLength = 0;

    // Purpose unknown. Filled by _some_ cvars, but seemingly never read.
    CUtlString m_decimalValue;

    float m_flValue = 0.0f;
    int m_iValue = 0;
    int64 m_llValue = 0;
    uint64 m_ullValue = 0;
    double m_dblValue = 0.0;

    // A couple of unknown arrays, which don't seem to do anything (meaningful).
    int *pUnk = nullptr;
    int *pUnk2 = nullptr;

    bool m_bHasMax = false;
    float m_fMaxVal = 0.0f;

    bool m_bHasMin = false;
    float m_fMinVal = 0.0f;

    bool m_bIsDefaultValue = false;
    bool m_bIsReplicatedAndSet = false;
    bool m_bIsReplicatedSet = false;
    bool m_bUnkBool3 = false;

    CUtlVector<FnChangeCallback_t> m_vecCallbacks;

public:
    void InstallChangeCallback(FnChangeCallback_t callback);
    void RemoveChangeCallback(FnChangeCallback_t callback);

public:
    ConVar(const char *pName, const char *pDefaultValue, uint32 flags, const char *pHelpString, bool bHasMax, float maxValue, bool bHasMin, float minValue, FnChangeCallback_t changeCallback = nullptr);
    ConVar(const char *pName, const char *pDefaultValue, uint32 flags, const char *pHelpString, float maxValue, float minValue, FnChangeCallback_t changeCallback = nullptr);
    ConVar(const char *pName, const char *pDefaultValue, uint32 flags, const char *pHelpString, FnChangeCallback_t changeCallback = nullptr);
    ConVar(const char *pName, const char *pDefaultValue, uint32 flags, FnChangeCallback_t changeCallback = nullptr);
    ConVar(const char *pName, const char *pDefaultValue, FnChangeCallback_t changeCallback = nullptr);
    ConVar(const char *pName, const char *pDefaultValue, const char *pHelpString);
    explicit ConVar(const char *pName, FnChangeCallback_t changeCallback = nullptr);

public:
    [[nodiscard]] int GetStringValueLength() const;
    int GetStringValue(char *pBuf, int cbBuf) const;

    [[nodiscard]] const char *GetStringValue() const;

    [[nodiscard]] float GetFloatValue() const;
    [[nodiscard]] int GetIntValue() const;
    [[nodiscard]] int64 GetInt64Value() const;
    [[nodiscard]] double GetDoubleValue() const;
    [[nodiscard]] uint64 GetUInt64Value() const;

public:
    // Internal use only! Set the parent of the ConVar.
    void SetParent(ConVar *pParent)
    {
        this->m_pParent = pParent;
    }

public:
    ~ConVar() override;
    bool BIsCommand() const override;

    // Use this in most cases, unless you know the type of the variable.
    // This will attempt to parse the string into all the types.
    virtual bool SetValue(const char *value);
    virtual bool SetValue(float value);
    virtual bool SetValue(int value);
    virtual bool SetValue(int64 value);
    virtual bool SetValue(double value);
    virtual bool SetValue(uint64 value);
    virtual void Unk1();
    virtual void Validate(CValidator&);
private:
    virtual bool BIsDefaultValue();
    virtual void SetIsDefaultValue();
    virtual void SetIsNotDefaultValue();

    // These are absolutely not accurate. I haven't got the slightest clue what these could be. Replicated convar stuff?
    // Replicated convars aren't even used in Steam, so this is basically useless.
    virtual bool BIsReplicatedValueSet();
    virtual bool BGetUnk3();
    virtual void SetUnk3_True();
    virtual void SetUnk3_False();
    virtual void SetReplicatedWaitingValue(const char *pszString, bool bSetValue, bool bIsNotDefault);

    // Stores a string into the internal unkUtlString buffer. Purpose unknown.
    virtual void SetUnkUtlStr(const char *pszString);

    // Private setters

    virtual void InternalSetValue(const char *pszString);
    virtual void InternalSetValue(float flValue);
    virtual void InternalSetValue(int iValue);
    virtual void InternalSetValue(int64 lValue);
    virtual void InternalSetValue(uint64 ullValue);
    virtual void InternalSetValue(double dValue);
    virtual bool ClampValue(float& flValue);
    virtual void ChangeStringValue(const char *pszString);
};

inline double ConVar::GetDoubleValue() const
{
    Assert(m_pParent);
    return m_pParent->m_dblValue;
}

inline float ConVar::GetFloatValue() const
{
    Assert(m_pParent);
    return m_pParent->m_flValue;
}

inline int64 ConVar::GetInt64Value() const
{
    Assert(m_pParent);
    return m_pParent->m_llValue;
}

inline int ConVar::GetIntValue() const
{
    Assert(m_pParent);
    return m_pParent->m_iValue;
}

inline int ConVar::GetStringValueLength() const
{
    Assert(m_pParent);
    if (m_pParent->IsFlagSet(FCVAR_NEVER_AS_STRING))
        return sizeof("FCVAR_NEVER_AS_STRING");


    return m_pParent->m_iCurrentValueLength;
}

inline const char *ConVar::GetStringValue() const
{
    Assert(m_pParent);

    if (m_pParent->IsFlagSet(FCVAR_NEVER_AS_STRING))
        return "FCVAR_NEVER_AS_STRING";

    return m_pParent->m_currentValue.String();
}

inline int ConVar::GetStringValue(char *pBuf, int cbBuf) const
{
    Assert(m_pParent);

    int toCopy = GetStringValueLength();
    if (cbBuf < toCopy)
    {
        toCopy = cbBuf;
    }

    memcpy(pBuf, m_pParent->m_currentValue.String(), toCopy);

    return toCopy;
}

inline uint64 ConVar::GetUInt64Value() const
{
    Assert(m_pParent);
    return m_pParent->m_ullValue;
}






