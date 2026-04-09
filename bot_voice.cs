using System;
using System.IO;
using System.Media;

namespace chat_bot_part1
{//start of namespace 
    public class bot_voice
    {//start of bot voice class

        //global variable
        //autopath
        string botpath = AppDomain.CurrentDomain.BaseDirectory;

        public bot_voice()
        {//start of bot voice constractor

            //call the voice method 
            botvoice();

        }//end of greetVoice class, constractor



        //method to voice greet the user
        private void botvoice()
        { // start of void method 

            //get the full path of the place of Debug\bin\
            string fullpath = botpath.Replace(@"bin\Debug\", "");

            //play the sound 
            string comabined_path = fullpath + "cybersecurity_ai.wav";

            //create an instance for the soundplay class 
            SoundPlayer voice_player = new SoundPlayer(comabined_path);

            //load the audio 
            voice_player.Load();

            //play till the end 
            voice_player.PlaySync();

        }//end of bot_voice constractor
    }//end of bot voice class
}//end of namespace 