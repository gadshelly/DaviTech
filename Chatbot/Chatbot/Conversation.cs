using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatbot;

namespace Chatbot
{
    public class Conversation
    {
        public string UserName = "";
        public bool KnowsName => !string.IsNullOrEmpty(UserName);

        public static Context Parse(string originalText)
        {
            Context ret = new Context();

            ret.OriginalText = originalText;
            string lowerText = originalText.Trim().ToLower();
            char[] chars = lowerText.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (!(char.IsLetterOrDigit(chars[i])))
                {
                    chars[i] = ' ';
                }
            }
            string cleanText = new string(chars);

            if(cleanText.StartsWith("my name s") || cleanText.StartsWith("my name is "))

            ret.CleanText = cleanText;

            if (lowerText.EndsWith('?')) ret.IsQuestion = true;

            ret.Words = new List<string>(cleanText.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            return ret;
        }
        public string Answer(Context context)
        { 
            return "What?";
            //if (text.StartsWith("//")) return "Why did you write a comment? What are you trying to hide from me?";
            //if (text == "hi" || text == "hello") return "Hello";
            //if (text.EndsWith("s your name") || text.EndsWith("s your name?"))
            //{
            //    if (!KnowsName)
            //    {
            //        TellingName = true;
            //        UserKnowsName = true;
            //        return "My name is Megabyte, what's yours?";
            //    }
            //    else return "My name is Megabyte.";
            //}
            //if(TellingName || text.StartsWith("my name is ") || text.StartsWith("my name s "))
            //{
            //    text = text.Replace("?", "");
            //    text = text.Replace("my name is ", "");
            //    text = text.Replace("my name s ", "");
            //    text = text.Replace(",what is yours", "");
            //    text = text.Replace(",what s yours", "");
            //    UserName = text;
            //    UserName.Replace(UserName[0], Char.ToUpper(UserName[0]));
            //    if (TellingName)
            //    {
            //        TellingName = false;
            //        return "Nice to meet you, " + UserName + ".";
            //    }
            //    else
            //    {
            //        UserKnowsName = true;
            //        return "Nice to meet you, " + UserName + ", My name is Megabyte.";
            //    }
            //}
            //if (text.StartsWith("thanks") || text.StartsWith("thank you")) return "Your welcome.";
        }
        public string Respond(string text)
        {
            Context context = Parse(text);
            return Answer(context);
        }
    }
}
