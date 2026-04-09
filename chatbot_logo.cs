using System;
using System.Drawing;
using System.IO;

namespace chat_bot_part1
{//start of namespace 
    public class chatbot_logo
    {//start of logo class
        public chatbot_logo()
        {//start of logo constractor

            //setting a path for the logo
            string logo_path = AppDomain.CurrentDomain.BaseDirectory;

            //Replacing full path of the place of Debug\bin\
            string other_path = logo_path.Replace(@"bin\Debug\", "");

            //combaining the paths 
            string file_location = Path.Combine(other_path, "CHATBOT_LOGO.png");

            //Checking whether the logo file exists or not 
            if (!File.Exists(file_location))
            {
                Console.WriteLine("Logo file not found at : " + file_location);
            }

            // Load and resize the image
            Bitmap image = new Bitmap(file_location);
            image = new Bitmap(image, new Size(100, 100));

            //Changing the color
            Console.ForegroundColor = ConsoleColor.Blue;


            // Convert to ASCII and Display the image
            for (int height = 0; height < image.Height; height++)
            {
                for (int width = 0; width < image.Width; width++)
                {
                    Color pixelColor = image.GetPixel(width, height);
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char asciiChar = gray > 200 ? '.' : gray > 150 ? '*' : gray > 100 ? 'o' : gray > 50 ? '#' : '@';
                    Console.Write(asciiChar);
                }
                Console.WriteLine();
            }

            Console.WriteLine();



        }//end of logo constractor
    }// end of logo class
}//end of namespace 