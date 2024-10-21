#pragma once
#include <stdio.h>
#include <stdlib.h>
#include <stdarg.h>
#include <stddef.h>
#include <new>
#include <utility>
#include <string.h>
#include <time.h>

#include <minbase/minbase_identify.h>
#include <minbase/minbase_endian.h>
#include <minbase/minbase_types.h>
#include <minbase/minbase_decls.h>
#include <minbase/minbase_annotations.h>

#if IsPosix()
	typedef int SOCKET;
	#define INVALID_SOCKET (-1)
#else
	typedef uintp SOCKET;
	#define INVALID_SOCKET	(SOCKET)(~0) // must exactly match winsock2.h to avoid warnings
#endif

#if IsPosix()

	// handle mapping windows names used in tier0 to posix names in one place
	#define _snprintf snprintf //validator.cpp
	#if !defined( stricmp )
	#define stricmp strcasecmp // assert_dialog.cpp
	#endif

	#if !defined( _stricmp )
	#define _stricmp strcasecmp // validator.cpp
	#endif
	#define _strcmpi strcasecmp // vprof.cpp

	#include <errno.h>
	inline int GetLastError() { return errno; }

#endif

//-----------------------------------------------------------------------------
// Methods to invoke the constructor, copy constructor, and destructor
//-----------------------------------------------------------------------------

// Placement new, using "default initialization".
// THIS DOES NOT INITIALIZE PODS!
template <class T> 
inline void Construct( T* pMemory )
{
	HINT( pMemory != 0 );
	::new( pMemory ) T;
}

// Placement new, using "value initialization".
// This will zero-initialize PODs
template <class T>
inline T* ValueInitializeConstruct( T* pMemory )
{
	HINT( pMemory != 0 );
	return ::new( pMemory ) T{};
}

template <class T, typename... ConstructorArgs>
inline T* Construct( T* pMemory, ConstructorArgs&&... args )
{
	HINT( pMemory != 0 );
	return ::new( pMemory ) T( std::forward<ConstructorArgs>(args)... );
}

template <class T>
inline void CopyConstruct( T* pMemory, T const& src )
{
	::new( pMemory ) T(src);
}

template <class T> 
inline void Destruct( T* pMemory )
{
	pMemory->~T();

#ifdef _DEBUG
	memset( (void*)pMemory, 0xDD, sizeof(T) );
#endif
}

extern uint32_t Plat_MSTime();
extern uint64_t	Plat_RelativeTicks();	// Returns time in raw ticks since an arbitrary start point.
extern double	Plat_FloatTime();		// Relative ticks to seconds (double).
extern uint64_t	Plat_USTime();			// Relative ticks to microseconds

extern uint32_t ThreadGetCurrentProcessId();
extern uint32_t ThreadGetCurrentId();

extern const char **Plat_GetProcessArgv(int* pArgc);
extern bool Plat_CommandLineParamExists(const char*);

extern bool Plat_IsSteamDeck();
extern bool Plat_IsInDebugSession();