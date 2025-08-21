using System;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.UI;
using System.Diagnostics;


namespace summer_game;

public class SoundBar : BehaviorComponent
{
    private bool _music;
    public bool Music
    {
        get => _music;
        set
        {
            _music = value;
            
            if (_left != null)
                _left.Music = value;
           
            if (_right != null)
                _right.Music = value;
        }
    }

    private UISprite _sprite;
    private SoundButton _left;
    private SoundButton _right;
    private Sprite _1;
    private Sprite _2;
    private Sprite _3;
    private Sprite _4;
    private Sprite _5;

    public SoundBar(bool music)
    {
        Music = music;
    }

    public override void Awake()
    {
        _sprite = GetComponent<UISprite>();
        _1 = Core.GlobalLibrary.GetSprite("ui", "1");
        _2 = Core.GlobalLibrary.GetSprite("ui", "2");
        _3 = Core.GlobalLibrary.GetSprite("ui", "3");
        _4 = Core.GlobalLibrary.GetSprite("ui", "4");
        _5 = Core.GlobalLibrary.GetSprite("ui", "5");

        _left = SceneTools.Instantiate(Prefabs.SoundButton(), new Vector2(-120, 0), 0f, Parent).GetComponent<SoundButton>();
        _left.Left = true;

        _right = SceneTools.Instantiate(Prefabs.SoundButton(), new Vector2(130, 0), 0f, Parent).GetComponent<SoundButton>();
        _right.Left = false;

        Music = Music;
    }

    public override void Update(GameTime gameTime)
    {
        if (Music)
        {
            if (Settings.MusicSound > 0)
            {
                _sprite.IsVisible = true;

                switch (Settings.MusicSound)
                {
                    case 1:
                        _sprite.Sprite = _1;
                        break;
                    case 2:
                        _sprite.Sprite = _2;
                        break;
                    case 3:
                        _sprite.Sprite = _3;
                        break;
                    case 4:
                        _sprite.Sprite = _4;
                        break;
                    case 5:
                        _sprite.Sprite = _5;
                        break;
                }
            }
            else
            {
                _sprite.IsVisible = false;
            }
        }
        else
        {
            if (Settings.SFXSound > 0)
            {
                _sprite.IsVisible = true;

                switch (Settings.SFXSound)
                {
                    case 1:
                        _sprite.Sprite = _1;
                        break;
                    case 2:
                        _sprite.Sprite = _2;
                        break;
                    case 3:
                        _sprite.Sprite = _3;
                        break;
                    case 4:
                        _sprite.Sprite = _4;
                        break;
                    case 5:
                        _sprite.Sprite = _5;
                        break;
                }
            }
            else
            {
                _sprite.IsVisible = false;
            }
        }
    }
}
