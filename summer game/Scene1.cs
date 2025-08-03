using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.Tilemap;
using MyMonoGameLibrary.Tools;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Input;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class Scene1 : Scene
{
    private SpriteFont _big;
    private SpriteFont _small;

    public override void Initialize()
    {
        Gravity = 25f;
        UICamera.Scale = 10;
        //Camera.PixelScale = 4;
        base.Initialize();
    }
    
    public override void LoadContent()
    {
        // load assets
        _big = Core.GlobalLibrary.GetFont("04B_30");
        _small = Core.GlobalLibrary.GetFont("04B_30_small");
        SceneLibrary.AddTileset("snowy tileset");

        // set up scene
        SetTilemap("level1", SceneLibrary.GetTileset("snowy tileset"));
        Setup(Prefabs.Player());
        Setup(Prefabs.Snowman(), new Vector2(7, 0)).GetComponent<EnemyBehavior>().Level = 2;
        Setup(Prefabs.Iceman(), new Vector2(-7, 0)).GetComponent<EnemyBehavior>().Level = 2;
        Setup(Prefabs.Snowman(), new Vector2(7, 12)).GetComponent<EnemyBehavior>().Level = 1;
        Setup(Prefabs.Iceman(), new Vector2(-7, 12)).GetComponent<EnemyBehavior>().Level = 1;
        Setup(Prefabs.Snowman(), new Vector2(7, -12)).GetComponent<EnemyBehavior>().Level = 3;
        Setup(Prefabs.Iceman(), new Vector2(-7, -12)).GetComponent<EnemyBehavior>().Level = 3;

        Setup(Prefabs.SpeedUp(), new Vector2(10, 0));
        Setup(Prefabs.EnhancedThrowing(), new Vector2(9, 0));
        Setup(Prefabs.TripleShot(), new Vector2(11, 0));
        Setup(Prefabs.DoubleDamage(), new Vector2(12, 0));
        Setup(Prefabs.SpeedUp(), new Vector2(-10, 0));
        Setup(Prefabs.EnhancedThrowing(), new Vector2(-9, 0));
        Setup(Prefabs.TripleShot(), new Vector2(-11, 0));
        Setup(Prefabs.DoubleDamage(), new Vector2(-12, 0));
        Setup(Prefabs.Fish(), new Vector2(14, 0));


        //Setup(Prefabs.TestDummy(), new Vector2(-7, 0));


        Setup
        (
            "Camera Manager",
            [
                new CameraManager()
            ]
        );

        Setup
        (
            "game manager",
            [
                new GameManager()
            ]
        );

        Setup
        (
            "ui manager",
            [
                new HealthUI(),
                new BuffUI(),
            ]
        );

        Setup
        (
            "pause button",
            [
                new Transform(new Vector2(1840, 80)),
                new UISprite(),
                new BoxCollider(80, 80),
                new PauseButton()
            ]
        );

        Setup
        (
            "resume button",
            [
                new Transform(new Vector2(960, 540)),
                new UISprite(),
                new BoxCollider(360, 120),
                new ResumeButton()
            ]
        );

        Setup
        (
            "score text",
            [
                new Transform(new Vector2(20, 40)),
                new UIText(_big, "", AnchorMode.MiddleLeft),
            ]
        );

        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
        if (InputManager.Keyboard.WasKeyJustPressed(Keys.Escape))
        {
            SceneTools.Paused = !SceneTools.Paused;
        }

        base.Update(gameTime);
    }
    public override void Draw(GameTime gameTime)
    {
        Core.GraphicsDevice.Clear(Color.PaleVioletRed);

        // set render modes
        Core.SpriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

        //debugging
        foreach (GameObject gameObject in GetGameDrawObjects())
        {
            DebugMode.DrawOrigin(gameObject);
            DebugMode.DrawCollider(gameObject);
        }
        DebugMode.DrawTilemapCollider(Tilemap);

        //foreach (GameObject gameObject in GetUIDrawObjects())
        //{
        //    DebugMode.DrawUICollider(gameObject);
        //}

        if (InputManager.Keyboard.WasKeyJustPressed(Keys.NumPad0))
        {
            DebugMode.PrintScene();
        }


        base.Draw(gameTime);
    }
}
