using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class HomeScene : Scene
{
    public override void Initialize()
    {
        UICamera.Scale = 10;
        base.Initialize();
    }

    public override void LoadContent()
    {
        Setup
        (
            "Title",
            [
                new Transform(new Vector2(960, 240)),
                new UISprite(Core.GlobalLibrary.GetSprite("ui", "title"))
            ]
        );

        Setup
        (
            "play button",
            [
                new Transform(new Vector2(960, 360)),
                new UISprite(),
                new BoxCollider(220, 120),
                new Button(Core.GlobalLibrary.GetSprite("ui", "play"), Core.GlobalLibrary.GetSprite("ui", "play_h"), ()=>Core.ChangeScene(new GameScene()))
            ]
        );

        base.LoadContent();
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
