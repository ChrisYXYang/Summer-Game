using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Tools;
using MyMonoGameLibrary.Tilemap;
using MyMonoGameLibrary.Scenes;
using static System.Net.Mime.MediaTypeNames;

namespace summer_game;

public class Game1 : Core
{
    public Game1() : base("Summer Game", 1920, 1080) {}

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ChangeScene(new HomeScene());
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        GlobalLibrary.AddSpriteSheet("characters");
        GlobalLibrary.AddSpriteSheet("ui");
        GlobalLibrary.AddFont("04B_30");
        GlobalLibrary.AddFont("04B_30_small");
        GlobalLibrary.AddSong("theme");


        Audio.PlaySong(GlobalLibrary.GetSong("theme"));

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        //// debugging purposes
        //if (InputManager.Keyboard.WasKeyJustReleased(Keys.NumPad2))
        //{
        //    List<GameObject> gameObjects = SceneTools.GetGameObjects();
        //    for (int i = 0; i < gameObjects.Count; i++)
        //    {
        //        for (int k = i + 1; k < gameObjects.Count; k++)
        //        {
        //            if (gameObjects[i].Name.Equals(gameObjects[k].Name))
        //            {
        //                throw new Exception("same name");
        //            }
        //        }
        //    }

        //    Debug.WriteLine("all names unique\n");
        //}

        if (InputManager.Keyboard.WasKeyJustPressed(Keys.NumPad0))
        {
            Debugging.PrintScene();
        }

        base.Update(gameTime);
    }
}
