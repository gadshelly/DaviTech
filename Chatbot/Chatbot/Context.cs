using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{
    internal class Context
    {
        public List<string> Words;
        public string Text;
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
