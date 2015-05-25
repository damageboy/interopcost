using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using InteropDotNet;

namespace InteropCostManaged
{
  public interface INative
  {
    [RuntimeDllImport("InteropTarget", EntryPoint = "InteropTarget")]
    int InteropTargetRuntime(int a, int b, int x, int d);
  }


  class Program {
    [DllImport("InteropTarget", EntryPoint = "InteropTarget")]
    private static extern int InteropTargetRegular(int a, int b, int x, int d);

    [DllImport("InteropTarget", EntryPoint = "InteropTarget")]
    [SuppressUnmanagedCodeSecurity]
    private static extern int InteropTargetFast(int a, int b, int x, int d);

    static void Main(string[] args)
    {
      int a, b, x, d;
      a = 1;
      b = 2;
      x = 66;
      d = 3;

      NativePreloadHelper.Preload("InteropTarget");
      var native = InteropRuntimeImplementer.CreateInstance<INative>();

      var sw = Stopwatch.StartNew();


      var iterations = 100000000;
      double iterationsPerNsMsRatio = iterations/1000000;
      for (int i = 0; i < iterations; i++)
        InteropTargetRegular(a, b, x, d);

      var ms = sw.ElapsedMilliseconds;
      Console.WriteLine("{0}/{1}ns per normal [DllImport] call", ms, ms / iterationsPerNsMsRatio);

      sw = Stopwatch.StartNew();
      for (int i = 0; i < iterations; i++)
        InteropTargetFast(a, b, x, d);

      ms = sw.ElapsedMilliseconds;
      Console.WriteLine("{0}/{1}ns per [DllImport] + [SuppressUnmanagedCodeSecurity] call", ms, ms / iterationsPerNsMsRatio);

      sw = Stopwatch.StartNew();
      for (int i = 0; i < iterations; i++)
        native.InteropTargetRuntime(a, b, x, d);

      ms = sw.ElapsedMilliseconds;
      Console.WriteLine("{0}/{1}ns per [RuntimeDllImport] call", ms, ms / iterationsPerNsMsRatio);
    }
  }
}
