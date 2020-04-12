using System;

using System.IO;

namespace TestCourseUdemy.Work
{
    class FileReader
    {
        public string[] Read(string filename)
        {
            string[] fileContent;
            try
            {
                 fileContent = File.ReadAllLines(filename);
            }
            catch(Exception e)
            {

                throw new Exception(e.Message);
            }

            return fileContent;
         

        }
    }
}
