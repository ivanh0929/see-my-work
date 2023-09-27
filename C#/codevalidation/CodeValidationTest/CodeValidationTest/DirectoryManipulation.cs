using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Net.WebRequestMethods;

namespace test
{
    internal class DM
    {
        public static void DCreate()
        {
            DirectoryInfo dy;
            // Specify the directory you want to manipulate.
            Console.WriteLine("Please enter the file path.");
            string dir = CV.CVString("Please enter a valid string.");
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(dir))
                {
                    Console.WriteLine("That path exists already. Do you want to overwrite it? Y/N");
                    string confirmation = CV.CVYORN("Please enter Y or N.");

                    // If yes, overwrite
                    // If no, no

                    switch (confirmation)
                    {
                        case "Y":
                            dy = Directory.CreateDirectory(dir);
                            Console.WriteLine("The directory was created successfully at {0}. \nPress any key to continue.", Directory.GetCreationTime(dir));
                            Console.ReadLine();
                            break;
                        case "N":
                            Console.WriteLine("Ending program...\nPress any key to continue.");
                            Console.ReadLine();
                            Environment.Exit(0);
                            break;
                    }

                    return;
                }

                // Since this doesn't exist, go make it
                dy = Directory.CreateDirectory(dir);
                Console.WriteLine("The directory was created successfully at {0}.\nPress any key to continue.", Directory.GetCreationTime(dir));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

        }

        public static void DCreate(string dir)
        {
            DirectoryInfo dy;

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(dir))
                {
                    Console.WriteLine("That path exists already. Do you want to overwrite it? Y/N");
                    string confirmation = CV.CVYORN("Please enter Y or N.");

                    // If yes, overwrite
                    // If no, no

                    switch (confirmation)
                    {
                        case "Y":
                            dy = Directory.CreateDirectory(dir);
                            Console.WriteLine("The directory was created successfully at {0}.\nPress enter to continue.", Directory.GetCreationTime(dir));
                            Console.ReadLine();
                            break;
                        case "N":
                            Console.WriteLine("Ending program...\nPress enter to continue.");
                            Console.ReadLine();
                            Environment.Exit(0);
                            break;
                    }

                    return;
                }

                // Since this doesn't exist, go make it
                dy = Directory.CreateDirectory(dir);
                Console.WriteLine("The directory was created successfully at {0}.\nPress enter to continue.", Directory.GetCreationTime(dir));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
        public static void DDelete()
        {
            // Find a directory
            Console.WriteLine("Please enter the file path to the directory you want to delete.");
            string dir = CV.CVString("Please enter a valid string.");
            Console.WriteLine("Are you sure you want to delete that directory?");
            string confirmation = CV.CVYORN("Please enter Y or N.");

            switch(confirmation)
            {
                case "Y":

                    // Try to delete the directory

                    try
                    {
                        if (Directory.Exists(dir))
                        {
                            Directory.Delete(dir);
                            Console.WriteLine("The directory at {0} was successfully deleted. \nPress enter to continue.", dir);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("The directory at {0} does not exist. \nPress enter to continue.", dir);
                        }
                    }
                    catch (Exception DirectoryNotFound)
                    {
                        Console.WriteLine("The process failed: {0}", DirectoryNotFound.ToString());
                    }
                    break;
                case "N":
                    Console.WriteLine("Deletion cancelled.");
                    break;
            }


        }

        public static void DDelete(string dir)
        {

            // Try to delete the directory

            try
            {
                if (Directory.Exists(dir))
                {
                    Directory.Delete(dir);
                    Console.WriteLine("The directory at {0} was successfully deleted. \nPress enter to continue.", dir);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("The directory at {0} does not exist. \nPress enter to continue.", dir);
                }
            }
            catch (Exception DirectoryNotFound)
            {
                Console.WriteLine("The process failed: {0}", DirectoryNotFound.ToString());
            }


        }

        public static void DWriteStream(string dir)
        {
            // Get the file

            StreamWriter sw = new StreamWriter(dir);
            bool KeepGoing = true;

            // While the user wants to keep writing, keep adding to the file

            do
            {
                Console.WriteLine("Do you want to keep adding lines? Y/N");
                string confirmation = CV.CVYORN("Please enter Y or N.");
                switch (confirmation)
                {
                    case "Y":
                        Console.WriteLine("Provide input.");
                        string addtofile = CV.CVString("Please enter a valid string.");
                        sw.WriteLine(addtofile);
                        KeepGoing = true;
                        break;
                    case "N":
                        KeepGoing = false;
                        break;

                }
            }
            while (KeepGoing = true);
            sw.Close();
        }

        public static void DWriteBinary(string dir)
        {
            // Get the file

            
            Stream outStream = System.IO.File.OpenWrite(dir);
            BinaryWriter bw = new BinaryWriter(outStream);
            bool KeepGoing = true;

            // While the user wants to keep writing, keep adding to the file

            do
            {
                Console.WriteLine("Do you want to keep adding lines? Y/N");
                string confirmation = CV.CVYORN("Please enter Y or N.");
                switch (confirmation)
                {
                    case "Y":
                        Console.WriteLine("Provide input.");
                        string addtofile = CV.CVString("Please enter a valid string.");
                        bw.Write(addtofile);
                        KeepGoing = true;
                        break;
                    case "N":
                        KeepGoing = false;
                        break;

                }
            }
            while (KeepGoing == true);
            bw.Close();
            outStream.Close();
        }

    }
}


