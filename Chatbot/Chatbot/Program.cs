using Chatbot;
Function func = new Function();
string userInput;
while (true)
{
    Console.Write(func.KnowsName ? func.UserName + ": " : "You: ");
    userInput = Console.ReadLine();
    Console.Write(func.UserKnowsName ? "Megabyte: " : "Chatbot: ");
    Console.WriteLine(func.Answer(userInput) + "\n");
}