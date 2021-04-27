using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FTP_client
{
    class GetFiles
    {
        static string FileDir = @"C:\Users\mammadovh\source\Workspaces\Workspace\interfeys\";

        public static void RenameIndexFile()
        {
            DirectoryInfo Dir = new DirectoryInfo(@"C:\Users\mammadovh\source\Workspaces\Workspace\interfeys\site");
            var list = Dir.GetFiles();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].FullName.Contains("index.html"))
                    File.Move(list[i].FullName, list[i].FullName.Insert((list[i].FullName.Length - 5), "_umumi"));
            }
        }
    }
}
