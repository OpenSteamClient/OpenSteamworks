#pragma once

#define Assert( x ) \
do { \
    if (!(x)) { \
        AssertMsgImpl(__FILE__, __LINE__, #x); \
    } \
} while (0)

#define AssertMsg( x, ... ) \
do { \
    if (!(x)) { \
        AssertMsgImpl(__FILE__, __LINE__, __VA_ARGS__); \
    } \
} while (0)

#define AssertEquals( _exp, _expectedValue ) AssertMsg( (_exp) == (_expectedValue), "Expected %d but got %d!", (_expectedValue), (_exp) )
#define VerifyEquals( x, y ) AssertEquals( x, y )
#define VerifyFatal(x) Assert(x)

#define AssertMsg1( _exp, _msg, a1 )									AssertMsg( _exp, _msg, a1 )
#define AssertMsg2( _exp, _msg, a1, a2 )								AssertMsg( _exp, _msg, a1, a2 )
#define AssertMsg3( _exp, _msg, a1, a2, a3 )							AssertMsg( _exp, _msg, a1, a2, a3 )
#define AssertMsg4( _exp, _msg, a1, a2, a3, a4 )						AssertMsg( _exp, _msg, a1, a2, a3, a4 )
#define AssertMsg5( _exp, _msg, a1, a2, a3, a4, a5 )					AssertMsg( _exp, _msg, a1, a2, a3, a4, a5 )
#define AssertMsg6( _exp, _msg, a1, a2, a3, a4, a5, a6 )				AssertMsg( _exp, _msg, a1, a2, a3, a4, a5, a6 )
#define AssertMsg6( _exp, _msg, a1, a2, a3, a4, a5, a6 )				AssertMsg( _exp, _msg, a1, a2, a3, a4, a5, a6 )
#define AssertMsg7( _exp, _msg, a1, a2, a3, a4, a5, a6, a7 )			AssertMsg( _exp, _msg, a1, a2, a3, a4, a5, a6, a7 )
#define AssertMsg8( _exp, _msg, a1, a2, a3, a4, a5, a6, a7, a8 )		AssertMsg( _exp, _msg, a1, a2, a3, a4, a5, a6, a7, a8 )
#define AssertMsg9( _exp, _msg, a1, a2, a3, a4, a5, a6, a7, a8, a9 )	AssertMsg( _exp, _msg, a1, a2, a3, a4, a5, a6, a7, a8, a9 )

#ifndef NDEBUG
    #define DbgAssert Assert
#else
    #define DbgAssert(x)
#endif

#define DbgVerify DbgAssert

extern void AssertMsgImpl(const char *file, int line, const char *msg, ...);