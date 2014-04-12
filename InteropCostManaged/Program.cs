using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;

namespace InteropCostManaged
{
  class Program {
    [DllImport("InteropTarget.dll", EntryPoint = "InteropTarget")]    
    private static extern int InteropTargetRegular(int a, int b, int x, int d);

    [DllImport("InteropTarget.dll", EntryPoint = "InteropTarget")]
    [SuppressUnmanagedCodeSecurity]
    private static extern int InteropTargetFast(int a, int b, int x, int d);

    static void Main(string[] args)
    {
      int a, b, x, d;
      a = 1;
      b = 2;
      x = 66;
      d = 3;


      var sw = Stopwatch.StartNew();

      for (int i = 0; i < 1000000000; i++)
        InteropTargetRegular(a, b, x, d);

      var ms = sw.ElapsedMilliseconds;
      Console.WriteLine("{0}/{1}ns per normal [DllImport] call", ms, ms / 1000.0);

      sw = Stopwatch.StartNew();
      for (int i = 0; i < 1000000000; i++)
        InteropTargetFast(a, b, x, d);

      ms = sw.ElapsedMilliseconds;
      Console.WriteLine("{0}/{1}ns per [DllImport] + [SuppressUnmanagedCodeSecurity] call", ms, ms / 1000.0);
    }
  }
}
