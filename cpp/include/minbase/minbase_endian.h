//====== Copyright 1996-2012, Valve Corporation, All rights reserved. ======//
//
// Endianness handling.
//
//==========================================================================//

#pragma once
#ifndef MINBASE_ENDIAN_H
#define MINBASE_ENDIAN_H

#include <miniutl.h>

//-----------------------------------------------------------------------------
// Purpose: Standard functions for handling endian-ness
//-----------------------------------------------------------------------------

//-------------------------------------
// Basic swaps
//-------------------------------------

template <typename T>
inline T WordSwapC( T w )
{
	COMPILE_TIME_ASSERT( sizeof(T) == sizeof( uint16_t ));
	uint16_t temp;
#if defined( __ICC )
	temp = _byteswap_ushort( *(uint16_t*)&w );
#else
	// This translates into a single rotate on x86/x64
	temp = *(uint16_t *)&w;
	temp = (temp << 8) | (temp >> 8);
#endif
	return *((T*)&temp);
}

template <typename T>
inline T DWordSwapC( T dw )
{
	COMPILE_TIME_ASSERT( sizeof( T ) == sizeof( uint32_t ));
	uint32_t temp;
#if defined( __ICC )
	temp = _byteswap_ulong( *(uint32_t*)&dw );
#elif defined( __clang__ ) || GCC_VERSION >= 40300
	temp = __builtin_bswap32( *(uint32_t*)&dw );
#else
	temp =    *((uint32_t *)&dw) >> 24;
	temp |= ((*((uint32_t *)&dw) & 0x00FF0000) >> 8);
	temp |= ((*((uint32_t *)&dw) & 0x0000FF00) << 8);
	temp |=   *((uint32_t *)&dw) << 24;
#endif
   return *((T*)&temp);
}

template <typename T>
inline T QWordSwapC( T dw )
{
	COMPILE_TIME_ASSERT( sizeof( dw ) == sizeof( uint64_t ));
	uint64_t temp;
#if defined( __ICC )
	temp = _byteswap_uint64( *(uint64_t*)&dw );
#elif defined( __clang__ ) || GCC_VERSION >= 40300
	temp = __builtin_bswap64( *(uint64_t*)&dw );
#else
	temp = (uint64_t)DWordSwapC( (uint32_t)( ( *(uint64_t*)&dw ) >> 32 ) );
	temp |= (uint64_t)DWordSwapC( (uint32_t)( *(uint64_t*)&dw ) ) << 32;
#endif
	return *((T*)&temp);
}

#define WordSwap  WordSwapC
#define DWordSwap DWordSwapC
#define QWordSwap QWordSwapC

#if defined _WIN32 || defined __DOS__
	#define __LITTLE_ENDIAN 4321
	#define __BIG_ENDIAN 1234
	#define __BYTE_ORDER __LITTLE_ENDIAN //!!!
#endif

#if !defined(__BYTE_ORDER) && !defined(__LITTLE_ENDIAN) && !defined(__BIG_ENDIAN)
	#if defined(__BYTE_ORDER__) && defined(__ORDER_BIG_ENDIAN__) && defined(__ORDER_LITTLE_ENDIAN__) // some compilers define this
		#define __BYTE_ORDER __BYTE_ORDER__
		#define __LITTLE_ENDIAN __ORDER_LITTLE_ENDIAN__
		#define __BIG_ENDIAN __ORDER_BIG_ENDIAN__
	#else
		#error
	#endif
#endif

#undef LittleFloat // GCC isn't happy with xash3d_types.h definition

#if __BYTE_ORDER == __LITTLE_ENDIAN
	#define BigInt16( val )		WordSwap( val )
	#define BigWord( val )		WordSwap( val )
	#define BigInt32( val )		DWordSwap( val )
	#define BigDWord( val )		DWordSwap( val )
	#define BigQWord( val )		QWordSwap( val ) 
	#define BigFloat( val )		DWordSwap( val )
	#define LittleInt16( val )	( val )
	#define LittleWord( val )	( val )
	#define LittleInt32( val )	( val )
	#define LittleDWord( val )	( val )
	#define LittleQWord( val )	( val )
	#define LittleFloat( val )	( val )
#elif __BYTE_ORDER == __BIG_ENDIAN
	#define BigInt16( val )		( val )
	#define BigWord( val )		( val )
	#define BigInt32( val )		( val )
	#define BigDWord( val )		( val )
	#define BigQWord( val )		( val )
	#define BigFloat( val )		( val )
	#define LittleInt16( val )	WordSwap( val )
	#define LittleWord( val )	WordSwap( val )
	#define LittleInt32( val )	DWordSwap( val )
	#define LittleDWord( val )	DWordSwap( val )
	#define LittleQWord( val )	QWordSwap( val )
	#define LittleFloat( val )	DWordSwap( val )
#else
	// @Note (toml 05-02-02): this technique expects the compiler to 
	// optimize the expression and eliminate the other path. On any new 
	// platform/compiler this should be tested.
	inline short BigInt16( int16_t val )        { int test = 1; return ( *(char *)&test == 1 ) ? WordSwap( val )  : val; }
	inline uint16_t BigWord( uint16_t val )     { int test = 1; return ( *(char *)&test == 1 ) ? WordSwap( val )  : val; }
	inline int32_t BigInt32( int32_t val )      { int test = 1; return ( *(char *)&test == 1 ) ? DWordSwap( val ) : val; }
	inline uint32_t BigDWord( uint32_t val )    { int test = 1; return ( *(char *)&test == 1 ) ? DWordSwap( val ) : val; }
	inline uint64_t BigQWord( uint64_t val )    { int test = 1; return ( *(char *)&test == 1 ) ? QWordSwap( val ) : val; }
	inline float BigFloat( float val )          { int test = 1; return ( *(char *)&test == 1 ) ? DWordSwap( val ) : val; }
	inline short LittleInt16( int16_t val )     { int test = 1; return ( *(char *)&test == 1 ) ? val : WordSwap( val ); }
	inline uint16_t LittleWord( uint16_t val )  { int test = 1; return ( *(char *)&test == 1 ) ? val : WordSwap( val ); }
	inline long LittleInt32( int32_t val )      { int test = 1; return ( *(char *)&test == 1 ) ? val : DWordSwap( val ); }
	inline uint32_t LittleDWord( uint32_t val ) { int test = 1; return ( *(char *)&test == 1 ) ? val : DWordSwap( val ); }
	inline uint64_t LittleQWord( uint64_t val ) { int test = 1; return ( *(char *)&test == 1 ) ? val : QWordSwap( val ); }
	inline float LittleFloat( float val )       { int test = 1; return ( *(char *)&test == 1 ) ? val : DWordSwap( val ); }
#endif

#if __BYTE_ORDER == __LITTLE_ENDIAN
#define VALVE_LITTLE_ENDIAN 1
#else
#define VALVE_BIG_ENDIAN 1
#endif

#if defined( VALVE_LITTLE_ENDIAN ) == defined( VALVE_BIG_ENDIAN )
	#error "Cannot determine endianness of platform!"
#endif

#if defined(__linux__) || defined(__APPLE__) 
#define VALVE_CALLBACK_PACK_SMALL
#define VALVE_CALLBACK_SIZE 4
#else
#define VALVE_CALLBACK_PACK_LARGE
#define VALVE_CALLBACK_SIZE 8
#endif

#endif // #ifndef MINBASE_ENDIAN_H
