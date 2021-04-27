using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;

namespace FTP_client
{

    class Program
    {


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("samir got");
            
            while (ProgramInterface.Breaker)
            {
                ProgramInterface.ProgInterface();
            }
        }
    }

    class ProgramInterface
    {
        static FtpClient ftpClient = new FtpClient();
        static FileStruct[] ListOfFtpFiles;
        public static bool Breaker = true;

        public static void ProgInterface()
        {
            Console.WriteLine("Input the secret word to start");
            string word = Console.ReadLine();
            if (word == "HH")
            {
                ftpClient.Host = @"update.az.idb.local:21";
                ftpClient.UserName = "ftpusrmod1";
                ftpClient.Password = "XXXXXXXXXXXXXX";
                Menu();

            }
            else
            {
                Console.WriteLine("Wrong word. Press any key to exit the program");
                Breaker = false;
                Console.ReadKey();
            }

        }

        static void Menu()
        {
            Console.WriteLine("Select an option(type the order number of option)\n\n");
            Console.WriteLine("1. Get Dirs from FTP");
            Console.WriteLine("2. Upload files");
            string Choice = Console.ReadLine();

            if (Choice == "1")
            {
                GetDirs();
            }
            else if (Choice == "2")
            {
                GetDirs();
                Console.WriteLine("Type numbers of folders u want to deploy");
                Uploader(ArrayFiller());

            }
            else
            {
                Console.WriteLine("Wrong Option!!!");
            }
        }

        static void GetDirs()
        {
            string Dir = "/!Step_Developing1_UMUMI/Hafiz";
            FileStruct[] fss = ftpClient.ListDirectory(Dir);

            for (int i = 0; i < fss.Length; i++)
            {
                Console.WriteLine($"{i}. {fss[i].Name}");
            }
            ListOfFtpFiles = fss;
        }

        static int[] ArrayFiller()
        {
            string[] StrArr = Console.ReadLine().Split();
            int[] arr = new int[StrArr.Length];
            for (int i = 0; i < StrArr.Length; i++)
                Int32.TryParse(StrArr[i], out arr[i]);
            return arr;
        }

        static void Uploader(int[] arr)
        {
            
            for (int i = 0; i < arr.Length; i++)
            {
                ftpClient.CreateDirectory($"/!Step_Developing1_UMUMI/Hafiz/{ListOfFtpFiles[arr[i]].Name}", "site");
                ftpClient.recursiveDirectory($"/!Step_Developing1_UMUMI/Hafiz/{ListOfFtpFiles[arr[i]].Name}/", @"C:\Users\mammadovh\source\Workspaces\Workspace\interfeys\site\");
            }
            Console.WriteLine("Finish");
        }
    }
}