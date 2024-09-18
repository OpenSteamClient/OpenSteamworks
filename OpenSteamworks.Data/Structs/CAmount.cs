using System.Runtime.InteropServices;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Data.Structs;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CAmount
{
	public int m_nAmount;
	public ECurrencyCode m_eCurrencyCode;
};