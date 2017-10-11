
using System.Collections.Generic;
using System.Linq;
using List.Entities;

namespace List.Repositories
{
    class MusicRepositoriesFakeDB : IMusicRepository
    {
        #region MyRegion
        private static int id = 1;
        private static List<Music> AllSongs = new List<Music>();
        #endregion

        static Music m1 = new Music()
        {
            Id = id++,
            Name = "MachineGunKelly - Sail",
            Style = "Trap"
        };
        static Music m2 = new Music()
        {
            Id = id++,
            Name = "T-Pain - Church",
            Style = "Pop"

        };
        static Music m3 = new Music()
        {
            Id = id++,
            Name = "Copy con - Ganja Mama",
            Style = "Raggie"

        };
        static Music m4 = new Music()
        {
            Id = id++,
            Name = "Pentatonix - Radio Active",
            Style = "Acapella"
        };
        static public void addMusics()
        {
            AllSongs.Add(m1);
            AllSongs.Add(m2);
            AllSongs.Add(m3);
            AllSongs.Add(m4);
        }

        public Music Add(Music music)
        {
            Music newMusic;
            AllSongs.Add(newMusic = new Music()
            {
                Id = id++,
                Name = music.Name,
                Style = music.Style
            });
                return null;
        }

        public Music Delete(int Id)
        {
            {
                var music = GetMusic(Id);
                AllSongs.Remove(music);
                return music;
            }
        }

        public List<Music> GetAllMusic()
        {
            return new List<Music>(AllSongs);
        }

        public Music GetMusic(int Id)
        {
            return AllSongs.FirstOrDefault(x => x.Id == Id);
        }
    }
}
