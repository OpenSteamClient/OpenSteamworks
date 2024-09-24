//===== Copyright (C) 1996-2005, Valve Corporation, All rights reserved. ======//
//
// Purpose: 
//
// $NoKeywords: $
//
// A growable memory class.
//===========================================================================//

#pragma once
#ifndef UTLMEMORY_H
#define UTLMEMORY_H

#include <string.h>
#include "miniutl.h"

//-----------------------------------------------------------------------------

#ifdef UTLMEMORY_TRACK
#define UTLMEMORY_TRACK_ALLOC()		MemAlloc_RegisterAllocation( "Sum of all UtlMemory", 0, m_nAllocationCount * sizeof(T), m_nAllocationCount * sizeof(T), 0 )
#define UTLMEMORY_TRACK_FREE()		if ( !m_pMemory ) ; else MemAlloc_RegisterDeallocation( "Sum of all UtlMemory", 0, m_nAllocationCount * sizeof(T), m_nAllocationCount * sizeof(T), 0 )
#else
#define UTLMEMORY_TRACK_ALLOC()		((void)0)
#define UTLMEMORY_TRACK_FREE()		((void)0)
#endif

//-----------------------------------------------------------------------------
// The CUtlMemory class:
// A growable memory class which doubles in size by default.
//-----------------------------------------------------------------------------

int UtlMemory_CalcNewAllocationCount(int nAllocationCount, int nGrowSize, int nNewSize, int nBytesItem);

class CUtlMemoryBase
{
public:
	// constructor, destructor
	CUtlMemoryBase( int nSizeOfType, int nGrowSize = 0, int nInitSize = 0 );
	CUtlMemoryBase( int nSizeOfType, void* pMemory, int numElements );
	CUtlMemoryBase( int nSizeOfType, const void* pMemory, int numElements );
	~CUtlMemoryBase();

	// Can we use this index?
	bool IsIdxValid( int i ) const;

	// Attaches the buffer to external memory....
	void SetExternalBuffer( void * pMemory, int numElements );
	void SetExternalBuffer( const void * pMemory, int numElements );

	void *Detach();

	// Size
	int NumAllocated() const;
	int Count() const;

	// Memory deallocation
	void Purge();

	// is the memory externally allocated?
	bool IsExternallyAllocated() const;

	// is the memory read only?
	bool IsReadOnly() const;

	// Set the size by which the memory grows
	void SetGrowSize( int size );

protected:

	// Copy construction and assignment are not valid
	CUtlMemoryBase(const CUtlMemoryBase& rhs);
	const CUtlMemoryBase& operator=(const CUtlMemoryBase& rhs);

	enum
	{
		EXTERNAL_BUFFER_MARKER = -1,
		EXTERNAL_CONST_BUFFER_MARKER = -2,
	};

	void * m_pMemory;
	int m_nAllocationCount;
	int m_nGrowSize;
};

template< class T >
class CUtlMemory : public CUtlMemoryBase
{
public:
	// constructor, destructor
	CUtlMemory( int nGrowSize = 0, int nInitSize = 0 );
	CUtlMemory( T* pMemory, int numElements );
	CUtlMemory( const T* pMemory, int numElements );

	// element access
	T& operator[]( int i );
	const T& operator[]( int i ) const;
	T& Element( int i );
	const T& Element( int i ) const;

	int CubAllocated() const { return m_nAllocationCount * sizeof(T); }
	void Swap( CUtlMemory<T> &mem );

	// Makes sure we've got at least this much memory
	void EnsureCapacity( int num );

	// Grows the memory, so that at least allocated + num elements are allocated
	void Grow( int num = 1 );

	// Switches the buffer from an external memory buffer to a reallocatable buffer
	// Will copy the current contents of the external buffer to the reallocatable buffer
	void ConvertToGrowableMemory( int nGrowSize );

	// Purge all but the given number of elements
	void Purge( int numElements, bool bRealloc = true );

	// Gets the base address (can change when adding elements!)
	T* Base();
	const T* Base() const;

private:
	
	// Copy construction and assignment are not valid
	CUtlMemory(const CUtlMemory& rhs);
	const CUtlMemory& operator=(const CUtlMemory& rhs);
};

//-----------------------------------------------------------------------------
// The CUtlMemoryFixed class:
// A fixed memory class
//-----------------------------------------------------------------------------

template< typename T, size_t SIZE >
class CUtlMemoryFixed
{
public:
	// constructor, destructor
	CUtlMemoryFixed( int nGrowSize = 0, int nInitSize = 0 )	{ Assert( nInitSize == 0 || nInitSize == SIZE ); 	}
	CUtlMemoryFixed( T* pMemory, int numElements )			{ Assert( 0 ); 										}

	// Can we use this index?
	bool IsIdxValid( int i ) const							{ return (i >= 0) && (i < SIZE); }

	// Gets the base address
	T* Base()												{ return (T*)(&m_Memory[0]); }
	const T* Base() const									{ return (const T*)(&m_Memory[0]); }

	// element access
	T& operator[]( int i )									{ Assert( IsIdxValid(i) ); return Base()[i];	}
	const T& operator[]( int i ) const						{ Assert( IsIdxValid(i) ); return Base()[i];	}
	T& Element( int i )										{ Assert( IsIdxValid(i) ); return Base()[i];	}
	const T& Element( int i ) const							{ Assert( IsIdxValid(i) ); return Base()[i];	}

	// Attaches the buffer to external memory....
	void SetExternalBuffer( T* pMemory, int numElements )	{ Assert( 0 ); }

	// Size
	int NumAllocated() const								{ return SIZE; }
	int Count() const										{ return SIZE; }

	// Grows the memory, so that at least allocated + num elements are allocated
	void Grow( int num = 1 )								{ Assert( 0 ); }

	// Makes sure we've got at least this much memory
	void EnsureCapacity( int num )							{ Assert( num <= SIZE ); }

	// Memory deallocation
	void Purge()											{}

	// Purge all but the given number of elements (NOT IMPLEMENTED IN CUtlMemoryFixed)
	void Purge( int numElements, bool bRealloc = true )		{ Assert( 0 ); }

	// is the memory externally allocated?
	bool IsExternallyAllocated() const						{ return false; }

	// Set the size by which the memory grows
	void SetGrowSize( int size )							{}

private:
	uint8_t m_Memory[SIZE*sizeof(T)];
};

//-----------------------------------------------------------------------------
// constructor, destructor
//-----------------------------------------------------------------------------

template< class T >
inline CUtlMemory<T>::CUtlMemory( int nGrowSize, int nInitAllocationCount ) : CUtlMemoryBase( sizeof( T ), nGrowSize, nInitAllocationCount  )
{
	
}


template< class T >
inline CUtlMemory<T>::CUtlMemory( T* pMemory, int numElements ) : CUtlMemoryBase( sizeof( T ), (void*)pMemory, numElements )
{
}


template< class T >
inline CUtlMemory<T>::CUtlMemory( const T* pMemory, int numElements ) : CUtlMemoryBase( sizeof( T ), pMemory, numElements )
{
}


template< class T >
void SWAP( T &a, T &b )
{
	T tmp( a );
	a = b;
	b = tmp;
}

//-----------------------------------------------------------------------------
// Makes sure we've got at least this much memory
//-----------------------------------------------------------------------------
template< class T >
inline void CUtlMemory<T>::EnsureCapacity( int num )
{
	if (m_nAllocationCount >= num)
		return;

	if ( IsExternallyAllocated() )
	{
		// Can't grow a buffer whose memory was externally allocated 
		Assert(0);
		return;
	}

	UTLMEMORY_TRACK_FREE();

	m_nAllocationCount = num;

	UTLMEMORY_TRACK_ALLOC();

	if (m_pMemory)
	{
		m_pMemory = PvRealloc( m_pMemory, m_nAllocationCount * sizeof(T) );
	}
	else
	{
		m_pMemory = PvAlloc( m_nAllocationCount * sizeof(T) );
	}
}

template< class T >
inline void CUtlMemory<T>::Purge( int numElements, bool bRealloc )
{
	Assert( numElements >= 0 );

	if( numElements > m_nAllocationCount )
	{
		// Ensure this isn't a grow request in disguise.
		Assert( numElements <= m_nAllocationCount );
		return;
	}

	// If we have zero elements, simply do a purge:
	if( numElements == 0 )
	{
		Purge();
		return;
	}

	if ( IsExternallyAllocated() )
	{
		// Can't shrink a buffer whose memory was externally allocated, fail silently like purge 
		return;
	}

	// If the number of elements is the same as the allocation count, we are done.
	if( numElements == m_nAllocationCount )
	{
		return;
	}

	if( !m_pMemory )
	{
		// Allocation count is non zero, but memory is null.
		Assert( m_pMemory );
		return;
	}

	if ( bRealloc )
	{
		UTLMEMORY_TRACK_FREE();

		m_nAllocationCount = numElements;

		UTLMEMORY_TRACK_ALLOC();

		// Allocation count > 0, shrink it down.
		MEM_ALLOC_CREDIT_CLASS();
		m_pMemory = PvRealloc( m_pMemory, m_nAllocationCount * sizeof(T) );
	}
	else
	{
		// Some of the tracking may be wrong as we are changing the size but are not reallocating.
		m_nAllocationCount = numElements;
	}
}

//-----------------------------------------------------------------------------
// Fast swap
//-----------------------------------------------------------------------------
template< class T >
inline void CUtlMemory<T>::Swap( CUtlMemory<T> &mem )
{
	SWAP( m_nGrowSize, mem.m_nGrowSize );
	SWAP( m_pMemory, mem.m_pMemory );
	SWAP( m_nAllocationCount, mem.m_nAllocationCount );
}

//-----------------------------------------------------------------------------
// Switches the buffer from an external memory buffer to a reallocatable buffer
//-----------------------------------------------------------------------------
template< class T >
inline void CUtlMemory<T>::ConvertToGrowableMemory( int nGrowSize )
{
	if ( !IsExternallyAllocated() )
		return;

	m_nGrowSize = nGrowSize;
	if (m_nAllocationCount)
	{
		UTLMEMORY_TRACK_ALLOC();
		MEM_ALLOC_CREDIT_CLASS();

		int nNumBytes = m_nAllocationCount * sizeof(T);
		void *pMemory = PvAlloc( nNumBytes );
		memcpy( pMemory, m_pMemory, nNumBytes ); 
		m_pMemory = pMemory;
	}
	else
	{
		m_pMemory = NULL;
	}
}

template< class T >
inline void CUtlMemory<T>::Grow( int num )
{
	Assert( num > 0 );

	if ( IsExternallyAllocated() )
	{
		// Can't grow a buffer whose memory was externally allocated 
		Assert(0);
		return;
	}

	// Make sure we have at least numallocated + num allocations.
	// Use the grow rules specified for this memory (in m_nGrowSize)
	int nAllocationRequested = m_nAllocationCount + num;

	UTLMEMORY_TRACK_FREE();

	m_nAllocationCount = UtlMemory_CalcNewAllocationCount( m_nAllocationCount, m_nGrowSize, nAllocationRequested, sizeof(T) );

	UTLMEMORY_TRACK_ALLOC();
	if (m_pMemory)
	{
		m_pMemory = PvRealloc( m_pMemory, m_nAllocationCount * sizeof(T) );
	}
	else
	{
		m_pMemory = PvAlloc( m_nAllocationCount * sizeof(T) );
	}
}


//-----------------------------------------------------------------------------
// element access
//-----------------------------------------------------------------------------
template< class T >
inline T& CUtlMemory<T>::operator[]( int i )
{
	DbgAssert( !IsReadOnly() );
	DbgAssert( IsIdxValid(i) );
	return ((T*)m_pMemory)[i];
}

template< class T >
inline const T& CUtlMemory<T>::operator[]( int i ) const
{
	DbgAssert( IsIdxValid(i) );
	return ((T*)m_pMemory)[i];
}

template< class T >
inline T& CUtlMemory<T>::Element( int i )
{
	DbgAssert( !IsReadOnly() );
	DbgAssert( IsIdxValid(i) );
	return ((T*)m_pMemory)[i];
}

template< class T >
inline const T& CUtlMemory<T>::Element( int i ) const
{
	DbgAssert( IsIdxValid(i) );
	return ((T*)m_pMemory)[i];
}


//-----------------------------------------------------------------------------
// Gets the base address (can change when adding elements!)
//-----------------------------------------------------------------------------
template< class T >
inline T* CUtlMemory<T>::Base()
{
	return (T*)m_pMemory;
}

template< class T >
inline const T *CUtlMemory<T>::Base() const
{
	return (const T*)m_pMemory;
}

#endif // UTLMEMORY_H
