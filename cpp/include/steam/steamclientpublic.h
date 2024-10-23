#pragma once
#include "steamtypes.h"
#include "steamuniverse.h"
#include "steamenums.h"

enum EAccountType {
    k_EAccountTypeInvalid = 0,
    // single user account
    k_EAccountTypeIndividual = 1,	
    // multiseat (e.g. cybercafe) account
    k_EAccountTypeMultiseat = 2,	
    // game server account
    k_EAccountTypeGameServer = 3,
    //  anonymous game server account
    k_EAccountTypeAnonGameServer = 4,	
    k_EAccountTypePending = 5,		
    // content server
    k_EAccountTypeContentServer = 6,	
    k_EAccountTypeClan = 7,
    k_EAccountTypeChat = 8,
    // Fake SteamID for local PSN account on PS3 or Live account on 360, etc.
    k_EAccountTypeConsoleUser = 9,	
    k_EAccountTypeAnonUser = 10,

    // Max of 16 items in this field
    k_EAccountTypeMax
};

const unsigned int k_unSteamAccountIDMask = 0xFFFFFFFF;
const unsigned int k_unSteamAccountInstanceMask = 0x000FFFFF;
const unsigned int k_unSteamUserDefaultInstance	= 1; 

enum EChatSteamIDInstanceFlags
{
	k_EChatAccountInstanceMask = 0x00000FFF, // top 8 bits are flags

	k_EChatInstanceFlagClan = ( k_unSteamAccountInstanceMask + 1 ) >> 1,	// top bit
	k_EChatInstanceFlagLobby = ( k_unSteamAccountInstanceMask + 1 ) >> 2,	// next one down, etc
	k_EChatInstanceFlagMMSLobby = ( k_unSteamAccountInstanceMask + 1 ) >> 3,	// next one down, etc

	// Max of 8 flags
};

#pragma pack( push, 1 )

// Steam ID structure (64 bits total)
class CSteamID
{
public:

	//-----------------------------------------------------------------------------
	// Purpose: Constructor
	//-----------------------------------------------------------------------------
	CSteamID()
	{
		m_steamid.m_comp.m_unAccountID = 0;
		m_steamid.m_comp.m_EAccountType = k_EAccountTypeInvalid;
		m_steamid.m_comp.m_EUniverse = k_EUniverseInvalid;
		m_steamid.m_comp.m_unAccountInstance = 0;
	}


	//-----------------------------------------------------------------------------
	// Purpose: Constructor
	// Input  : unAccountID -	32-bit account ID
	//			eUniverse -		Universe this account belongs to
	//			eAccountType -	Type of account
	//-----------------------------------------------------------------------------
	CSteamID( uint32 unAccountID, EUniverse eUniverse, EAccountType eAccountType )
	{
		Set( unAccountID, eUniverse, eAccountType );
	}


	//-----------------------------------------------------------------------------
	// Purpose: Constructor
	// Input  : unAccountID -	32-bit account ID
	//			unAccountInstance - instance 
	//			eUniverse -		Universe this account belongs to
	//			eAccountType -	Type of account
	//-----------------------------------------------------------------------------
	CSteamID( uint32 unAccountID, unsigned int unAccountInstance, EUniverse eUniverse, EAccountType eAccountType )
	{
		InstancedSet( unAccountID, unAccountInstance, eUniverse, eAccountType );
	}


	//-----------------------------------------------------------------------------
	// Purpose: Constructor
	// Input  : ulSteamID -		64-bit representation of a Steam ID
	// Note:	Will not accept a uint32 or int32 as input, as that is a probable mistake.
	//			See the stubbed out overloads in the private: section for more info.
	//-----------------------------------------------------------------------------
	CSteamID( uint64 ulSteamID )
	{
		SetFromUint64( ulSteamID );
	}

	//-----------------------------------------------------------------------------
	// Purpose: Sets parameters for steam ID
	// Input  : unAccountID -	32-bit account ID
	//			eUniverse -		Universe this account belongs to
	//			eAccountType -	Type of account
	//-----------------------------------------------------------------------------
	void Set( uint32 unAccountID, EUniverse eUniverse, EAccountType eAccountType )
	{
		m_steamid.m_comp.m_unAccountID = unAccountID;
		m_steamid.m_comp.m_EUniverse = eUniverse;
		m_steamid.m_comp.m_EAccountType = eAccountType;

		if ( eAccountType == k_EAccountTypeClan || eAccountType == k_EAccountTypeGameServer )
		{
			m_steamid.m_comp.m_unAccountInstance = 0;
		}
		else
		{
			m_steamid.m_comp.m_unAccountInstance = k_unSteamUserDefaultInstance;
		}
	}


	//-----------------------------------------------------------------------------
	// Purpose: Sets parameters for steam ID
	// Input  : unAccountID -	32-bit account ID
	//			eUniverse -		Universe this account belongs to
	//			eAccountType -	Type of account
	//-----------------------------------------------------------------------------
	void InstancedSet( uint32 unAccountID, uint32 unInstance, EUniverse eUniverse, EAccountType eAccountType )
	{
		m_steamid.m_comp.m_unAccountID = unAccountID;
		m_steamid.m_comp.m_EUniverse = eUniverse;
		m_steamid.m_comp.m_EAccountType = eAccountType;
		m_steamid.m_comp.m_unAccountInstance = unInstance;
	}


	//-----------------------------------------------------------------------------
	// Purpose: Initializes a steam ID from its 52 bit parts and universe/type
	// Input  : ulIdentifier - 52 bits of goodness
	//-----------------------------------------------------------------------------
	void FullSet( uint64 ulIdentifier, EUniverse eUniverse, EAccountType eAccountType )
	{
		m_steamid.m_comp.m_unAccountID = ( ulIdentifier & k_unSteamAccountIDMask );						// account ID is low 32 bits
		m_steamid.m_comp.m_unAccountInstance = ( ( ulIdentifier >> 32 ) & k_unSteamAccountInstanceMask );			// account instance is next 20 bits
		m_steamid.m_comp.m_EUniverse = eUniverse;
		m_steamid.m_comp.m_EAccountType = eAccountType;
	}


	//-----------------------------------------------------------------------------
	// Purpose: Initializes a steam ID from its 64-bit representation
	// Input  : ulSteamID -		64-bit representation of a Steam ID
	//-----------------------------------------------------------------------------
	void SetFromUint64( uint64 ulSteamID )
	{
		m_steamid.m_unAll64Bits = ulSteamID;
	}


	//-----------------------------------------------------------------------------
	// Purpose: Clear all fields, leaving an invalid ID.
	//-----------------------------------------------------------------------------
    void Clear()
	{
		m_steamid.m_comp.m_unAccountID = 0;
		m_steamid.m_comp.m_EAccountType = k_EAccountTypeInvalid;
		m_steamid.m_comp.m_EUniverse = k_EUniverseInvalid;
		m_steamid.m_comp.m_unAccountInstance = 0;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Converts steam ID to its 64-bit representation
	// Output : 64-bit representation of a Steam ID
	//-----------------------------------------------------------------------------
	uint64 ConvertToUint64() const
	{
		return m_steamid.m_unAll64Bits;
	}


	//-----------------------------------------------------------------------------
	// Purpose: Converts the static parts of a steam ID to a 64-bit representation.
	//			For multiseat accounts, all instances of that account will have the
	//			same static account key, so they can be grouped together by the static
	//			account key.
	// Output : 64-bit static account key
	//-----------------------------------------------------------------------------
	uint64 GetStaticAccountKey() const
	{
		// note we do NOT include the account instance (which is a dynamic property) in the static account key
		return (uint64) ( ( ( (uint64) m_steamid.m_comp.m_EUniverse ) << 56 ) + ((uint64) m_steamid.m_comp.m_EAccountType << 52 ) + m_steamid.m_comp.m_unAccountID );
	}


	//-----------------------------------------------------------------------------
	// Purpose: create an anonymous game server login to be filled in by the AM
	//-----------------------------------------------------------------------------
	void CreateBlankAnonLogon( EUniverse eUniverse )
	{
		m_steamid.m_comp.m_unAccountID = 0;
		m_steamid.m_comp.m_EAccountType = k_EAccountTypeAnonGameServer;
		m_steamid.m_comp.m_EUniverse = eUniverse;
		m_steamid.m_comp.m_unAccountInstance = 0;
	}


	//-----------------------------------------------------------------------------
	// Purpose: create an anonymous game server login to be filled in by the AM
	//-----------------------------------------------------------------------------
	void CreateBlankAnonUserLogon( EUniverse eUniverse )
	{
		m_steamid.m_comp.m_unAccountID = 0;
		m_steamid.m_comp.m_EAccountType = k_EAccountTypeAnonUser;
		m_steamid.m_comp.m_EUniverse = eUniverse;
		m_steamid.m_comp.m_unAccountInstance = 0;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Is this an anonymous game server login that will be filled in?
	//-----------------------------------------------------------------------------
	bool BBlankAnonAccount() const
	{
		return m_steamid.m_comp.m_unAccountID == 0 && BAnonAccount() && m_steamid.m_comp.m_unAccountInstance == 0;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Is this a game server account id?  (Either persistent or anonymous)
	//-----------------------------------------------------------------------------
	bool BGameServerAccount() const
	{
		return m_steamid.m_comp.m_EAccountType == k_EAccountTypeGameServer || m_steamid.m_comp.m_EAccountType == k_EAccountTypeAnonGameServer;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Is this a persistent (not anonymous) game server account id?
	//-----------------------------------------------------------------------------
	bool BPersistentGameServerAccount() const
	{
		return m_steamid.m_comp.m_EAccountType == k_EAccountTypeGameServer;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Is this an anonymous game server account id?
	//-----------------------------------------------------------------------------
	bool BAnonGameServerAccount() const
	{
		return m_steamid.m_comp.m_EAccountType == k_EAccountTypeAnonGameServer;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Is this a content server account id?
	//-----------------------------------------------------------------------------
	bool BContentServerAccount() const
	{
		return m_steamid.m_comp.m_EAccountType == k_EAccountTypeContentServer;
	}


	//-----------------------------------------------------------------------------
	// Purpose: Is this a clan account id?
	//-----------------------------------------------------------------------------
	bool BClanAccount() const
	{
		return m_steamid.m_comp.m_EAccountType == k_EAccountTypeClan;
	}


	//-----------------------------------------------------------------------------
	// Purpose: Is this a chat account id?
	//-----------------------------------------------------------------------------
	bool BChatAccount() const
	{
		return m_steamid.m_comp.m_EAccountType == k_EAccountTypeChat;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Is this a chat account id?
	//-----------------------------------------------------------------------------
	bool IsLobby() const
	{
		return ( m_steamid.m_comp.m_EAccountType == k_EAccountTypeChat )
			&& ( m_steamid.m_comp.m_unAccountInstance & k_EChatInstanceFlagLobby );
	}


	//-----------------------------------------------------------------------------
	// Purpose: Is this an individual user account id?
	//-----------------------------------------------------------------------------
	bool BIndividualAccount() const
	{
		return m_steamid.m_comp.m_EAccountType == k_EAccountTypeIndividual || m_steamid.m_comp.m_EAccountType == k_EAccountTypeConsoleUser;
	}


	//-----------------------------------------------------------------------------
	// Purpose: Is this an anonymous account?
	//-----------------------------------------------------------------------------
	bool BAnonAccount() const
	{
		return m_steamid.m_comp.m_EAccountType == k_EAccountTypeAnonUser || m_steamid.m_comp.m_EAccountType == k_EAccountTypeAnonGameServer;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Is this an anonymous user account? ( used to create an account or reset a password )
	//-----------------------------------------------------------------------------
	bool BAnonUserAccount() const
	{
		return m_steamid.m_comp.m_EAccountType == k_EAccountTypeAnonUser;
	}

	//-----------------------------------------------------------------------------
	// Purpose: Is this a faked up Steam ID for a PSN friend account?
	//-----------------------------------------------------------------------------
	bool BConsoleUserAccount() const
	{
		return m_steamid.m_comp.m_EAccountType == k_EAccountTypeConsoleUser;
	}
	
	const char * Render() const;				// renders this steam ID to string
	static const char * Render( uint64 ulSteamID );	// static method to render a uint64 representation of a steam ID to a string

	// simple accessors
	void SetAccountID( uint32 unAccountID )		{ m_steamid.m_comp.m_unAccountID = unAccountID; }
	void SetAccountInstance( uint32 unInstance ){ m_steamid.m_comp.m_unAccountInstance = unInstance; }
		
	AccountID_t GetAccountID() const			{ return m_steamid.m_comp.m_unAccountID; }
	uint32 GetUnAccountInstance() const			{ return m_steamid.m_comp.m_unAccountInstance; }
	EAccountType GetEAccountType() const		{ return ( EAccountType ) m_steamid.m_comp.m_EAccountType; }
	EUniverse GetEUniverse() const				{ return m_steamid.m_comp.m_EUniverse; }
	void SetEUniverse( EUniverse eUniverse )	{ m_steamid.m_comp.m_EUniverse = eUniverse; }
	bool IsValid() const;

	// this set of functions is hidden, will be moved out of class
	explicit CSteamID( const char *pchSteamID, EUniverse eDefaultUniverse = k_EUniverseInvalid );

	void SetFromString( const char *pchSteamID, EUniverse eDefaultUniverse );
    // SetFromString allows many partially-correct strings, constraining how
    // we might be able to change things in the future.
    // SetFromStringStrict requires the exact string forms that we support
    // and is preferred when the caller knows it's safe to be strict.
    // Returns whether the string parsed correctly.
	bool SetFromStringStrict( const char *pchSteamID, EUniverse eDefaultUniverse );

	inline bool operator==( const CSteamID &val ) const { return m_steamid.m_unAll64Bits == val.m_steamid.m_unAll64Bits; } 
	inline bool operator!=( const CSteamID &val ) const { return !operator==( val ); }
	inline bool operator<( const CSteamID &val ) const { return m_steamid.m_unAll64Bits < val.m_steamid.m_unAll64Bits; }
	inline bool operator>( const CSteamID &val ) const { return m_steamid.m_unAll64Bits > val.m_steamid.m_unAll64Bits; }

	// DEBUG function
	bool BValidExternalSteamID() const;

private:
	// These are defined here to prevent accidental implicit conversion of a u32AccountID to a CSteamID.
	// If you get a compiler error about an ambiguous constructor/function then it may be because you're
	// passing a 32-bit int to a function that takes a CSteamID. You should explicitly create the SteamID
	// using the correct Universe and account Type/Instance values.
	CSteamID( uint32 );
	CSteamID( int32 );

	// 64 bits total
	union SteamID_t
	{
		struct SteamIDComponent_t
		{
#ifdef VALVE_BIG_ENDIAN
			EUniverse			m_EUniverse : 8;	// universe this account belongs to
			unsigned int		m_EAccountType : 4;			// type of account - can't show as EAccountType, due to signed / unsigned difference
			unsigned int		m_unAccountInstance : 20;	// dynamic instance ID
			uint32				m_unAccountID : 32;			// unique account identifier
#else
			uint32				m_unAccountID : 32;			// unique account identifier
			unsigned int		m_unAccountInstance : 20;	// dynamic instance ID
			unsigned int		m_EAccountType : 4;			// type of account - can't show as EAccountType, due to signed / unsigned difference
			EUniverse			m_EUniverse : 8;	// universe this account belongs to
#endif
		} m_comp;

		uint64 m_unAll64Bits;
	} m_steamid;
};

inline bool CSteamID::IsValid() const
{
	if ( m_steamid.m_comp.m_EAccountType <= k_EAccountTypeInvalid || m_steamid.m_comp.m_EAccountType >= k_EAccountTypeMax )
		return false;
	
	if ( m_steamid.m_comp.m_EUniverse <= k_EUniverseInvalid || m_steamid.m_comp.m_EUniverse >= k_EUniverseMax )
		return false;

	if ( m_steamid.m_comp.m_EAccountType == k_EAccountTypeIndividual )
	{
		if ( m_steamid.m_comp.m_unAccountID == 0 || m_steamid.m_comp.m_unAccountInstance != k_unSteamUserDefaultInstance )
			return false;
	}

	if ( m_steamid.m_comp.m_EAccountType == k_EAccountTypeClan )
	{
		if ( m_steamid.m_comp.m_unAccountID == 0 || m_steamid.m_comp.m_unAccountInstance != 0 )
			return false;
	}

	if ( m_steamid.m_comp.m_EAccountType == k_EAccountTypeGameServer )
	{
		if ( m_steamid.m_comp.m_unAccountID == 0 )
			return false;
		// Any limit on instances?  We use them for local users and bots
	}
	return true;
}

// generic invalid CSteamID
#define k_steamIDNil CSteamID()

// This steamID comes from a user game connection to an out of date GS that hasnt implemented the protocol
// to provide its steamID
#define k_steamIDOutofDateGS CSteamID( 0, 0, k_EUniverseInvalid, k_EAccountTypeInvalid )
// This steamID comes from a user game connection to an sv_lan GS
#define k_steamIDLanModeGS CSteamID( 0, 0, k_EUniversePublic, k_EAccountTypeInvalid )
// This steamID can come from a user game connection to a GS that has just booted but hasnt yet even initialized
// its steam3 component and started logging on.
#define k_steamIDNotInitYetGS CSteamID( 1, 0, k_EUniverseInvalid, k_EAccountTypeInvalid )
// This steamID can come from a user game connection to a GS that isn't using the steam authentication system but still
// wants to support the "Join Game" option in the friends list
#define k_steamIDNonSteamGS CSteamID( 2, 0, k_EUniverseInvalid, k_EAccountTypeInvalid )

struct SteamIPAddress_t
{
    enum ESteamIPType
    {
        k_ESteamIPTypeIPv4 = 0,
        k_ESteamIPTypeIPv6 = 1,
    };

	union {

		uint32_t			m_unIPv4;		    // Host order
		uint8_t			    m_rgubIPv6[16];		// Network order! Same as inaddr_in6.  (0011:2233:4455:6677:8899:aabb:ccdd:eeff)

		// Internal use only
		uint64_t			m_ipv6Qword[2];	    // big endian
	};

	ESteamIPType m_eType;

	bool IsSet() const 
	{ 
		if ( k_ESteamIPTypeIPv4 == m_eType )
		{
			return m_unIPv4 != 0;
		}
		else 
		{
			return m_ipv6Qword[0] !=0 || m_ipv6Qword[1] != 0; 
		}
	}

	static SteamIPAddress_t FromIPv4(uint32_t ip)
	{
		SteamIPAddress_t ipOut;
		ipOut.m_eType = k_ESteamIPTypeIPv4;
		ipOut.m_unIPv4 = ip;

		return ipOut;
	}

	static SteamIPAddress_t IPv4Any()
	{
		SteamIPAddress_t ipOut;
		ipOut.m_eType = k_ESteamIPTypeIPv4;
		ipOut.m_unIPv4 = 0;

		return ipOut;
	}

	static SteamIPAddress_t IPv6Any()
	{
		SteamIPAddress_t ipOut;
		ipOut.m_eType = k_ESteamIPTypeIPv6;
		ipOut.m_ipv6Qword[0] = 0;
		ipOut.m_ipv6Qword[1] = 0;

		return ipOut;
	}

	static SteamIPAddress_t IPv4Loopback()
	{
		SteamIPAddress_t ipOut;
		ipOut.m_eType = k_ESteamIPTypeIPv4;
		ipOut.m_unIPv4 = 0x7f000001;

		return ipOut;
	}

	static SteamIPAddress_t IPv6Loopback()
	{
		SteamIPAddress_t ipOut;
		ipOut.m_eType = k_ESteamIPTypeIPv6;
		ipOut.m_ipv6Qword[0] = 0;
		ipOut.m_ipv6Qword[1] = 0;
		ipOut.m_rgubIPv6[15] = 1;

		return ipOut;
	}
};

//-----------------------------------------------------------------------------
// Purpose: encapsulates an appID/modID pair
//-----------------------------------------------------------------------------
class CGameID
{
public:

	CGameID()
	{
		m_gameID.m_nType = k_EGameIDTypeApp;
		m_gameID.m_nAppID = k_uAppIdInvalid;
		m_gameID.m_nModID = 0;
	}

	explicit CGameID( uint64 ulGameID )
	{
		m_ulGameID = ulGameID;
	}

	explicit CGameID( int32 nAppID )
	{
		m_ulGameID = 0;
		m_gameID.m_nAppID = nAppID;
	}

	explicit CGameID( uint32 nAppID )
	{
		m_ulGameID = 0;
		m_gameID.m_nAppID = nAppID;
	}

	CGameID( uint32 nAppID, uint32 nModID )
	{
		m_ulGameID = 0;
		m_gameID.m_nAppID = nAppID;
		m_gameID.m_nModID = nModID;
		m_gameID.m_nType = k_EGameIDTypeGameMod;
	}

	CGameID( const CGameID &that )
	{
		m_ulGameID = that.m_ulGameID;
	}

	CGameID& operator=( const CGameID & that )
	{
		m_ulGameID = that.m_ulGameID;
		return *this;
	}

	// Hidden functions used only by Steam
	explicit CGameID( const char *pchGameID );
	const char *Render() const;					// render this Game ID to string
	static const char *Render( uint64 ulGameID );		// static method to render a uint64 representation of a Game ID to a string

	uint64 ToUint64() const
	{
		return m_ulGameID;
	}

	uint64 *GetUint64Ptr()
	{
		return &m_ulGameID;
	}

	void Set( uint64 ulGameID )
	{
		m_ulGameID = ulGameID;
	}

	bool IsMod() const
	{
		return ( m_gameID.m_nType == k_EGameIDTypeGameMod );
	}

	bool IsShortcut() const
	{
		return ( m_gameID.m_nType == k_EGameIDTypeShortcut );
	}

	bool IsP2PFile() const
	{
		return ( m_gameID.m_nType == k_EGameIDTypeP2P );
	}

	bool IsSteamApp() const
	{
		return ( m_gameID.m_nType == k_EGameIDTypeApp );
	}
		
	uint32 ModID() const
	{
		return m_gameID.m_nModID;
	}

	uint32 AppID() const
	{
		return m_gameID.m_nAppID;
	}

	bool operator == ( const CGameID &rhs ) const
	{
		return m_ulGameID == rhs.m_ulGameID;
	}

	bool operator != ( const CGameID &rhs ) const
	{
		return !(*this == rhs);
	}

	bool operator < ( const CGameID &rhs ) const
	{
		return ( m_ulGameID < rhs.m_ulGameID );
	}

	bool IsValid() const
	{
		// each type has it's own invalid fixed point:
		switch( m_gameID.m_nType )
		{
		case k_EGameIDTypeApp:
			return m_gameID.m_nAppID != k_uAppIdInvalid;

		case k_EGameIDTypeGameMod:
			return m_gameID.m_nAppID != k_uAppIdInvalid && m_gameID.m_nModID & 0x80000000;

		case k_EGameIDTypeShortcut:
			return (m_gameID.m_nModID & 0x80000000) != 0;

		case k_EGameIDTypeP2P:
			return m_gameID.m_nAppID == k_uAppIdInvalid && m_gameID.m_nModID & 0x80000000;

		default:
			return false;
		}

	}

	void Reset() 
	{
		m_ulGameID = 0;
	}

//
// Internal stuff.  Use the accessors above if possible
//

	enum EGameIDType
	{
		k_EGameIDTypeApp		= 0,
		k_EGameIDTypeGameMod	= 1,
		k_EGameIDTypeShortcut	= 2,
		k_EGameIDTypeP2P		= 3,
	};

	struct GameID_t
	{
#ifdef VALVE_BIG_ENDIAN
		unsigned int m_nModID : 32;
		unsigned int m_nType : 8;
		unsigned int m_nAppID : 24;
#else
		unsigned int m_nAppID : 24;
		unsigned int m_nType : 8;
		unsigned int m_nModID : 32;
#endif
	};

	union
	{
		uint64 m_ulGameID;
		GameID_t m_gameID;
	};
};


#pragma pack( pop )

//-----------------------------------------------------------------------------
// Purpose: information about user sessions
//-----------------------------------------------------------------------------
struct FriendSessionStateInfo_t
{
	uint32 m_uiOnlineSessionInstances;
	uint8 m_uiPublishedToFriendsSessionInstance;
};

#pragma pack( push, VALVE_CALLBACK_SIZE )

struct SteamItemDetails_t
{
	SteamItemInstanceID_t m_itemId;
	SteamItemDef_t m_iDefinition;
	uint16 m_unQuantity;
	uint16 m_unFlags; // see ESteamItemFlags
};

struct SteamPartyBeaconLocation_t
{
	ESteamPartyBeaconLocationType m_eType;
	uint64 m_ulLocationID;
};

// connection state to a specified user, returned by GetP2PSessionState()
// this is under-the-hood info about what's going on with a SendP2PPacket(), shouldn't be needed except for debuggin
struct P2PSessionState_t
{
	uint8 m_bConnectionActive;		// true if we've got an active open connection
	uint8 m_bConnecting;			// true if we're currently trying to establish a connection
	uint8 m_eP2PSessionError;		// last error recorded (see enum above)
	uint8 m_bUsingRelay;			// true if it's going through a relay server (TURN)
	int32 m_nBytesQueuedForSend;
	int32 m_nPacketsQueuedForSend;
	uint32 m_nRemoteIP;				// potential IP:Port of remote host. Could be TURN server. 
	uint16 m_nRemotePort;			// Only exists for compatibility with older authentication api's
};

// friend game played information
struct FriendGameInfo_t
{
	CGameID m_gameID;
	uint32 m_unGameIP;
	uint16 m_usGamePort;
	uint16 m_usQueryPort;
	CSteamID m_steamIDLobby;
};

// a single entry in a leaderboard, as returned by GetDownloadedLeaderboardEntry()
struct LeaderboardEntry_t
{
	CSteamID m_steamIDUser; // user with the entry - use SteamFriends()->GetFriendPersonaName() & SteamFriends()->GetFriendAvatar() to get more info
	int32 m_nGlobalRank;	// [1..N], where N is the number of users with an entry in the leaderboard
	int32 m_nScore;			// score as set in the leaderboard
	int32 m_cDetails;		// number of int32 details available for this entry
	UGCHandle_t m_hUGC;		// handle for UGC attached to the entry
};

//-----------------------------------------------------------------------------
// Purpose: Structure that contains an array of const char * strings and the number of those strings
//-----------------------------------------------------------------------------
struct SteamParamStringArray_t
{
    SteamParamStringArray_t()
	{
		m_ppStrings = nullptr;
		m_nNumStrings = 0;
	}

	const char ** m_ppStrings;
	int32 m_nNumStrings;
};

#pragma pack( pop )