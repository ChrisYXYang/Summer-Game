using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class SoundButton : Press
{
    private bool _left;
    public bool Left
    {
        get => _left;
        set
        {
            _left = value;

            if (_sprite != null)
            {
                if (value)
                {
                    _sprite.FlipX = false;
                }
                else
                {
                    _sprite.FlipX = true;
                }
            }
        }
    }
    public bool Music { get; set; }

    private UISprite _sprite;
    
    public SoundButton(Sprite normal, Sprite hover) : base(normal, hover)
    {
    }

    public override void Awake()
    {
        _sprite = GetComponent<UISprite>();
    }


    public override void Clicked()
    {
        if (Left)
        {
            if (Music)
                Settings.MusicSound--;
            else
                Settings.SFXSound--;
        }
        else
        {
            if (Music)
                Settings.MusicSound++;
            else
                Settings.SFXSound++;
        }
    }
}
