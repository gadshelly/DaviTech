using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatbot;

namespace Chatbot
{
    public class Context
    {
        public List<string> Words;
        public string OriginalText = "";
        public string CleanText = "";
        public bool IsQuestion = false;
        public bool TellingName = false;
        public override string ToString()
        {
            return $"Original Text: {OriginalText}\n" +
                $"Clean Text: {CleanText}\n" +
                $"Is Question: {IsQuestion}\n" +
                $"Telling Name: {TellingName}\n";
        }
    }
}
