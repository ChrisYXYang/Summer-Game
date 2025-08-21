using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class SoundBar : BehaviorComponent
{
    private bool _toggleMusic;
    
    public SoundBar(bool togglemusic)
    {
        _toggleMusic = togglemusic;
    }

    public override void Start()
    {
        
    }
}
