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
        SceneLibrary.AddTileset("lab tileset");

        // create objects   
        SetTilemap("level1", SceneLibrary.GetTileset("lab tileset"));

        Instantiate(Prefabs.Player());


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
