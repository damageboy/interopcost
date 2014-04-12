// InteropCost.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <InteropTarget.h>
#include <windows.h>

int _tmain(int argc, _TCHAR* argv[])
{
  int a, b, x, d;
  a = 1;
  b = 2;
  x = 66;
  d = 3;

  LARGE_INTEGER x1;
  LARGE_INTEGER x2;
  LARGE_INTEGER freq;

  QueryPerformanceFrequency(&freq);

  QueryPerformanceCounter(&x1);

  for (int i = 0; i < 1000000000; i++)
    InteropTarget(a, b, x, d);

  QueryPerformanceCounter(&x2);

  __int64 ms = (x2.QuadPart - x1.QuadPart) / (freq.QuadPart / 1000);

  printf("%d/%fns per call", ms, ms / 1000.0);
	return 0;
}

