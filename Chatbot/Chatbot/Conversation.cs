﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatbot;
using System.IO;
using System.Text;
using javax.management.relation;

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
			cleanText = cleanText.Trim();

			if (cleanText.StartsWith("my name s")
				|| cleanText.StartsWith("my name is ")) ret.TellingName = true;

			ret.CleanText = cleanText;

			if (lowerText.StartsWith("what") || lowerText.StartsWith("where ") || lowerText.StartsWith("why ") 
				|| lowerText.StartsWith("who ") || lowerText.StartsWith("is ") || lowerText.StartsWith("am ")
				|| lowerText.StartsWith("are ") || lowerText.StartsWith("do ") || lowerText.StartsWith("does ")
				|| lowerText.StartsWith("did ") || lowerText.StartsWith("can ") || lowerText.StartsWith("was ")
				|| lowerText.StartsWith("where ") || lowerText.StartsWith("will ") || lowerText.StartsWith("won ")
				|| lowerText.StartsWith("whose ") || lowerText.StartsWith("had ") || lowerText.StartsWith("whose ")
				|| lowerText.StartsWith("have ") || lowerText.StartsWith("when ") || lowerText.StartsWith("how")
				|| lowerText.EndsWith('?')) ret.IsQuestion = true;

			ret.Words = new List<string>(cleanText.Split(' ', StringSplitOptions.RemoveEmptyEntries));

			lowerText = lowerText + " ;";
			if (!ret.IsQuestion && (lowerText.StartsWith("his ") || lowerText.StartsWith("her ") 
				|| lowerText.StartsWith("their ") || lowerText.StartsWith("my ") || lowerText.StartsWith("your ")
				|| lowerText.StartsWith("our ")) //|| lowerText.Split()[1] == "his" || lowerText.Split()[1] == "her" 
				//|| lowerText.Split()[1] == "their" || lowerText.Split()[1] == "my" || lowerText.Split()[1] == "your" 
			   // || lowerText.Split()[1] == "our")
	//|| lowerText.Split()[1] == "is"
	)
			{
				string understandContext = originalText;

				//understandContext = understandContext.Replace("his ", "");
				//understandContext = understandContext.Replace("her ", "");
				//understandContext = understandContext.Replace("their ", "");
				//understandContext = understandContext.Replace("my ", "");
				//understandContext = understandContext.Replace("your ", "");
				//understandContext = understandContext.Replace("our ", "");
				//understandContext = understandContext.Replace("the ", "");
				//
				//if (understandContext.Split("are").Length > 1) ret.TalkAbout = understandContext.Split(" are")[0];
				//else if (understandContext.Split("is").Length > 1) ret.TalkAbout = understandContext.Split(" is")[0];

				try
				{
					understandContext = understandContext.Replace(understandContext.ToLower().Split(" is")[1], "");
					understandContext = understandContext.Replace(" is", "");
				}
				catch
				{
					understandContext = understandContext.Replace(understandContext.ToLower().Split(" are")[1], "");
					understandContext = understandContext.Replace(" are", "");
				}


				//ret.TalksAbout = understandContext.Replace(understandContext.Split()[0].ToLower().Replace(" ", ""), "");

				ret.TalksAbout = understandContext.Split()[1];

				if (understandContext.Split()[0].ToLower() != "the")
					ret.BelongsTo = understandContext.Split()[0].ToLower();
				else ret.BelongsTo = "no one";
			}
            else if (ret.IsQuestion && (lowerText.Split()[1] == "his"
				|| lowerText.Split()[1] == "her" || lowerText.Split()[1] == "their" || lowerText.Split()[1] == "my" 
				|| lowerText.Split()[1] == "your"|| lowerText.Split()[1] == "our" || lowerText.Split()[1] == "is"))
			{
				string understandContext = lowerText;
                //string firstWord = lowerText.Split()[0];

                //understandContext = understandContext.Replace(understandContext.Split()[0], "");

                //understandContext = understandContext.Replace(firstWord, "");

                //understandContext.Split()[0] = " ";

                understandContext = understandContext.Substring(3);
				if (understandContext.StartsWith(' ')) understandContext = understandContext.Substring(1);

                understandContext = understandContext.Replace(" is", "");
				understandContext = understandContext.Replace(" are", "");
				//understandContext = understandContext.Substring(1);

				understandContext = understandContext.Replace("?", "");
				understandContext = understandContext.Replace("!", "");
				//understandContext = understandContext.Replace(understandContext.Split()[0], "");
				ret.BelongsTo = understandContext.Split()[0];
                //understandContext = understandContext.Substring(1);
				ret.TalksAbout = understandContext.Split()[1];
			}
			lowerText = lowerText.Substring(lowerText.Length - 2);

			return ret;
		}
		public string Answer(Context context)
		{ 
			if(context.CleanText == "test")
			{
				string[] file = File.ReadAllText(
					@"C:\Projects\gadshelly\DaviTech\Chatbot\Chatbot\SentencesTest.txt").Split("\r\n");
				int length = int.Parse(file[0]);
				TestPackage[] packages = new TestPackage[length];

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

					packages[i - 1] = new TestPackage(input, expectedOutput);
				}

				Tester tester = new Tester();
				return tester.TestArr(packages);
			}

			else if (context.CleanText == "qtest")
			{
				string[] file = File.ReadAllText(
	@"C:\Projects\gadshelly\DaviTech\Chatbot\Chatbot\QuestionsTest.txt").Split("\r\n");
				int length = int.Parse(file[0]);
				QuestionTestPackage[] packages = new QuestionTestPackage[length];

				for (int i = 1; i <= length; i++)
				{
					packages[i - 1] = new QuestionTestPackage(file[i], true);
				}

				QuestionTester tester = new QuestionTester();
				return tester.TestArr(packages);
			}

			else if(context.CleanText == "btest")
			{
                string[] file = File.ReadAllText(
@"C:\Projects\gadshelly\DaviTech\Chatbot\Chatbot\BelongingTest.txt").Split("\r\n");
            }

			else if (context.TellingName)
			{
				if(UserName == null)
				{
					UserName = context.Words[3][0].ToString().ToUpper() + context.Words[3].Substring(0).ToLower();
					return $"Nice to meet you, {UserName}, my name is Megabyte.";
				}
				else
				{
					if (context.Words[3][0].ToString().ToUpper() + context.Words[3].Substring(0).ToLower()
						== UserName) return "Yes, I know...";
					else if(!string.IsNullOrEmpty(UserName))
					{
						string ret = $"I thought your name was {UserName}, but okay.";
						UserName = context.Words[3][0].ToString().ToUpper() + context.Words[3].Substring(0).ToLower();
						return ret;
					}
				}
			}

			else if (context.CleanText == "quit") return "quit";

			return "Amogus";
		}
		public string Respond(string text)
		{
			Context context = Parse(text);
			return Answer(context);
		}
	}
}
