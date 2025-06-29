using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class GameManager : BehaviorComponent
{
    public static GameManager Instance { get; private set; }
    public int SlimesCollected { get; set; } = 0;

    public GameManager()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
