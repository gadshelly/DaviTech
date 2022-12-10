using Chatbot;
string userInput;
Conversation conversation = new Conversation();
while (true)
{
    Console.Write("You: ");
    userInput = Console.ReadLine();
    Console.Write("Megabyte: ");
    Console.WriteLine(conversation.Answer(userInput) + "\n");
}