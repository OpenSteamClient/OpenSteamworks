#ifndef MINBASE_TYPES_H
#define MINBASE_TYPES_H
#pragma once

#ifndef MINBASE_IDENTIFY_H
#error Must include minbase_identify.h
#endif

#include <cstdint>

typedef uint8_t uint8;
typedef uint16_t uint16;
typedef uint32_t uint32;
typedef uint64_t uint64;

typedef int8_t int8;
typedef int16_t int16;
typedef int32_t int32;
typedef int64_t int64;

typedef intptr_t intp;
typedef uintptr_t uintp;

typedef uint32 uint;

// Why?
#ifdef _WIN64
	typedef unsigned int str_size;
#else
	typedef size_t str_size;
#endif

#endif