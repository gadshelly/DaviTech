using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{
    public class Function
    {
        private bool TellingName = false;

        public bool UserKnowsName = false;
        public bool KnowsName = false;
        public string UserName = "";
        public string Answer(string upperText)
        {
            upperText = upperText.Trim();
            string text = upperText;
            text = text.ToLower();
            int index = 0;
            foreach(char c in text)
            {
                if(!char.IsLetterOrDigit(c))
                {
                    if(index + 1 != text.Length)
                    {
                        if (text[index + 1] != ' ') text.Replace(c, ' ');
                        else text.Replace(c, '\0');
                    }
                    else text.Replace(c, '\0');
                }
                index++;
            }
            if (text.StartsWith("//")) return "Why did you write a comment? What are you trying to hide from me?";
            if (text.EndsWith("!!!") || text.ToUpper() == upperText) return "No need to yell, I understand you just fine.";
            if (text == "hi" || text == "hello") return "Hello";
            if (text.EndsWith("s your name") || text.EndsWith("s your name?"))
            {
                if (!KnowsName)
                {
                    TellingName = true;
                    UserKnowsName = true;
                    return "My name is Megabyte, what's yours?";
                }
                else return "My name is Megabyte.";
            }
            if(TellingName || text.StartsWith("my name is ") || text.StartsWith("my name s "))
            {
                text = text.Replace("?", "");
                text = text.Replace("my name is ", "");
                text = text.Replace("my name s ", "");
                text = text.Replace(",what is yours", "");
                text = text.Replace(",what s yours", "");
                UserName = text;
                UserName.Replace(UserName[0], Char.ToUpper(UserName[0]));
                KnowsName = true;
                if (TellingName)
                {
                    TellingName = false;
                    return "Nice to meet you, " + UserName + ".";
                }
                else
                {
                    UserKnowsName = true;
                    return "Nice to meet you, " + UserName + ", My name is Megabyte.";
                }
            }
            if (text.StartsWith("thanks") || text.StartsWith("thank you")) return "Your welcome.";
            return "I don't understand you.";
        }
    }
}
