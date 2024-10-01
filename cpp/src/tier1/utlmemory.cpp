//========= Copyright 1996-2010, Valve Corporation, All rights reserved. ============//
//
// Purpose: 
//
// $NoKeywords: $
//
//=============================================================================//

#include <utlmemory.h>

CUtlMemoryBase::CUtlMemoryBase( int nSizeOfType, int nGrowSize, int nInitAllocationCount ) : m_pMemory(0), 
m_nAllocationCount( nInitAllocationCount ), m_nGrowSize( nGrowSize )
{
	Assert( nGrowSize >= 0 );
	if (m_nAllocationCount)
	{
		UTLMEMORY_TRACK_ALLOC();
		m_pMemory = PvAlloc( m_nAllocationCount * nSizeOfType );
	}
}


CUtlMemoryBase::CUtlMemoryBase( int nSizeOfType, void * pMemory, int numElements ) : m_pMemory(pMemory),
m_nAllocationCount( numElements )
{
	Assert( nSizeOfType > 0 );
	// Special marker indicating externally supplied modifyable memory
	m_nGrowSize = EXTERNAL_BUFFER_MARKER;
}


CUtlMemoryBase::CUtlMemoryBase( int nSizeOfType, const void * pMemory, int numElements ) : m_pMemory( (void*)pMemory ),
m_nAllocationCount( numElements )
{
	Assert( nSizeOfType > 0 );
	// Special marker indicating externally supplied modifyable memory
	m_nGrowSize = EXTERNAL_CONST_BUFFER_MARKER;
}

CUtlMemoryBase::~CUtlMemoryBase()
{
	Purge();
}


//-----------------------------------------------------------------------------
// Fast swap
//-----------------------------------------------------------------------------
void *CUtlMemoryBase::Detach()
{
	m_nAllocationCount = 0;
	void *pMemory = m_pMemory;
	m_pMemory = NULL;
	return pMemory;
}

//-----------------------------------------------------------------------------
// Attaches the buffer to external memory....
//-----------------------------------------------------------------------------
void CUtlMemoryBase::SetExternalBuffer( void * pMemory, int numElements )
{
	// Blow away any existing allocated memory
	Purge();

	m_pMemory = pMemory;
	m_nAllocationCount = numElements;

	// Indicate that we don't own the memory
	m_nGrowSize = EXTERNAL_BUFFER_MARKER;
}


void CUtlMemoryBase::SetExternalBuffer( const void* pMemory, int numElements )
{
	// Blow away any existing allocated memory
	Purge();

	m_pMemory = const_cast<void*>( pMemory );
	m_nAllocationCount = numElements;

	// Indicate that we don't own the memory
	m_nGrowSize = EXTERNAL_CONST_BUFFER_MARKER;
}


//-----------------------------------------------------------------------------
// is the memory externally allocated?
//-----------------------------------------------------------------------------
bool CUtlMemoryBase::IsExternallyAllocated() const
{
	return (m_nGrowSize < 0);
}


//-----------------------------------------------------------------------------
// is the memory read only?
//-----------------------------------------------------------------------------
bool CUtlMemoryBase::IsReadOnly() const
{
	return (m_nGrowSize == EXTERNAL_CONST_BUFFER_MARKER);
}


void CUtlMemoryBase::SetGrowSize( int nSize )
{
	Assert( !IsExternallyAllocated() );
	Assert( nSize >= 0 );
	m_nGrowSize = nSize;
}


//-----------------------------------------------------------------------------
// Size
//-----------------------------------------------------------------------------
int CUtlMemoryBase::NumAllocated() const
{
	return m_nAllocationCount;
}


int CUtlMemoryBase::Count() const
{
	return m_nAllocationCount;
}


//-----------------------------------------------------------------------------
// Is element index valid?
//-----------------------------------------------------------------------------
bool CUtlMemoryBase::IsIdxValid( int i ) const
{
	return (i >= 0) && (i < m_nAllocationCount);
}


//-----------------------------------------------------------------------------
// Grows the memory
//-----------------------------------------------------------------------------
int UtlMemory_CalcNewAllocationCount( int nAllocationCount, int nGrowSize, int nNewSize, int nBytesItem )
{
	if ( nGrowSize )
	{ 
		nAllocationCount = ((1 + ((nNewSize - 1) / nGrowSize)) * nGrowSize);
	}
	else 
	{
		if ( !nAllocationCount )
		{
			if ( nBytesItem > 0 )
			{
				// Compute an allocation which is at least as big as a cache line...
				nAllocationCount = (31 + nBytesItem) / nBytesItem;
			}
			else
			{
				// Should be impossible, but if hit try to grow an amount that may be large
				// enough for most cases and thus avoid both divide by zero above as well as
				// likely memory corruption afterwards.
				AssertMsg( false, "nBytesItem is %d in UtlMemory_CalcNewAllocationCount", nBytesItem );
				nAllocationCount = 256;
			}
		}

		// Cap growth to avoid high-end doubling insanity (1 GB -> 2 GB -> overflow)
		int nMaxGrowStep = Max( 1, 256*1024*1024 / ( nBytesItem > 0 ? nBytesItem : 1 ) );
		while (nAllocationCount < nNewSize)
		{
#ifndef _XBOX
			// Grow by doubling, but at most 256 MB at a time.
			nAllocationCount += Min( nAllocationCount, nMaxGrowStep );
#else
			int nNewAllocationCount = ( nAllocationCount * 9) / 8; // 12.5 %
			if ( nNewAllocationCount > nAllocationCount )
				nAllocationCount = nNewAllocationCount;
			else
				nAllocationCount *= 2;
#endif
		}
	}

	return nAllocationCount;
}

//-----------------------------------------------------------------------------
// Memory deallocation
//-----------------------------------------------------------------------------
void CUtlMemoryBase::Purge()
{
	if ( !IsExternallyAllocated() )
	{
		if (m_pMemory)
		{
			UTLMEMORY_TRACK_FREE();
			FreePv( m_pMemory );
			m_pMemory = 0;
		}
		m_nAllocationCount = 0;
	}
}

//-----------------------------------------------------------------------------
// Data and memory validation
//-----------------------------------------------------------------------------
#ifdef DBGFLAG_VALIDATE
void CUtlMemoryBase::Validate( CValidator &validator, const char *pchName )
{

#ifdef _WIN32
	validator.Push( typeid(*this).raw_name(), this, pchName );
#else
	validator.Push( typeid(*this).name(), this, pchName );
#endif

	if ( NULL != m_pMemory )
		validator.ClaimMemory( m_pMemory );

	validator.Pop();
}
#endif // DBGFLAG_VALIDATE
