using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HamburguesitoNet.Application.Common.Utils
{
    public class DirectoryUtil
    {
        public static string GetAssemblyDir() => Path.GetDirectoryName(GetAssemblyPath());
        public static string GetAssemblyPath() => Assembly.GetExecutingAssembly().Location;
        public static string GetSolutionFileName() => GetSolutionPath().Split(@"\").Last().Replace(".sln", "");

        public static string GetSolutionPath()
        {
            var currentDirPath = GetAssemblyDir();
            while (currentDirPath != null)
            {
                var fileInCurrentDir = Directory.GetFiles(currentDirPath).Select(f => f.Split(@"\").Last()).ToArray();
                var solutionFileName = fileInCurrentDir.SingleOrDefault(f => f.EndsWith(".sln", StringComparison.InvariantCultureIgnoreCase));
                if (solutionFileName != null)
                    return Path.Combine(currentDirPath, solutionFileName);

                currentDirPath = Directory.GetParent(currentDirPath)?.FullName;
            }

            throw new FileNotFoundException("Cannot find solution file path");
        }
    }
}
