using HandlebarsDotNet;
using System.IO;
using System.Reflection;

namespace DeeFlat.Email.WebHost.FileSystem
{
    public class DiskFileSystem : ViewEngineFileSystem
    {
        public override string GetFileContent(string filename)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return File.ReadAllText(Path.Combine(path, filename));
        }

        protected override string CombinePath(string dir, string otherFileName)
        {
            return Path.Combine(dir, otherFileName);
        }

        public override bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
