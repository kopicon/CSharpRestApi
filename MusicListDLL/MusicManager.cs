using System;
using System.Collections.Generic;
using MusicListEntities;
using static System.Console;


namespace MusicListDAL
{
    public class MusicManager
    {
        
        public static List<Music> allMusics = new List<Music>();

        public static void ShowAllMusics()
        {
            WriteLine("Here you can see all the stored musics:\n");
            
            foreach (var item in allMusics)
            {
                WriteLine($"Id: { item.Id}\n" +
                          $"Name: {item.Name }\n" +
                          $"Style: {item.Style }\n");
            }
            WriteLine("\n");
            Introduction.ExitorNot();
            
        }
        public static void AddSpecificMusic(Music music)
        {
            allMusics.Add(music);           
        }
        public static void AddMusic()
        {
            int id = allMusics.Count + 1;
            WriteLine("The name of the music: \n");
            var name = ReadLine();

            WriteLine("The Style of the music: \n");
            var style = ReadLine();

            allMusics.Add(new Music ()
            {
                Id = id++,
                Name = name,
                Style = style
            });
            
            WriteLine("You successfully added " + name + " to the list");
            Introduction.ExitorNot();
        }
        public static void DeleteMusic(int Id)
        {
            foreach (var music in FakeDataBase.AllSongs)
            {
                if (music.Id == Id)
                {
                    FakeDataBase.AllSongs.Remove(music);
                }
            }
            return null;
        }
        private static Music FindMusicById()
        {
            WriteLine("Insert Music Id: \n");
            int id;
            while (!int.TryParse(ReadLine(), out id))
            {
                    WriteLine("Please insert a number");
            }
            return bllFacade.
        }

            
        public static void EditVideo()
        {
            var Music = FindMusicById();
            WriteLine("Enter the new name of the music:\n");
            Music.Name = ReadLine();
            WriteLine("Enter the new style of the music:\n");
            Music.Style = ReadLine();
            WriteLine("You successfully changed the nem of the music");
            Introduction.ExitorNot();
        }
    }
}
