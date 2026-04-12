using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Lifetime;

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
            AddBotTypingEffect("**************************************************************", ConsoleColor.DarkGreen);
          
            AddBotTypingEffect("[ Welcome to SAFEBUDDY CHATBOT ]", ConsoleColor.Magenta);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            AddBotTypingEffect("**************************************************************", ConsoleColor.DarkGreen);
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

            //do while to re-prompt the user (do something while expecting something to happen)
            do
            {//start of do while 
             //user prompting with text colour 

                //ai chat message and name 
                Console.ForegroundColor = ConsoleColor.Blue;
                AddBotTypingEffect(" SAFEBUDDY : Enter your name: ", ConsoleColor.Blue);
                end_user = Console.ReadLine();

                //reset the color
                Console.ResetColor();


            } while (!isEmpty());//end of do while 

        }//end of ask_name method

        //the boolean method to check if the user entered name
        private bool isEmpty()
        {//start of isEmpty method
            if (!string.IsNullOrWhiteSpace(end_user))
            {//start of if statement
                if (storeValidation(end_user))
                {//start of if statement
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" SAFEBUDDY : ");
                   AddBotTypingEffect("Hey " + end_user, ConsoleColor.DarkBlue);
                    return true;
                   
                }//end of if statement
                Console.ResetColor();
            }//end of if statement

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(" Please write a valid name: ");
            TriggerBeep();
            return false;
        }//end of isEmpty method


        public void ask_question()
        {//start of ask_question method 

            Console.ForegroundColor = ConsoleColor.Blue;
            AddBotTypingEffect("Please Enter Question Related to Cybersecurity . e.g.malware, phishing", ConsoleColor.Blue);
            Console.ResetColor();

            do
            {
               
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(end_user + ": ");
                question = Console.ReadLine();
                exitwords(question);
                if (string.IsNullOrEmpty(question))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("QUESTION CAN NOT BE EMPTY. Please Try Again...");
                    TriggerBeep();
                    Console.ResetColor();
                }
                else
                {
                    Get_Response();
                }
              

            } while (true);
            //once vaildated information is entered , continue
          

           
        }
           
        public void Store_Responses()
        {//start of store response method  

            //Storing into generic 
            //storing triggering words and the response 
            Bot_Response.Add("cybersecurity", "The practice of protecting computers, networks, and data from hackers,attacks, or unauthorized access.");
            Bot_Response.Add("virus","A type of walware that spreads from one computer to another and can damage files or systems.");
            Bot_Response.Add("malware","Harmful software designed to amage or disrupt a computer system.");
            Bot_Response.Add("phishing","A scam where attackers trick you into giving personal information, like passwords through fake emails or websites.");
            Bot_Response.Add("cyberattack", "When someone tries to damage, steal, or gain access to your system or data without permission.");
            Bot_Response.Add("sypware","Sotware that secretly collects information about you without your permission.");
            Bot_Response.Add("ransomware","Malware that locks your files and demands payments to unlock them.");
            Bot_Response.Add("firewall","A security system that monitors and controls incoming and outgoing network traffic.");
            Bot_Response.Add("encryption", "The process of converting information or data into a code to prevent unauthorized access.");
            Bot_Response.Add("safe browsing", "Practices and tools that help protect you from online threats while browsing the internet.");
            Bot_Response.Add("password safety", "Practices and tools that help protect your passwords and personal information.");
            Bot_Response.Add("antivirus software", "Software designed to detect and remove malware from your computer.");
            Bot_Response.Add("social engineering", "Manipulating people into revealing confidential information.");
            Bot_Response.Add("ethical hacking", "The practice of intentionally probing systems for vulnerabilities to improve security.");
            Bot_Response.Add("vulnerability", "A weakness in the system that attacks can exploit.");
            Bot_Response.Add("social engineering", "Manipulating people into revealing confidential information.");
            Bot_Response.Add("identity theft", "The act of stealing someone's personal information to commit fraud.");
            Bot_Response.Add("malicious app", "A harmful application that can damage your device or steal information.");
            Bot_Response.Add("digital footprint", "The trail of data you leave behind when using the internet.");
            Bot_Response.Add("data breach", "An incident where sensitive, protected, or confidential data is accessed or disclosed without authorization.");
            Bot_Response.Add("cyberbullying", "Using technology to harrass or harm others online.");
            Bot_Response.Add("two-factor authentication", "Requires two steps to verify your identification for better security.");
            Bot_Response.Add("VPN", "A virtual private network that helps protect your online privacy and security.");



            Console.ResetColor();
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
            Words_To_Ingore.Add("who");
            Words_To_Ingore.Add("how");
            Words_To_Ingore.Add("when");
            Words_To_Ingore.Add("where");
            Words_To_Ingore.Add("who");
            Words_To_Ingore.Add("and");
            Words_To_Ingore.Add("so");
            Words_To_Ingore.Add("if");
            Words_To_Ingore.Add("i");
            Words_To_Ingore.Add("my");
            Words_To_Ingore.Add("should");
            Words_To_Ingore.Add("would");
            Words_To_Ingore.Add("give");
            Words_To_Ingore.Add("show");
            Words_To_Ingore.Add("help");
            Words_To_Ingore.Add("tell");
            Words_To_Ingore.Add("can");
            Words_To_Ingore.Add("it");
            Words_To_Ingore.Add("because");
            Words_To_Ingore.Add("but");
            Words_To_Ingore.Add("how");
            Words_To_Ingore.Add("was");



        }//end of words to ignore method 

        public void Get_Response()
        {//start of get reponse method 
            //adding a boolean
            bool foundMatch = false;
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
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("SAFEBUDDY : ");
                        AddBotTypingEffect(Response_text, ConsoleColor.Yellow);
                        AddBotTypingEffect("SAFEBUDDY : Let me know if you'd like more assistance refining this further!\nOr please enter (stop/bye/exit/goodbye) to exit the application \n", ConsoleColor.Blue);
                        Console.ResetColor();
                        foundMatch = true;
                    }

                    
                }//end of foreach for keywords 

            }//end of foreach for response 
            if (!foundMatch)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("SAFEBUDDY : ");
                AddBotTypingEffect("Please enter a question related to cybersecurity.", ConsoleColor.Red);
            }
            Console.ResetColor();
        }//end of get response method 

        public bool storeValidation(string name)
        {

            // Checking the length
            if (name.Length < 1)
            {
                AddBotTypingEffect("Name must be at least 1 character.", ConsoleColor.Red);
                Console.ResetColor();
                return false;
            }

            // Checking if all characters are letters
            foreach (char c in name)
            {
                if (!char.IsLetter(c))
                {
                    AddBotTypingEffect("Name must contain only letters.", ConsoleColor.Red);
                    Console.ResetColor();
                    return false;
                }
            }

            // If all checks pass
            return true;
        }

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
                    AddBotTypingEffect("Goodbye, Thank you for using SafeBuddy bot . Hope to see you again.", ConsoleColor.Blue);
                    Console.ResetColor();   
                    System.Environment.Exit(0);
                    check = true;
                }
            }//end of foreach loop 

            return check;
        }


        /*
         *created a method that will trigger a sound when user input is wrong
        passed two parameters the first one is for the frequency, it controls the pitch of the sound
        second parameter is the duration, it is for the time the sound will take
        
         */
        public void TriggerBeep(int frequency = 500, int duration = 1000)
        {
            //used exception Handling
            try
            {
                // This will play a beep with the specified frequency and duration
                Console.Beep(frequency, duration);

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred while playing the beep: {ex.Message}");
            }
        }

        //created a method that changes the Bot typing effect, making it more user friendly
        //passed the message,message color and the speed of the message as parameters
        public void AddBotTypingEffect(string Bot_message, ConsoleColor text_color, int text_speed = 30)// this method parses a string
        {
            Console.ForegroundColor = text_color;
            foreach (char messages in Bot_message)
            {
                Console.Write(messages);
                System.Threading.Thread.Sleep(text_speed); // Adjust speed for effect
            }
            Console.WriteLine();
            Console.ResetColor();
        }


    }//end of public class
}//end of namespace

