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
        // load assets
        SceneSpriteLibrary.AddTileset(this.Content, "overworld tileset");

        // create objects   
        Instantiate("overworld", SceneSpriteLibrary.GetTileset("overworld tileset"));

        Instantiate
        (
            "player",
            [
            new Transform(),
            new CircleCollider(8),
            new SpriteRenderer(Core.GlobalSpriteLibrary.GetSprite("characters", "player_0")),
            new PlayerController(3)
            ]
        );

        Instantiate
        (
            "guide",
            [
            new Transform(),
            new SpriteRenderer(Core.GlobalSpriteLibrary.GetSprite("characters", "player_0"), Color.White * 0.3f),
            ]
        );

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
            "blue",
            [
            new Transform(new Vector2(7f, -3f)),
                        new CircleCollider(6),
            new SpriteRenderer(Core.GlobalSpriteLibrary.GetSprite("characters", "blue_1"), Color.White, true, false, 0.2f),
            new Slime(),
            ]
        );

        Instantiate
        (
            "animated green",
            [
            new Transform(new Vector2(2f, 3f)),
                        new CircleCollider(6),
            new SpriteRenderer(Core.GlobalSpriteLibrary.GetSprite("characters", "green_0"), 0.2f),
            new Animator(Core.GlobalSpriteLibrary.GetAnimation("characters", "green_slime")),
            new Slime(),
            ]
        );

        Instantiate
        (
            "animated blue",
            [
            new Transform(new Vector2(-2f, 3f)),
            new CircleCollider (6),
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
        Core.GraphicsDevice.Clear(Color.CornflowerBlue);

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
