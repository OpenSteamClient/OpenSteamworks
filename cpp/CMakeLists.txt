cmake_minimum_required(VERSION 3.10)

project(opensteamworks LANGUAGES C CXX)

set(CMAKE_POSITION_INDEPENDENT_CODE ON)

option(STATIC_TIER0 "Build tier0 statically" ON)
option(STATIC_TIER1 "Build tier1 statically" ON)
option(STATIC_VSTDLIB "Build vstdlib statically" ON)
option(WITH_STEAMPROTO "Build with steamclient protobuf" OFF)

if (STATIC_TIER0)
set(tier0_s_BUILD_TYPE STATIC)
else()
set(tier0_s_BUILD_TYPE SHARED)
endif()

if (STATIC_TIER1)
set(tier1_s_BUILD_TYPE STATIC)
else()
set(tier1_s_BUILD_TYPE SHARED)
endif()

if (STATIC_VSTDLIB)
set(vstdlib_s_BUILD_TYPE STATIC)
else()
set(vstdlib_s_BUILD_TYPE SHARED)
endif()

add_library(tier1_s ${tier1_s_BUILD_TYPE} 
    src/tier1/bitstring.cpp
    src/tier1/cvar.cpp
    src/tier1/generichash.cpp
    src/tier1/ipv6text.c
    src/tier1/netadr.cpp
    src/tier1/strtools.cpp
    src/tier1/utlbuffer.cpp
    src/tier1/utlmemory.cpp
    src/tier1/utlstring.cpp)

add_library(tier0_s ${tier0_s_BUILD_TYPE} 
    src/tier0/dbg.cpp
    src/tier0/platform.cpp)

set_property(TARGET tier0_s PROPERTY POSITION_INDEPENDENT_CODE ON)
set_property(TARGET tier1_s PROPERTY POSITION_INDEPENDENT_CODE ON)

if (WITH_STEAMPROTO)
    include("../OpenSteamworks.Native/cmake/protobuf_external.cmake")
    file(GLOB_RECURSE steamproto_sources CONFIGURE_DEPENDS "../OpenSteamworks.Native/protobufhack/generated/*.cc")

    add_library(steamproto STATIC ${steamproto_sources})

    set_property(TARGET steamproto PROPERTY POSITION_INDEPENDENT_CODE ON)

    set_target_properties(steamproto PROPERTIES CXX_STANDARD 14)
    target_link_libraries(steamproto PUBLIC ${Protobuf_LIBRARIES})

    target_include_directories(steamproto PUBLIC "../OpenSteamworks.Native/protobufhack/generated/" ${Protobuf_INCLUDE_DIRS} PRIVATE ${CMAKE_CURRENT_BINARY_DIR})
endif()

set_target_properties(tier1_s PROPERTIES CXX_STANDARD 20)
set_target_properties(tier0_s PROPERTIES CXX_STANDARD 20)

target_include_directories(tier0_s PUBLIC "include" PRIVATE "include/tier0")
target_include_directories(tier1_s PUBLIC "include" PRIVATE "include/tier1")

target_link_libraries(tier1_s PUBLIC tier0_s)