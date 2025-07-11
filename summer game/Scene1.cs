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
    
    public override void LoadContent()
    {
        Gravity = 20f;

        // load assets
        _big = Core.GlobalLibrary.GetFont("04B_30");
        _small = Core.GlobalLibrary.GetFont("04B_30_small");
        SceneLibrary.AddTileset("lab tileset");

        // set up scene
        SetTilemap("level1", SceneLibrary.GetTileset("lab tileset"));
        Setup(Prefabs.Player());

        Setup
        (
            "green",
            [
            new Transform(new Vector2(-7f, -3)),
            new CircleCollider(Converter.PixelToUnit(6), "slime"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "green_1"), Color.White, true, false, 0.2f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "green_slime")),
            new Slime("green"),
            ]
        );

        Setup(Prefabs.Label(), GetGameObject("green"));

        Setup
        (
            "green_45",
            [
            new Transform(new Vector2(2f, 2f)),
            new CircleCollider(Converter.PixelToUnit(6), "slime"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "green_0"), 0.2f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "green_slime")),
            new Slime("green"),
            ]
        );

        Setup(Prefabs.Label(), GetGameObject("green_1"));

        Setup
        (
            "blue_10",
            [
            new Transform(new Vector2(7f, -3f)),
            new CircleCollider(Converter.PixelToUnit(6), "slime"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "blue_1"), Color.White, true, false, 0.2f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "blue_slime")),
            new Slime("blue"),
            ]
        );

        Setup(Prefabs.Label(), GetGameObject("blue"));

        Setup
        (
            "blue1",
            [
            new Transform(new Vector2(-2f, 2f)),
            new CircleCollider(Converter.PixelToUnit(6), "slime"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "blue_0"), 0.2f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "blue_slime")),
            new Slime("blue"),
            ]
        );

        Setup(Prefabs.Label(), GetGameObject("blue1"));

        GameObject playerLabel = Setup(Rename("player label", Prefabs.Label()), GetGameObject("player"));
        ((TextRenderer)playerLabel.Renderer).Text = "Player!";

        Setup
        (
            "Camera Manager",
            [
                new CameraBehavior()
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
            "text",
            [
                new Transform(new Vector2(160, 80)),
                new UIText(_big, "", AnchorMode.MiddleLeft),
                new SlimeText(),
                new TextCollider(20,10),
                new BoxCollider()
            ]
        );

        Setup
        (
            "icon",
            [
                new Transform(Vector2.Zero),
                new UISprite(Core.GlobalLibrary.GetSprite("characters", "green_0"), Vector2.Zero),
                new UIAnimator(Core.GlobalLibrary.GetAnimation("characters", "green_slime")),
                new SlimeUIBehavior(),
                new BoxCollider(60, 60, 80, 80, "ui")
            ]
        );

        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
        //if (InputManager.Keyboard.WasKeyJustPressed(Keys.Enter))
        //{
        //    Core.ChangeScene(new Scene2());
        //    Debug.WriteLine("changing scenes");
        //}

        base.Update(gameTime);
    }
    public override void Draw(GameTime gameTime)
    {
        Core.GraphicsDevice.Clear(Color.MediumPurple);

        // set render modes
        Core.SpriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

        // debugging
        foreach (GameObject gameObject in GetGameDrawObjects())
        {
            DebugMode.DrawOrigin(gameObject);
            DebugMode.DrawCollider(gameObject);
        }

        foreach (GameObject gameObject in GetUIDrawObjects())
        {
            DebugMode.DrawUICollider(gameObject);
        }

        DebugMode.DrawTilemapCollider(Tilemap);

        base.Draw(gameTime);
    }
}
