using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatbot

namespace Chatbot
{
    public class Context
    {
        public List<string> Words;
        public string OriginalText;
        public string CleanText;
        public bool IsQuestion = false;
        public bool TellingName = false;
        public enum DataType { 
                None,
                FirstName, 
                LastName, 
                FullName,
                Age, 
                Country,
                City,
                Street,
                HouseNum
        };
    }
}
