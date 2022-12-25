using Chatbot;
using edu.stanford.nlp.parser;
using OpenNLP.Tools.Parser;
using OpenNLP.Tools.Tokenize;
using System.Runtime.CompilerServices;

//TEST();

string userInput;
string response;
Conversation conversation = new Conversation();
while (true)
{
    Console.Write("You: ");
    userInput = Console.ReadLine();
    Console.Write("Megabyte: ");
    response = conversation.Respond(userInput) + '\n';
    if (response == "NOT AMOGUS:(\n")
    {
        Console.WriteLine("Quiting...\n\n");
        Environment.Exit(0);
    }
    Console.WriteLine(response);
}

void TEST()
{
    EnglishTreebankParser parser = new EnglishTreebankParser("test");
    Parse parsed = parser.DoParse("this is just a test");
}