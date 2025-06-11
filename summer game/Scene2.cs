using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.Tilemap;
using MyMonoGameLibrary.Tools;
using MyMonoGameLibrary;
using Microsoft.Xna.Framework.Input;
using MyMonoGameLibrary.Input;

namespace summer_game;

public class Scene2 : Scene
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
            new BoxCollider(6, 9),
            new SpriteRenderer(Core.GlobalSpriteLibrary.GetSprite("characters", "player_0")),
            new PlayerController(4)
            ]
        );

        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
        if (InputManager.Keyboard.WasKeyJustPressed(Keys.Enter))
            Core.ChangeScene(new Scene1());

        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        Core.GraphicsDevice.Clear(Color.CornflowerBlue);

        // set render modes
        Core.SpriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);


        base.Draw(gameTime);
    }
}
