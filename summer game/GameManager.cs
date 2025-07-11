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
    public int SlimesCollected { get; set; } = 0;

    public GameManager()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private GameObject _test;
    public override void Update(GameTime gameTime)
    {
        if (InputManager.Keyboard.WasKeyJustPressed(Keys.D1))
        {
            _test = SceneTools.Instantiate(Prefabs.Appear());
        }

        if (InputManager.Keyboard.WasKeyJustPressed(Keys.D2))
        {
            SceneTools.Destroy(_test);
        }
    }
}
