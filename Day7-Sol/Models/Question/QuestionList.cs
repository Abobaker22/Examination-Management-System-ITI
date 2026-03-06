using System;
using System.Collections.Generic;
using System.Text;

namespace Day7_Sol.Models.Questions
{
    public class QuestionList:List<Question>
    {
        private static List<string>? FileNames;
        public string FileName { get; set; }
        public QuestionList(string filename)
        {
            if (FileNames?.Contains(filename) == true)
                throw new Exception($"That FileName{filename} is Already taken");
            FileNames = new List<string>();
            FileName = filename;
            FileNames.Add(filename);    
        }

        // hide the existing add and introduce My functionality of Add in List Class
        public new void Add(Question item)
        {
            base.Add(item); // kept the default behavior 
            StreamWriter streamWriter = null;
            #region Not the best implementation
            //try
            //{
            //    string filePathWithName = FileName;
            //    streamWriter = new StreamWriter(filePathWithName, true); // true => append mode enabled
            //    streamWriter.WriteLine(item.ToString());

            //    //have you already implemented the ToString() override in your TrueFalseQuestion and ChooseOneQuestion classes? If not,
            //    //sw.WriteLine(item.ToString()) will just print the name of the class instead of the actual question text.
            //}
            //catch (IOException ex)
            //{
            //    Console.WriteLine($"Error logging question: {ex.Message}");
            //}
            //finally
            //{
            //    if (streamWriter != null)
            //    {
            //        streamWriter.Close();
            //        streamWriter.Dispose();
            //    }
            //} 
            #endregion
            try
            {
                // 'true' means APPEND mode. 'using' ensures the file is closed automatically.
                using (StreamWriter sw = new StreamWriter(FileName, true))
                {
                    sw.WriteLine(item.ToString());
                    sw.WriteLine("------------------------------");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Disk error while logging: {ex.Message}");
            }
        }
    }
}
