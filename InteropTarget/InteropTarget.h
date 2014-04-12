// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the INTEROPTARGET_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// INTEROPTARGET_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef INTEROPTARGET_EXPORTS
#define INTEROPTARGET_API __declspec(dllexport)
#else
#define INTEROPTARGET_API __declspec(dllimport)
#endif

extern "C" INTEROPTARGET_API int InteropTarget(int a, int b, int x, int d);
