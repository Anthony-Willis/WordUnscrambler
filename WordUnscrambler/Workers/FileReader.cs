using System;
using System.IO;

namespace WordUnscrambler.Workers
{
    class FileReader
    {
        public string[] Read(string fileName)
        {
            string[] fileContent;
            try
            {
                fileContent = File.ReadAllLines(fileName);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);//by usuing new exception you are keeping the call stack, better practice
            }
            return fileContent; //incase file name not found, must add a try/catch
        }

    }
}
