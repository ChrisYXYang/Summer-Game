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
        Setup(Prefabs.Snowman(), new Vector2(7, 0));
        Setup(Prefabs.Iceman(), new Vector2(-7, 0));

        Setup(Prefabs.SpeedUp(), new Vector2(10, 0));
        Setup(Prefabs.EnhancedThrowing(), new Vector2(9, 0));
        Setup(Prefabs.TripleShot(), new Vector2(11, 0));
        Setup(Prefabs.DoubleDamage(), new Vector2(12, 0));
        Setup(Prefabs.SpeedUp(), new Vector2(-10, 0));
        Setup(Prefabs.EnhancedThrowing(), new Vector2(-9, 0));
        Setup(Prefabs.TripleShot(), new Vector2(-11, 0));
        Setup(Prefabs.DoubleDamage(), new Vector2(-12, 0));

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
            "Game Manager",
            [
                new GameManager()
            ]
        );

        Setup
        (
            "UI Manager",
            [
                new HealthUI(),
                new BuffUI(),
            ]
        );

        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {


        base.Update(gameTime);
    }
    public override void Draw(GameTime gameTime)
    {
        Core.GraphicsDevice.Clear(Color.PaleVioletRed);

        // set render modes
        Core.SpriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

        //debugging
        foreach (GameObject gameObject in GetGameObjects())
        {
            DebugMode.DrawOrigin(gameObject);
        }

        foreach (GameObject gameObject in GetGameDrawObjects())
        {
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
