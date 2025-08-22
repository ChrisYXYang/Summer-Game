using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;


namespace summer_game;

public class HowToScene : Scene
{
    public override void Initialize()
    {
        UICamera.Scale = 10;
        base.Initialize();
    }

    public override void LoadContent()
    {
        SceneLibrary.AddSpriteSheet("instructions");
        
        Setup
        (
            "credit",
            [
                new Transform(new Vector2(1760, 1050), Vector2.One * 0.5f, 0f),
                        new UISprite(Core.GlobalLibrary.GetSprite("ui", "credit"))
            ]
        );

        Setup
        (
            "instructions",
            [
                new Transform(new Vector2(960, 540)),
                                new UISprite(SceneLibrary.GetSprite("instructions", "instructions"))
            ]
        );


        Setup
        (
            "back",
            [
                new Transform(new Vector2(1560, 880)),
                        new UISprite(),
                        new BoxCollider(240, 120),
                        new Button(Core.GlobalLibrary.GetSprite("ui", "back"), Core.GlobalLibrary.GetSprite("ui", "back_h"), () => Core.ChangeScene(new HomeScene()))
            ]
        );

        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
        if (InputManager.Keyboard.WasKeyJustPressed(Keys.Escape))
        {
            Core.ChangeScene(new HomeScene());
        }

        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        Core.GraphicsDevice.Clear(Color.PaleVioletRed);

        // set render modes
        Core.SpriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

        // debug
        if (Settings.Debug)
        {
            foreach (GameObject gameObject in SceneTools.GetGameDrawObjects())
            {
                if (gameObject.Enabled)
                {
                    Core.DrawOrigin(gameObject);
                    Core.DrawCollider(gameObject);
                }
            }

            foreach (GameObject gameObject in SceneTools.GetUIDrawObjects())
            {
                if (gameObject.Enabled)
                {
                    Core.DrawUIOrigin(gameObject);
                    Core.DrawUICollider(gameObject);
                }
            }
        }

        Core.DrawTilemap = Settings.Debug;

        base.Draw(gameTime);
    }
}