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

Results
=======

The following was obtained on a x64 Intel Core-i7 @ 3.4Ghz

| Method                                            | Time per invocation (ns) |
|---------------------------------------------------|--------------------------|
| Native to Native                                  | 1.63                     |
| Managed to Native [DllImport]                     | 12.95                    |
| Managed to Native [SuppressUnmanagedCodeSecurity] | 2.72                     |
| InteropDotNet                                     | 29.25                    |


Code Generated
==============

Here is a disassembly output of the code generated to complete a single interop call on an x64 machine
Disasseblies were obtained with windbg to get the "real" code for .NET code gen

Native to Native
================
```asm
mov         edx,2  
lea         ecx,[rdx-1]  
lea         r9d,[rdx+1]  
lea         r8d,[rdx+40h]  
call        qword ptr [__imp_InteropTarget (07FF62B932000h)]  
```
The parameters are loaded very effciently into the `rdx`,`rcx`,`r9`,`r8` registers as the compiler can
see that the values do not really change from invocation to invocation so it uses up much more efficient instructions (LEA) to calculate `rcx`, `r9`, `r8` from rdx instead of loading them with constants which would run slower and take up more code

Managed to Native [DllImport]
================

Managed to Native [DllImport] + [SuppressUnmanagedCodeSecurity]
================

# Bugs #

Really?
