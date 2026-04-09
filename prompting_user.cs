using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;

namespace chat_bot_part1
{//start of namespace 
    public class prompting_user
    {//start of class


        //global variables
        private string end_user = string.Empty;

        //Declaring a generic 
        Dictionary<string, string> Bot_Response = new Dictionary<string, string>();

        //Declaring a List/generic 
        List<string> Words_To_Ingore = new List<string>();


        string question = string.Empty;

        public prompting_user()
        {//start of prompting user constractor 


        //start of void method prompting_user()

        //display the welcome message with colour text 
        Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("**************************************************************");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" [ Welcome to SAFEBUDDY CHATBOT ]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("**************************************************************");
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            //calling my methods into my contractor, so that the code under the methods can be executed 
            Store_Responses();
            Ingoring_words();
            prompting_name();
            ask_question();

            //reset the color to default , it is a void method ,execute the comment
            Console.ResetColor();

        }//end of void method prompting_user()

        //prompt the user for the user name 
        public void prompting_name()
        {//start of ask_name method 

            //ai chat message and name 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" AI NAME: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Hello, Please enter your name: ");
           

            //reset color
            Console.ResetColor();

            //do while to re-prompt the user (do something while expecting something to happen)
            do
            {//start of do while 
                //user prompting with text colour 

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("USER:");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                end_user = Console.ReadLine();

                //reset the color
                Console.ResetColor();


            } while (!isEmpty());//end of do while 

        }//end of ask_name method

        //the boolean method to check if the user entered name
        private Boolean isEmpty()
        {//start of boolean method 

            //if statement to check if username if empty or not
            if (end_user != "")
            {//start of if statement
                //Return  success message if not empty 
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" AI NAME: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hey " + end_user);

                //return true as they said 
                return true;
            }//end of if statement
            else
            {//start of if else statement

                //error message 
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" AI NAME: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please write your name: ");

                //return false as they said 
                return false;
            }//end of if else statemnt

        }//end of is empty boolean method 


        public void ask_question()
        {//start of ask_question method 

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Hello " + end_user + "Please Enter Question Related to Cybersecurity . e.g.malware, phishing");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(end_user + ": ");
                question = Console.ReadLine();
                exitwords(question);
                if (string.IsNullOrEmpty(question))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("QUESTION CAN NOT BE EMPTY. Please Try Again...");
                }

               
            } while (string.IsNullOrEmpty(question));
            //once vaildated information is entered , continue
            Get_Response();

            Console.ResetColor();
        }
           
        public void Store_Responses()
        {//start of store response method  

            //Storing into generic 
            //storing triggering words and the response 
            Bot_Response.Add("cybersecurity", "The practice of protecting computers, networks, and data from hackers,attacks, or unauthorized access.");
            Bot_Response.Add("virus","A type of walware that spreads from one computer to another and can damage files or systems.");
            Bot_Response.Add("malware","Harmful software designed to amage or disrupt a comppter system.");
            Bot_Response.Add("phishing","A scam where attackers trick you into giving personal information, like passwords through fake emails or websites.");
            Bot_Response.Add("cyberattack", "When someone tries to damage, steal, or gain access to your system or data without permission.");
            Bot_Response.Add("sypware","Sotware that secretly collects information about you without your permission.");
            Bot_Response.Add("ransomware","Malware that locks your files and demands payments to unlock them.");
            Bot_Response.Add("firewall","A security system that monitors and controls incoming and outgoing network traffic.");
        }//end of store response class 


        public void Ingoring_words()
        {//start of words to ingore method 
            Words_To_Ingore.Add("and");
            Words_To_Ingore.Add("or");
            Words_To_Ingore.Add("please");
            Words_To_Ingore.Add("that");
            Words_To_Ingore.Add("about");
            Words_To_Ingore.Add("is");
            Words_To_Ingore.Add("am");
            Words_To_Ingore.Add("thank");
            Words_To_Ingore.Add("give");
            Words_To_Ingore.Add("what");




        }//end of words to ignore method 

        public void Get_Response()
        {//start of get reponse method 

            //store bot response 
            string Response_text = string.Empty;

        
            //spliting and storing the entire question into an array
            string[] response = question.Split(' ');

            //generic that fliter the split words 
            List<string> Flitered_words = new List<string>();
            //joining the flitered words to one line 
            

            foreach (string Word in response)
            {//outter loop
                //foreach loop for looping through the single dimensional array
                if (!Words_To_Ingore.Contains(Word.ToLower()))
                {
                    Flitered_words.Add(Word.ToLower());
                }//end of if 
            }//end of foreach loop

            string clean_input = string.Join(" ", Flitered_words);
            //checking for the response 
            //looping through the responses 
            foreach (var a in Bot_Response)
            {//inner loop
                //array to split the keywords
                string[] keywords = a.Key.Split(',');

                //using a for loop to iterate through the array 
                //iterating through the keywords 
                foreach (string x in keywords)
                {
                    //checking he resonse is found 
                    if (clean_input.Contains(x.ToLower()))
                    {
                        //storing the response by the bot for the user 
                        Response_text += a.Value;
                        Console.Write("Bot: ");
                        Console.WriteLine(Response_text);
                    }
                    else
                    {
                        Console.Write("Bot: ");
                        Console.WriteLine("Please enter a question related to cyber security");
                    } 
                }//end of foreach for keywords 

            }//end of foreach for response 
        }//end of get response method 

        public Boolean exitwords(String user_question)
        {
            Boolean check = false;

            ArrayList user_exit = new ArrayList();

            user_exit.Add("goodbye");
            user_exit.Add("bye");
            user_exit.Add("exit");
            user_exit.Add("quit");
            user_exit.Add("stop");
            user_exit.Add("done");

            foreach (string exit in user_exit)
            {//start of foreach loop
                //checking if the user question consists of exit words 
                if (user_question.Contains(exit))
                {
                    Console.WriteLine("Goodbye, Thank you for using SafeBuddy bot . Hope to see you again.");
                    System.Environment.Exit(0);
                    check = true;
                }
            }//end of foreach loop 

            

            return check;
        }


    }//end of public class
    }//end of namespace

