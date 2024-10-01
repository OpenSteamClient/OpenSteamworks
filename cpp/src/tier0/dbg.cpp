#include <tier0/dbg.h>
#include <stdio.h>
#include <cstdlib>
#include <stdarg.h>

void AssertMsgImpl(const char *file, int line, int cond, const char *msg, ...)
{
    if (!!cond)
    {
        return;
    }

    char buf[1024];
	va_list va;
	va_start( va, msg );
	vsnprintf( buf, sizeof( buf ), msg, va );
	va_end( va );

    fprintf(stderr, "%s (%d) : Assertion Failed: %s\n", file, line, buf);
    std::abort();
}