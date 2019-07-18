using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Windows.Forms;
using System.Media;



namespace prank.exe
{
    class Program
    {
        public static Random random = new Random();

        public static int begining = 10;
        public static int range = 20;

        /// <param name="args"></param>
        static void Main(string[] args)
        {


            // ta emot argument från cmd
            if (args.Length >= 2)
            {
                begining = Convert.ToInt32(args[0]);
                range = Convert.ToInt32(args[1]);
            }


            Thread thread_mouse = new Thread(new ThreadStart(mus_func));
            Thread thread_keyboard = new Thread(new ThreadStart(tangentbord_func));
            Thread thread_ljud = new Thread(new ThreadStart(ljud_func));
            Thread thread_popupp = new Thread(new ThreadStart(func_popup));

            DateTime interval = DateTime.Now.AddSeconds(begining);
     
            while (interval > DateTime.Now)
            {
                Thread.Sleep(1000);
            }

            // starta trådar
            thread_mouse.Start();
            thread_keyboard.Start();
            thread_ljud.Start();
            thread_popupp.Start();

            interval = DateTime.Now.AddSeconds(range);
            while (interval > DateTime.Now)
            {
                Thread.Sleep(1000);
            }

            Console.WriteLine("avslutar programet");

            // döda trådar
            thread_mouse.Abort();
            thread_keyboard.Abort();
            thread_ljud.Abort();
            thread_popupp.Abort();
        }

        #region Thread Functions

        public static void mus_func()
        {
          

            int moveX = 0;
            int moveY = 0;

            while (true)
            {
                

                if (random.Next(100) > 50)
                {
                    
                    moveX = random.Next(20) - 10;
                    moveY = random.Next(20) - 10;

                    //ger random kordinater till msuen
                    Cursor.Position = new System.Drawing.Point(
                        Cursor.Position.X + moveX,
                        Cursor.Position.Y + moveY);
                }

                Thread.Sleep(50);
            }
        }


        public static void tangentbord_func()
        {
 
            //skriva stora o små bosktäver då o då
            while (true)
            {
                if (random.Next(100) > 95)
                {
                    
                    char key = (char)(random.Next(25) + 65);

                   
                    if (random.Next(2) == 0)
                    {
                        key = Char.ToLower(key);
                    }

                    SendKeys.SendWait(key.ToString());
                }

                Thread.Sleep(random.Next(500));
            }
        }


        public static void ljud_func()
        {
          

            while (true)
            {
                //väljer chansen att ljud sker
                if (random.Next(100) > 60)
                {
                    // väljer typ av ljud
                    switch (random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;
                    }
                }

                Thread.Sleep(1000);
            }
        }


        public static void func_popup()
        {
            

            while (true)
            {
               
                if (random.Next(100) > 50)
                {
                   //visar popupp fönter
                    switch (random.Next(2))
                    {
                        case 0:
                            MessageBox.Show(
                               "Firefox has stopped working",
                                "Firefox",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            break;
                        case 1:
                            MessageBox.Show(
                               "Your system is running low on resources",
                                "Microsoft Windows",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            break;
                    }
                }

                Thread.Sleep(10000);
            }
        }
        #endregion
    }
}