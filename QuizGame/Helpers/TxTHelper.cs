using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Helpers
{
    public static class TxTHelper
    {
        public static bool TxTWrite(string filePath, string[] texts)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return false;
            }
            else if (File.Exists(filePath) == false)
            {
                return false;
            }

            File.WriteAllLines(filePath, texts, Encoding.UTF8);
            return true;
        }

        public static string[] TxTRead(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }
            else if (File.Exists(filePath) == false)
            {
                return null;
            }

            string[] text = File.ReadAllLines(filePath, Encoding.UTF8);
            return text;
        }
    }
}
