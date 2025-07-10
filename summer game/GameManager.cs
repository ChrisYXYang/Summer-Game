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
    private TextUI _test;
    public override void Update(GameTime gameTime)
    {
        if (InputManager.Keyboard.WasKeyJustPressed(Keys.D1))
        {
            _test = new TextUI(Core.GlobalLibrary.GetFont("04B_30"), "appear!", AnchorMode.MiddleCenter, new Vector2(960, 540));
            SceneTools.Instantiate("test", _test, SceneTools.GetCanvas().GetChild(0));
        }

        if (InputManager.Keyboard.WasKeyJustPressed(Keys.D2))
        {
            SceneTools.Destroy(SceneTools.GetCanvas().GetChild(0));
        }
    }
}
