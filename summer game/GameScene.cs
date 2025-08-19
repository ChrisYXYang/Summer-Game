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

public class GameScene : Scene
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


        Setup
        (
            "Camera Manager",
            [
                new CameraManager()
            ]
        );

        Setup
        (
            "Game Manager",
            [
                new GameManager()
            ]
        ).IgnorePause = true;

        Setup
        (
            "UI Manager",
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
                new PauseButton(Core.GlobalLibrary.GetSprite("ui", "pause"), Core.GlobalLibrary.GetSprite("ui", "pause_h"))
            ]
        );

        Setup
        (
            "resume button",
            [
                new Transform(new Vector2(960, 540)),
                new UISprite(),
                new BoxCollider(360, 120),
                new ResumeButton(Core.GlobalLibrary.GetSprite("ui", "resume"), Core.GlobalLibrary.GetSprite("ui", "resume_h"))
            ]
        );

        Setup
        (
            "score text",
            [
                new Transform(new Vector2(20, 20)),
                new UIText(_big, "", AnchorMode.TopLeft),
            ]
        );

        base.LoadContent();
    }

    public override void Draw(GameTime gameTime)
    {
        Core.GraphicsDevice.Clear(Color.PaleVioletRed);

        // set render modes
        Core.SpriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

        //debugging
        //foreach (GameObject gameObject in GetGameDrawObjects())
        //{
        //    DebugMode.DrawOrigin(gameObject);
        //    DebugMode.DrawCollider(gameObject);
        //}
        //DebugMode.DrawTilemapCollider(Tilemap);

        //foreach (GameObject gameObject in GetUIDrawObjects())
        //{
        //    DebugMode.DrawUICollider(gameObject);
        //}


        base.Draw(gameTime);
    }
}
