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

namespace summer_game;

public class Scene1 : Scene
{
    public override void LoadContent()
    {
        Gravity = 20f;
        
        // load assets
        SceneSpriteLibrary.AddTileset(this.Content, "lab tileset");

        // create objects   
        Instantiate("level1", SceneSpriteLibrary.GetTileset("lab tileset"));

        Instantiate(Prefabs.Player());



        Instantiate
        (
            "green",
            [
            new Transform(new Vector2(-7f, -3)),
            new CircleCollider(6),
            new SpriteRenderer(Core.GlobalSpriteLibrary.GetSprite("characters", "green_1"), Color.White, true, false, 0.2f),
            new Slime(),
            ]
        );

        Instantiate
        (
            "green_45",
            [
            new Transform(new Vector2(2f, 2f)),
            new CircleCollider(6),
            new SpriteRenderer(Core.GlobalSpriteLibrary.GetSprite("characters", "green_0"), 0.2f),
            new Animator(Core.GlobalSpriteLibrary.GetAnimation("characters", "green_slime")),
            new Slime(),
            ]
        );

        Instantiate
        (
            "blue_10",
            [
            new Transform(new Vector2(7f, -3f)),
            new CircleCollider(6),
            new SpriteRenderer(Core.GlobalSpriteLibrary.GetSprite("characters", "blue_1"), Color.White, true, false, 0.2f),
            new Slime(),
            ]
        );


        Instantiate
        (
            "blue1",
            [
            new Transform(new Vector2(-2f, 2f)),
            new CircleCollider(6),
            new SpriteRenderer(Core.GlobalSpriteLibrary.GetSprite("characters", "blue_0"), 0.2f),
            new Animator(Core.GlobalSpriteLibrary.GetAnimation("characters", "blue_slime")),
            new Slime(),
            ]
        );

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

        foreach (TileMap tileMap in GetTileMaps())
        {
            DebugMode.DrawTilemapCollider(tileMap);
        }

        base.Draw(gameTime);
    }
}
