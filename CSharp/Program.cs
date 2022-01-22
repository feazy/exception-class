using System;
using System.IO;

namespace CSharp
{
    public class InnerException
    {
        static void Main()
        {
            try
            {

                try
                {
                    Console.WriteLine("Enter First Number");
                    int FN = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Second Number");
                    int SN = Convert.ToInt32(Console.ReadLine());
                    int Result = FN / SN;
                    Console.WriteLine("Result = {0}", Result);
                }

                catch (Exception ex)
                {
                    string filePath = @"C:\Users\dvlp\source\repos\exception\CSharp\log2.txt";
                    if (File.Exists(filePath))
                    {
                        StreamWriter sw = new StreamWriter(filePath);
                        sw.Write(ex.GetType().Name);
                        sw.WriteLine();
                        sw.Write(ex.Message);
                        sw.Close();
                        Console.WriteLine("There is a problem, please try again later");
                    }

                    else
                    {
                        throw new FileNotFoundException(filePath + "is not found", ex);
                    }

                }

            }
            catch(Exception exception)
            {

                Console.WriteLine("Current exception = {0}", exception.GetType().Name);
                Console.WriteLine("Inner exception = {0} ",     exception.InnerException.GetType().Name);
            }


        }
    }
}
