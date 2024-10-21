/* Copyright (C) 2019 Flying With Gauss */

/* Because I removed all tier0 stuff, we need to compensate it with big universal header */

#pragma once
#ifndef MINIUTL_H
#define MINIUTL_H

#include <assert.h>
#include <stdlib.h>
#include <stddef.h>
#include <stdarg.h>
#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include <stdint.h>

#include <minbase/minbase_identify.h>
#include <minbase/minbase_annotations.h>
#include <minbase/minbase_types.h>
#include <minbase/minbase_decls.h>

#if !defined(_MSC_VER)
	#define _vsnprintf vsnprintf
#endif

#ifdef MY_COMPILER_SUCKS
	#define COMPILE_TIME_ASSERT( pred ) typedef int UNIQUE_ID[ (pred) ? 1 : -1]
#else
	#define COMPILE_TIME_ASSERT( pred ) static_assert( pred, "Compile time assert constraint is not true: " #pred )
#endif

#define PvAlloc   malloc
#define PvRealloc realloc
#define FreePv    free

#ifndef _WIN32
	#define PlatformSecureZeroMemory( ptr, len ) memset( ptr, 0, len )
#else
	#define PlatformSecureZeroMemory( ptr, len ) SecureZeroMemory( ptr, len )
#endif

#define Msg       printf

inline void Error( const char *msg )
{
	puts( msg );
	abort();
}

#include <tier0/basetypes.h>
#include <tier0/dbg.h>
#include <tier0/platform.h>

#include <tier1/strtools.h>

#define MEM_ALLOC_CREDIT_CLASS()

#define V_ARRAYSIZE( arr ) ( sizeof((arr)) / sizeof((arr)[0]) )

#endif // MINIUTL_H
