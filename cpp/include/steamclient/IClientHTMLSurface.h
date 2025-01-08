#pragma once

#include "clienttypes.h"

class IClientHTMLSurface
{
public:
    virtual void Destructor1() = 0;

    #ifndef _WIN32
    virtual void Destructor2() = 0;
    #endif
    
    virtual bool Init() = 0;
    virtual bool Shutdown() = 0;
    virtual SteamAPICall_t CreateBrowser(const char *userAgent, const char *customCSS) = 0;
    virtual void RemoveBrowser(HHTMLBrowser handle) = 0;
    virtual void AllowStartRequest(HHTMLBrowser handle, bool allow) = 0;
    virtual void LoadURL(HHTMLBrowser handle, const char *url, const char *postRequest) = 0;
    virtual void SetSize(HHTMLBrowser handle, uint32_t width, uint32_t height) = 0;
    virtual void StopLoad(HHTMLBrowser handle) = 0;
    virtual void Reload(HHTMLBrowser handle) = 0;
    virtual void GoBack(HHTMLBrowser handle) = 0;
    virtual void GoForward(HHTMLBrowser handle) = 0;
    virtual void AddHeader(HHTMLBrowser handle, const char *key, const char *value) = 0;
    virtual void ExecuteJavascript(HHTMLBrowser handle, const char *jsToEval) = 0;
    virtual void MouseUp(HHTMLBrowser handle, EHTMLMouseButton button) = 0;
    virtual void MouseDown(HHTMLBrowser handle, EHTMLMouseButton button) = 0;
    virtual void MouseDoubleClick(HHTMLBrowser handle, EHTMLMouseButton button) = 0;
    virtual void MouseMove(HHTMLBrowser handle, int x, int y) = 0;
    // Might also have uint32_t modifiers
    virtual void MouseWheel(HHTMLBrowser handle, int xDelta, int yDelta) = 0;
    // Uses Xorg's KeySums on Linux, CGKeyCode on MacOS, VKey:s on Windows.
    // Cannot type into text fields.
    virtual void KeyDown(HHTMLBrowser handle, int keyCode, EHTMLKeyModifiers modifiers, bool isSystemKey) = 0;
    virtual void KeyUp(HHTMLBrowser handle, int keyCode, EHTMLKeyModifiers modifiers) = 0;
    // You can't feed control keys. Use KeyDown for it.
    // Types characters into the current focused element
    virtual void KeyChar(HHTMLBrowser handle, int unicodeCharPoint, EHTMLKeyModifiers modifiers) = 0;
    virtual void SetHorizontalScroll(HHTMLBrowser handle, uint32_t absolutePos) = 0;
    virtual void SetVerticalScroll(HHTMLBrowser handle, uint32_t absolutePos) = 0;
    virtual void SetKeyFocus(HHTMLBrowser handle, bool hasFocus) = 0;
    virtual void ViewSource(HHTMLBrowser handle) = 0;
    virtual void CopyToClipboard(HHTMLBrowser handle) = 0;
    virtual void PasteFromClipboard(HHTMLBrowser handle) = 0;
    virtual void Find(HHTMLBrowser handle, const char *searchStr, bool goToNext, bool reverse) = 0;
    virtual void StopFind(HHTMLBrowser handle) = 0;
    virtual SteamAPICall_t GetLinkAtPosition(HHTMLBrowser handle, int x, int y) = 0;
    virtual void JSDialogResponse(HHTMLBrowser handle, bool response) = 0;
    virtual void FileLoadDialogResponse(HHTMLBrowser handle, const char *selectedPath) = 0;
    // Doesn't take a HHTMLBrowser. Wtf?
    virtual void SetCookie(const char *hostname, const char *key, const char *value, const char *path, RTime32 expiry, bool secure, bool httpOnly) = 0;
    virtual void SetPageScaleFactor(HHTMLBrowser handle, float zoom, int x, int y) = 0;
    virtual void SetBackgroundMode(HHTMLBrowser handle, bool backgroundMode) = 0;
    virtual void SetDPIScalingFactor(HHTMLBrowser handle, float scaleFactor) = 0;
    virtual unknown OpenDeveloperTools(HHTMLBrowser handle) = 0;
    virtual unknown Validate(void* cvalidator, const char *unk) = 0;
};