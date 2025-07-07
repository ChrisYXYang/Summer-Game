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
using static System.Net.Mime.MediaTypeNames;

namespace summer_game;

public class Game1 : DebugMode
{
    public Game1() : base("Summer Game", 1920, 1080, false) {}

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ChangeScene(new Level1());

        base.Initialize();
    }

    protected override void LoadContent()
    {
        GlobalLibrary.AddSpriteSheet("characters");
        GlobalLibrary.AddFont("04B_30");
        GlobalLibrary.AddFont("04B_30_small");
        GlobalLibrary.AddTileset("lab tileset");

        base.LoadContent();
    }

}
