#pragma once

#define Assert( x ) AssertMsgImpl(__FILE__, __LINE__, x, #x)
#define AssertMsg( x, ... ) AssertMsgImpl(__FILE__, __LINE__, x, __VA_ARGS__)
#define AssertEquals( _exp, _expectedValue ) AssertMsg( (_exp) == (_expectedValue), "Expected %d but got %d!", (_expectedValue), (_exp) )
#define VerifyEquals( x, y ) AssertEquals( x, y )

#ifndef NDEBUG
    #define DbgAssert Assert
#else
    #define DbgAssert(x)
#endif

extern void AssertMsgImpl(const char *file, int line, int cond, const char *msg, ...);