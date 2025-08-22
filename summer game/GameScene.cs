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
        SceneLibrary.AddSoundEffect("bounce");
        SceneLibrary.AddSoundEffect("collect");
        SceneLibrary.AddSoundEffect("crystal0");
        SceneLibrary.AddSoundEffect("crystal1");
        SceneLibrary.AddSoundEffect("crystal2");


        // set up scene
        SetTilemap("level1", SceneLibrary.GetTileset("snowy tileset"));
        Setup(Prefabs.Player(), new Vector2(0, 3.5f));


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
                new Button(Core.GlobalLibrary.GetSprite("ui", "pause"), Core.GlobalLibrary.GetSprite("ui", "pause_h"), () => MenuUI.Instance.Pause())
            ]
        ));

        uiManager.AddChild(Setup
        (
            "resume button",
            [
                new Transform(new Vector2(820, 900)),
                        new UISprite(),
                        new BoxCollider(360, 120),
                        new Button(Core.GlobalLibrary.GetSprite("ui", "resume"), Core.GlobalLibrary.GetSprite("ui", "resume_h"), () => MenuUI.Instance.Resume())
            ]
        ));

        uiManager.AddChild(Setup(Prefabs.DebugButton(), new Vector2(960, 750)));
        uiManager.AddChild(Setup(Prefabs.SoundSetting(), new Vector2(960, 340)));
        uiManager.AddChild(Setup(Prefabs.ParticleButton(), new Vector2(960, 600)));

        uiManager.AddChild(Setup
        (
            "exit",
            [
                new Transform(new Vector2(1160, 900)),
                                new UISprite(),
                                new BoxCollider(200, 120),
                                new Button(Core.GlobalLibrary.GetSprite("ui", "exit"), Core.GlobalLibrary.GetSprite("ui", "exit_h"), () => Core.ChangeScene(new HomeScene()))
            ]
        ));

        uiManager.AddChild(Setup
        (
            "credit",
            [
                new Transform(new Vector2(1760, 1050), Vector2.One * 0.5f, 0f),
                                new UISprite(Core.GlobalLibrary.GetSprite("ui", "credit"))
            ]
        ));

        uiManager.AddChild(Setup
        (
            "game over",
            [
                new Transform(new Vector2(960, 400)),
                new UISprite(Core.GlobalLibrary.GetSprite("ui", "game over"))
            ]
        ));

        uiManager.AddChild(Setup
        (
            "exit",
            [
                new Transform(new Vector2(960, 750)),
                                        new UISprite(),
                                        new BoxCollider(200, 120),
                                        new Button(Core.GlobalLibrary.GetSprite("ui", "exit"), Core.GlobalLibrary.GetSprite("ui", "exit_h"), () => Core.ChangeScene(new HomeScene()))
            ]
        ));

        uiManager.AddChild(Setup
        (
            "retry",
            [
                new Transform(new Vector2(960, 600)),
                                                new UISprite(),
                                                new BoxCollider(280, 120),
                                                new Button(Core.GlobalLibrary.GetSprite("ui", "retry"), Core.GlobalLibrary.GetSprite("ui", "retry_h"), () => Core.ChangeScene(new GameScene()))
            ]
        ));

        base.LoadContent();
    }

    public override void Draw(GameTime gameTime)
    {
        Core.GraphicsDevice.Clear(Color.PaleVioletRed);

        // set render modes
        Core.SpriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

        // debug
        if (Settings.Debug)
        {
            foreach (GameObject gameObject in SceneTools.GetGameDrawObjects())
            {
                if (gameObject.Enabled)
                {
                    Core.DrawOrigin(gameObject);
                    Core.DrawCollider(gameObject);
                }
            }

            foreach (GameObject gameObject in SceneTools.GetUIDrawObjects())
            {
                if (gameObject.Enabled)
                {
                    Core.DrawUIOrigin(gameObject);
                    Core.DrawUICollider(gameObject);
                }
            }
        }

        Core.DrawTilemap = Settings.Debug;

        base.Draw(gameTime);
    }
}
