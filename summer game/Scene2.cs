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
using System.Diagnostics;

namespace summer_game;

public class Scene2 : Scene
{
    public override void LoadContent()
    {
        // load assets
        SceneSpriteLibrary.AddTileset(this.Content, "lab tileset");

        // create objects   
        Instantiate("level1", SceneSpriteLibrary.GetTileset("lab tileset"));

        Instantiate(Prefabs.Player());


        Instantiate
        (
            "guide",
            [
            new Transform(),
            new SpriteRenderer(Core.GlobalSpriteLibrary.GetSprite("characters", "player_0"), Color.White * 0.3f),
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
