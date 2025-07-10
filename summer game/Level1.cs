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

public class Level1 : Scene
{
    private SpriteFont _big;
    private SpriteFont _small;
    
    public override void LoadContent()
    {
        Gravity = 20f;

        // load assets
        _big = Core.GlobalLibrary.GetFont("04B_30");
        _small = Core.GlobalLibrary.GetFont("04B_30_small");

        // set up scene
        SetTilemap("level1", Core.GlobalLibrary.GetTileset("lab tileset"));
        Setup(Prefabs.Player());
        Setup(Prefabs.OrangePortal());

        Setup
        (
            "Game Manager",
            [
                new GameManager()
            ]
        );

        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
        if (InputManager.Keyboard.WasKeyJustPressed(Keys.NumPad0))
        {
            DebugMode.PrintScene();
        }

        if (InputManager.Keyboard.WasKeyJustPressed(Keys.NumPad1))
        {
            DebugMode.PrintUI();
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

        //DebugMode.DrawTilemapCollider(Tilemap);
        DebugMode.DrawCanvasColliders(Canvas);

        base.Draw(gameTime);
    }
}
