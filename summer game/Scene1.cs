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
        SceneLibrary.AddFont("04B_30");
        SceneLibrary.AddFont("04B_30_small");
        _big = SceneLibrary.GetFont("04B_30");
        _small = SceneLibrary.GetFont("04B_30_small");
        SceneLibrary.AddTileset("lab tileset");

        // set up scene
        SetTilemap("level1", SceneLibrary.GetTileset("lab tileset"));
        Setup(Prefabs.Player());

        Setup
        (
            "green",
            [
            new Transform(new Vector2(-7f, -3)),
            new CircleCollider(6, "slime"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "green_1"), Color.White, true, false, 0.2f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "green_slime")),
            new Slime("green"),
            ]
        );

        Setup
        (
            "label",
            [
            new Transform(),
            new TextRenderer(_small, "", AnchorMode.MiddleCenter, Color.LightGreen, 0.2f)
            ]
        );
        GetGameObject("green").AddChild(GetGameObject("label"));

        Setup
        (
            "green_45",
            [
            new Transform(new Vector2(2f, 2f)),
            new CircleCollider(6, "slime"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "green_0"), 0.2f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "green_slime")),
            new Slime("green"),
            ]
        );

        Setup
        (
            "label",
            [
            new Transform(),
                    new TextRenderer(_small, "", AnchorMode.MiddleCenter, Color.LightGreen, 0.2f)
            ]
        );
        GetGameObject("green_1").AddChild(GetGameObject("label_1"));

        Setup
        (
            "blue_10",
            [
            new Transform(new Vector2(7f, -3f)),
            new CircleCollider(6, "slime"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "blue_1"), Color.White, true, false, 0.2f),
                        new Animator(Core.GlobalLibrary.GetAnimation("characters", "blue_slime")),
            new Slime("blue"),
            ]
        );

        Setup
        (
            "label",
            [
            new Transform(),
                            new TextRenderer(_small, "", AnchorMode.MiddleCenter, Color.LightBlue, 0.2f)
            ]
        );
        GetGameObject("blue").AddChild(GetGameObject("label_2"));

        Setup
        (
            "blue1",
            [
            new Transform(new Vector2(-2f, 2f)),
            new CircleCollider(6, "slime"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "blue_0"), 0.2f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "blue_slime")),
            new Slime("blue"),
            ]
        );

        Setup
        (
            "label",
            [
            new Transform(),
            new TextRenderer(_small, "", AnchorMode.MiddleCenter, Color.LightBlue, 0.2f)
            ]
        );
        GetGameObject("blue1").AddChild(GetGameObject("label_3"));

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

        Canvas.AddChild(new TextUI(_big, "", AnchorMode.MiddleLeft, new Vector2(160, 80)));
        Canvas.AddChild(new SpriteUI(Core.GlobalLibrary.GetSprite("characters", "green_0"), Vector2.Zero, Vector2.Zero));
        ((SpriteUI)Canvas.GetChild(1)).AddAnimator(Core.GlobalLibrary.GetAnimation("characters", "green_slime"));
        Canvas.GetChild(1).AddBoxCollider(60,60, 80, 80);
        Canvas.GetChild(1).AddBehavior(new SlimeUIBehavior());
        Canvas.GetChild(0).AddBehavior(new SlimeText());

        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
        if (InputManager.Keyboard.WasKeyJustPressed(Keys.Enter))
        {
            Core.ChangeScene(new Scene2());
            Debug.WriteLine("changing scenes");
        }

        base.Update(gameTime);
    }
    public override void Draw(GameTime gameTime)
    {
        Core.GraphicsDevice.Clear(Color.MediumPurple);

        // set render modes
        Core.SpriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

        // debugging
        foreach (GameObject gameObject in GetGameObjects())
        {
            DebugMode.DrawOrigin(gameObject);
            DebugMode.DrawGameObjectCollider(gameObject);
        }

        DebugMode.DrawTilemapCollider(Tilemap);
        DebugMode.DrawCanvasColliders(Canvas);

        base.Draw(gameTime);
    }
}
