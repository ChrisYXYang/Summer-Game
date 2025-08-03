using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;
using MyMonoGameLibrary;
using System.Diagnostics;

namespace summer_game;

public class GameManager : BehaviorComponent
{
    public static GameManager Instance { get; private set; }

    private int _score;
    public int Score 
    {
        get => _score;
        set
        {
            _score = value;
            _scoreText.Text = "Score: " + _score;
        } 
    }

    private UIText _scoreText;

    public GameManager()
    {

    }

    public override void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            SceneTools.Destroy(this.Parent);
        }
    }

    public override void Start()
    {
        _scoreText = SceneTools.GetGameObject("score text").GetComponent<UIText>();
        Parent.AddChild(_scoreText.Parent);
        _scoreText.Text = "Score: " + _score;
    }
}
