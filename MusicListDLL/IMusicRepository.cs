using List.Entities;
using System.Collections.Generic;


namespace List
{
    public interface IMusicRepository
    {
        Music GetMusic(int Id);
        List<Music> GetAllMusic();
        Music Add(Music music);
        Music Delete(int Id);
        //no Update because UnitOfWork will do update.
    }
}

