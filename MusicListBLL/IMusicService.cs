using MusicListBLL.BusinessObjects;
using System;
using System.Collections.Generic;


namespace MusicListBLL
{
    public interface IMusicService
    {
        MusicBO GetMusic(int Id);
        List<MusicBO> GetAllMusic();
        MusicBO Add(MusicBO music);
        MusicBO Delete(int Id);
        MusicBO Edit(MusicBO music);    
    }
}
