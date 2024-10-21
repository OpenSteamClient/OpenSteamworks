#ifndef VALVE_TRACELOGGING_H
#define VALVE_TRACELOGGING_H
#pragma once
#include "platform.h"

#define IsTraceLoggingEnabled() false

//
// Define stubs when trace logging is not enabled
//
#if !IsTraceLoggingEnabled()

	struct _tlgProvider_t;
	typedef struct _tlgProvider_t const* TraceLoggingHProvider;

	#define TRACELOGGING_DECLARE_PROVIDER( hprovider ) extern "C" const TraceLoggingHProvider hprovider;
	#define TRACELOGGING_DEFINE_PROVIDER( hprovider, ... ) extern "C" const TraceLoggingHProvider hprovider = nullptr;
	#define TRACELOGGING_DEFINE_PROVIDER_AUTOREGISTER( hprovider, ... ) TRACELOGGING_DEFINE_PROVIDER( hprovider )
	#define TraceLoggingRegister( ... ) ((void)0)
	#define TraceLoggingUnregister( ... ) ((void)0)
	#define TraceLoggingWrite( ... ) ((void)0)
	#define IsTraceLoggingProviderEnabled( hprovider ) false
	#define TraceLoggingWriteStart( activity, name, ...) ((void)0)
	#define TraceLoggingWriteTagged( activity, name, ...) ((void)0)
	#define TraceLoggingWriteStop( activity, name, ...) ((void)0)
	#define TRACELOGGING_ACTIVITY_SCOPE( hprovider , activity_name, ... ) ((void)0)

	template< TraceLoggingHProvider const& provider > class TraceLoggingActivity {};
	template< TraceLoggingHProvider const& provider > class TraceLoggingThreadActivity {};
#endif
#endif