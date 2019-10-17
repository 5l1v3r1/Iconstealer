using System;
using System.IO;

using Vestris.ResourceLib;

namespace Iconstealer {
    internal class Program {
        internal static void StealIcon(string sourceExecutable, string targetExecutable) {
            var sourceResInfo = new ResourceInfo();

            File.Copy(targetExecutable, $"{targetExecutable}.bak");

            sourceResInfo.Load(sourceExecutable);

            foreach (var icon in sourceResInfo[Kernel32.ResourceTypes.RT_ICON]) {
                icon.SaveTo(targetExecutable);
            }

            foreach (var groupico in sourceResInfo[Kernel32.ResourceTypes.RT_GROUP_ICON]) {
                groupico.SaveTo(targetExecutable);
            }
        }

        internal static void Main(string[] args) {
            if (args.Length != 2) {
                Console.WriteLine($"{typeof(Program).Assembly.Location} <source> <target>");
                return;
            }

            StealIcon(args[0], args[1]);
        }
    }
}