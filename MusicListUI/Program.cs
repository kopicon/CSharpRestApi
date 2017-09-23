using System;
using static System.Console;
using MusicListBLL;
using MusicListBLL.BusinessObjects;

namespace MusicListUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();
        
        static void Main(string[] args)
        {
            string[] menuItems = {
                "List of all musics",
                "Add music",
                "Delete music",
                "Edit music",
                "Exit"
            };

            var selection = ShowMenu(menuItems);
            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        {
                            ShowAllMusics();
                            break;
                        }
                    case 2:
                        {
                            AddMusic();
                            break;
                        }
                    case 3:
                        {
                            DeletMusic();
                            break;
                        }
                    case 4:
                        {
                            EditMusic();
                            break;
                        }
                    default:
                        break;
                }
            }
            WriteLine("Bye bye!!");
            Environment.Exit(0);
        }
        private static void EditMusic()
        {
            var Music = FindMusicById();
            if (Music != null)
            {
                WriteLine("Enter the new name of the music:\n");
                Music.Name = ReadLine();
                WriteLine("Enter the new style of the music:\n");
                Music.Style = ReadLine();
                WriteLine("You successfully changed the music");
                bllFacade.MusicService.Edit(Music);
            }
            else
            {
                WriteLine("Music not found!");
            }
        }
        public static void ShowAllMusics()
        {
            WriteLine("Here you can see all the stored musics:\n");

            foreach (var item in bllFacade.MusicService.GetAllMusic()) 
            {
                WriteLine($"Id: { item.Id}\n" +
                          $"Name: {item.Name }\n" +
                          $"Style: {item.Style }\n");
            }
            WriteLine("\n");
        }
            private static void AddMusic()
        {
            WriteLine("The name of the music: \n");
            var name = ReadLine();

            WriteLine("The Style of the music: \n");
            var style = ReadLine();

            bllFacade.MusicService.Add(new MusicBO()
            {
                Name = name,
                Style = style
            });
            WriteLine("You successfully added " + name + " to the list");
        }
           
        private static MusicBO FindMusicById()
        {
        WriteLine("Insert Music Id: \n");
        int id;
            while (!int.TryParse(ReadLine(), out id))
            {
                WriteLine("Please insert a number");
            }
            return bllFacade.MusicService.GetMusic(id);
        }

        private static void DeletMusic()
        {
            var musicFound = FindMusicById();
            if (musicFound != null)
            {
                bllFacade.MusicService.Delete(musicFound.Id);
 
            }
            var response = musicFound == null ? "Music not Found!" : "Music was Deleted";
            WriteLine(response);
        }
        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5)
            {
                Console.WriteLine("Please select a number between 1-5");
            }

            return selection;
        }
    }
}

