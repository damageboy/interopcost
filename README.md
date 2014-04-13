InteropCost
===========

# What #

This Test the cost of Managed/Native Interop in .NET / C++

This is a simple test project that shows the price of calling a simple function from C++ vs. doing the same from .NET

All test are run as x64 since that's all I care for. Release mode too with optimization for Native code.

The different projects are:
* InteropTarget - The target .dll which contains a 4 parameter function called `InteropTarget`
* InteropCostNative - A native console app that calls the function and prints the timing info
* InteropCostManaged - A managed .NET console app that calls the function and prints the timing info

# Bugs #

Really?
