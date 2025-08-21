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
        );

        Setup
        (
            "score text",
            [
                new Transform(new Vector2(20, 20)),
                        new UIText(Core.GlobalLibrary.GetFont("04B_30"), "", AnchorMode.TopLeft, Color.Navy),
            ]
        );

        GameObject uiManager = Setup
        (
            "UI Manager",
            [
                new HealthUI(),
                new BuffUI(),
                new MenuUI()
            ]
        );

        uiManager.AddChild(Setup
        (
            "pause button",
            [
                new Transform(new Vector2(1840, 80)),
                new UISprite(),
                new BoxCollider(80, 80),
                new PauseButton(Core.GlobalLibrary.GetSprite("ui", "pause"), Core.GlobalLibrary.GetSprite("ui", "pause_h"))
            ]
        ));

        uiManager.AddChild(Setup
        (
            "resume button",
            [
                new Transform(new Vector2(960, 900)),
                        new UISprite(),
                        new BoxCollider(360, 120),
                        new ResumeButton(Core.GlobalLibrary.GetSprite("ui", "resume"), Core.GlobalLibrary.GetSprite("ui", "resume_h"))
            ]
        ));

        uiManager.AddChild(Setup(Prefabs.DebugButton(), new Vector2(960, 750)));
        uiManager.AddChild(Setup(Prefabs.SoundSetting(), new Vector2(960, 340)));
        uiManager.AddChild(Setup(Prefabs.ParticleButton(), new Vector2(960, 600)));





        base.LoadContent();
    }

    public override void Draw(GameTime gameTime)
    {
        Core.GraphicsDevice.Clear(Color.PaleVioletRed);

        // set render modes
        Core.SpriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

        base.Draw(gameTime);
    }
}
