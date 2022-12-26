using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{
    internal class Conversation_HEBREW
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
            cleanText = cleanText.Trim();

            if (cleanText.StartsWith("קוראים לי ") || cleanText.StartsWith("השם שלי הוא ")
                || cleanText.StartsWith("השם שלי זה ")) ret.TellingName = true;

            ret.CleanText = cleanText;

            string subLowerText = lowerText.Substring(1);

            if (lowerText.StartsWith("מה ") || lowerText.StartsWith("מי ") || lowerText.StartsWith("איפה ")
                || lowerText.StartsWith("כמה ") || lowerText.StartsWith("מתי ") || lowerText.StartsWith("האם ")
                || subLowerText.StartsWith("מה ") || subLowerText.StartsWith("מי ") || subLowerText.StartsWith("איפה ")
                || subLowerText.StartsWith("כמה ") ||subLowerText.StartsWith("מתי ")||lowerText.EndsWith('?')) ret.IsQuestion = true;

            ret.Words = new List<string>(cleanText.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            return ret;
        }
        public string Answer(Context context)
        {
            if (context.CleanText == "test")
            {
                string[] file = File.ReadAllText(
                    @"C:\Projects\gadshelly\DaviTech\Chatbot\Chatbot\Hebrew\SentencesTest_HEBREW.txt").Split("\r\n");
                int length = int.Parse(file[0]);
                TestPackage_HEBREW[] packages = new TestPackage_HEBREW[length];

                string input;
                Context expectedOutput = new Context();
                string[] contextFields;

                for (int i = 1; i <= length; i++)
                {
                    input = file[i].Split("//")[0];
                    contextFields = file[i].Split("//")[1].Split(',');
                    expectedOutput = new Context(new List<string>(contextFields[0].Split('+'))
                        , contextFields[1], contextFields[2], Convert.ToBoolean(int.Parse(contextFields[3]))
                        , Convert.ToBoolean(int.Parse(contextFields[4])));

                    packages[i - 1] = new TestPackage_HEBREW(input, expectedOutput);
                }

                Tester_HEBREW tester = new Tester_HEBREW();
                return tester.TestArr(packages);
            }

            if (context.CleanText == "qtest")
            {
                string[] file = File.ReadAllText(
    @"C:\Projects\gadshelly\DaviTech\Chatbot\Chatbot\Hebrew\QuestionsTest.txt").Split("\r\n");
                int length = int.Parse(file[0]);
                QuestionTestPackage_HEBREW[] packages = new QuestionTestPackage_HEBREW[length];

                for (int i = 1; i <= length; i++)
                {
                    packages[i - 1] = new QuestionTestPackage_HEBREW(file[i], true);
                }

                QuestionTester_HEBREW tester = new QuestionTester_HEBREW();
                return tester.TestArr(packages);
            }

            if (context.CleanText == "quit") return "quit";

            if (context.IsQuestion) return "Question detected. ";

            return "No question detected. ";
        }
        public string Respond(string text)
        {
            Context context = Parse(text);
            return Answer(context);
        }

    }
}
