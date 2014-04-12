// InteropTarget.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "InteropTarget.h"

// This is an example of an exported function.
extern "C" INTEROPTARGET_API int InteropTarget(int a, int b, int x, int d)
{
	return 42 + a + b + x + d;
}

