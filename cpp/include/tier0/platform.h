#pragma once
#include <cstdint>

extern uint32_t Plat_MSTime();
extern uint32_t ThreadGetCurrentProcessId();
extern uint32_t ThreadGetCurrentId();

extern const char **Plat_GetProcessArgv(int* pArgc);
extern bool Plat_CommandLineParamExists(const char*);

extern bool Plat_IsSteamDeck();