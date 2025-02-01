using SML;
using System;
using System.Collections.Generic;

namespace NativeLib;

[Mod.SalemMod]
public class NativeLib
{
    public static List<string> loadedMods { get; protected set;} = new List<string>();

    public static void Start()
    {
        Console.WriteLine("NativeLib works!");
    }
}
