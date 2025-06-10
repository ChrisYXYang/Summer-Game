using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Tools;
using MyMonoGameLibrary.Tilemap;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class Game1 : DebugMode
{
    // variables and properties

    public Game1() : base("Summer Game", 1920, 1080, false) {}

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {   
        // TODO: use this.Content to load your game content here

        // load assets
        SpriteLibrary.AddSpriteSheet("characters", new SpriteSheet("characters"));
        SpriteLibrary.AddTileset("overworld", new Tileset("overworld tileset"));

        // create objects   
        _behaviors.Add(new CameraBehavior());

        Instantiate("overworld");

        Instantiate
        (
            "player", 
            [
            new Transform(),
            new BoxCollider(6, 9),
            new SpriteRenderer(SpriteLibrary.GetSprite("characters", "player_0")),
            new PlayerController(4)
            ]
        );

        Instantiate
        (
            "green", 
            [
            new Transform(new Vector2(1.5f, 3)),
            new BoxCollider(6, 6),
            new SpriteRenderer(SpriteLibrary.GetSprite("characters", "green_1"), Color.White, true, false, 0.2f),
            new Slime(),
            ]
        );

        Instantiate
        (
            "blue",
            [
            new Transform(new Vector2(1.5f, -1.5f)),
            new BoxCollider(6, 6),
            new SpriteRenderer(SpriteLibrary.GetSprite("characters", "blue_1"), Color.White, true, false, 0.2f),
            new Slime(),
            ]
        );

        Instantiate
        (
            "animated green",
            [
            new Transform(new Vector2(-1.5f, -1.5f)),
            new BoxCollider(6, 6),
            new SpriteRenderer(SpriteLibrary.GetSprite("characters", "green_0"), 0.2f),
            new Animator(SpriteLibrary.GetAnimation("characters", "green_slime")),
            new Slime(),
            ]
        );

        Instantiate
        (
            "animated blue",
            [
            new Transform(new Vector2(-1.5f, 1.5f)),
            new BoxCollider(6, 6),
            new SpriteRenderer(SpriteLibrary.GetSprite("characters", "blue_0"), 0.2f),
            new Animator(SpriteLibrary.GetAnimation("characters", "blue_slime")),
            new Slime(),
            ]
        );

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
    
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // set render modes
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

        // debugging
        foreach (GameObject gameObject in _gameObjects.Values)
        {
            DebugMode.DrawOrigin(gameObject);
            DebugMode.DrawBoxCollider(gameObject);
        }

        foreach (TileMap tileMap in _tileMaps.Values)
        {
            DebugMode.DrawTilemapCollider(tileMap);

        }

        base.Draw(gameTime);
    }
}
