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
        public string UserName = "";
        public bool KnowsName => !string.IsNullOrEmpty(UserName);
        public string Answer(string unmodifiedText)
        {
            unmodifiedText = unmodifiedText.Trim();
            string unlistedText = unmodifiedText;
            unlistedText = unlistedText.ToLower();
            //for(int i = 0; i < unlistedText.Length; i++)
            //{
            //    if(!char.IsLetterOrDigit(unlistedText[i]))
            //    {
            //        unlistedText = unlistedText.Replace(unlistedText[i], ' ');
            //    }
            //}

            for (int i = 0; i < unlistedText.Length; i++)
            {
                if (!char.IsLetterOrDigit(unlistedText[i]))
                {
                    unlistedText.Replace(unlistedText[i], ' ');
                }
            }

            string[] textArr = unlistedText.Split(' ');
            List<string> text = new List<string>();

            for (int i = 0; i < textArr.Length; i++)
            {
                text.Add(textArr[i]);
            }

            if (unlistedText.StartsWith("//")) return "Why did you write a comment? What are you trying to hide from me?";
            if (unlistedText.EndsWith("!!!") || unlistedText.ToUpper() == unmodifiedText) return "No need to yell, I understand you just fine.";
            if (unlistedText == "hi" || unlistedText == "hello") return "Hello";
            if (unlistedText.EndsWith("s your name") || unlistedText.EndsWith("s your name?"))
            {
                if (!KnowsName)
                {
                    TellingName = true;
                    UserKnowsName = true;
                    return "My name is Megabyte, what's yours?";
                }
                else return "My name is Megabyte.";
            }
            if(TellingName || unlistedText.StartsWith("my name is ") || unlistedText.StartsWith("my name s "))
            {
                unlistedText = unlistedText.Replace("?", "");
                unlistedText = unlistedText.Replace("my name is ", "");
                unlistedText = unlistedText.Replace("my name s ", "");
                unlistedText = unlistedText.Replace(",what is yours", "");
                unlistedText = unlistedText.Replace(",what s yours", "");
                UserName = unlistedText;
                UserName.Replace(UserName[0], Char.ToUpper(UserName[0]));
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
            if (unlistedText.StartsWith("thanks") || unlistedText.StartsWith("thank you")) return "Your welcome.";
            return "I don't understand you.";
        }
    }
}
