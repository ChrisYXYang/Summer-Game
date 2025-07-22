using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;
using MyMonoGameLibrary;
using System.Diagnostics;

namespace summer_game;

public class GameManager : BehaviorComponent
{
    public static GameManager Instance { get; private set; }

    public GameManager()
    {

    }

    public override void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            SceneTools.Destroy(this.Parent);
        }
    }
}
