using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NativeLib.API;

public class NativeLoader {

    private static List<string> loadedMods = new List<string>();

    // Loads a native (.dll, .so, .dylib) file from the Embedded resources of a mod
    public static void LoadNativeLibrary(string assemblyName, string libName) {
        string tempPath = Path.Combine(Path.GetTempPath(), libName);

        // Creates temporary file to load
        using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(assemblyName + ".resources." + libName))
        using (FileStream fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(fileStream);
        }

        IntPtr handle = IntPtr.Zero;

        Console.WriteLine("[NativeLib] Loading: " + libName);

        if (!loadedMods.Contains(assemblyName)) {
            loadedMods.Add(assemblyName);
        }

        // Loads the temporary file
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)){
            handle = LoadLibrary(tempPath);
        } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
            handle = LinuxDlopen(tempPath, RTLD_NOW);
        } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
            handle = MacOSDlopen(tempPath, RTLD_NOW);
        }

        if (handle == IntPtr.Zero)
        {
            throw new Exception("Failed to load native library.");
        }
    }

    public static bool HasLoaded(string assemblyName) {
        return loadedMods.Contains(assemblyName);
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr LoadLibrary(string lpFileName);

    [DllImport("libdl.so.2", EntryPoint = "dlopen", SetLastError = true)]
    private static extern IntPtr LinuxDlopen(string filename, int flags);

    [DllImport("libSystem.dylib", EntryPoint = "dlopen", SetLastError = true)]
    private static extern IntPtr MacOSDlopen(string filename, int flags);

    private const int RTLD_NOW = 2;
}