using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RenameFileswithSequence
{
    class RenameSqlFile
    {
        public static void Main(string[] args)
        {
            String SourcePath = @"MentionYourSourcePathoftheFolder"; // For Example - C:\NewFolder Or E:\NewFolder
            String DestinationPath = @"MentiontheDestinationPathoftheFolder"; // For Example - C:\NewFolder Or E:\NewFolder
            String DesiredExtn = "sql";
            ChangeFileName(SourcePath, DestinationPath, DesiredExtn);  
        }

        public static void ChangeFileName(string SPath, string DPath, string destExtension)
        {

            System.Console.WriteLine("Reading your files");
            System.IO.DirectoryInfo Sourcedirpath = new System.IO.DirectoryInfo(SPath);
            System.IO.DirectoryInfo Destdirpath = new System.IO.DirectoryInfo(DPath);
            System.IO.FileInfo[] infos = Sourcedirpath.GetFiles();
            foreach (System.IO.FileInfo f in infos)
            {
                // Do the renaming here
                String filename = f.Name;
                string extension = Path.GetExtension(f.FullName);
                // Avoid the files already have the desired extension
                if (extension != "." + destExtension)
                {
                    int i = filename.LastIndexOf('.');
                    string datascriptPart = filename.Substring(0, i);
                    string filenumber = filename.Substring(i + 1);
                    int j = datascriptPart.LastIndexOf('.');
                    string newfilename = datascriptPart.Insert(j, "-" + filenumber);

                    File.Move(Sourcedirpath + filename, Destdirpath + newfilename);
                    Console.WriteLine("Extension Has been changed: " + newfilename);
                    Console.WriteLine(Environment.NewLine);
                }

            }

            Console.ReadLine();
        
        
        
        }
        
    }
}
