using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;
using MyMonoGameLibrary;
using System.Diagnostics;
using MyMonoGameLibrary.Tools;
using System.Collections.Generic;

namespace summer_game;

public class GameManager : BehaviorComponent
{
    public static GameManager Instance { get; private set; }

    public static int HighScore { get; private set; } = 0;

    private int _score;
    public int Score 
    {
        get => _score;
        set
        {
            _score = value;

            if (_score > HighScore)
            {
                HighScore = _score;
            }

            _scoreText.Text = "High Score: " + HighScore + "\nScore: " + _score;
        } 
    }

    private UIText _scoreText;

    // itemspawn settings
    private float _maxItems = 8;
    private float _itemMin = 8;
    private float _itemMax = 24;
    private List<(Func<PrefabInstance>, float)> _spawnItems = [];
    private List<int> _itemCounts = new List<int> { 0, 0, 0 };

    // enemy spawn settings
    private List<Func<PrefabInstance>> _spawnEnemies = [];
    private int _maxEnemies = 4;
    private float _spawnTime = 2.5f;
    private List<float> _spawnTimers = new List<float> { 0, 0, 0 };
    private List<int> _enemyCounts = new List<int> { 0, 0, 0 };

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

        // what items to spawn
        _spawnItems.Add((Prefabs.SpeedUp, Tools.RandomFloat(_itemMin, _itemMax)));
        _spawnItems.Add((Prefabs.EnhancedThrowing, Tools.RandomFloat(_itemMin, _itemMax)));
        _spawnItems.Add((Prefabs.DoubleDamage, Tools.RandomFloat(_itemMin, _itemMax)));
        _spawnItems.Add((Prefabs.TripleShot, Tools.RandomFloat(_itemMin, _itemMax)));
        _spawnItems.Add((Prefabs.Heart, Tools.RandomFloat(_itemMin, _itemMax)));
        _spawnItems.Add((Prefabs.HalfHeart, Tools.RandomFloat(_itemMin, _itemMax)));

        // which enemies to spawn
        _spawnEnemies.Add(Prefabs.Snowman);
        _spawnEnemies.Add(Prefabs.Iceman);
    }

    public override void Start()
    {
        _scoreText = SceneTools.GetGameObject("score text").GetComponent<UIText>();
        Parent.AddChild(_scoreText.Parent);
        Score = 0;

        // spawn first fish
        int level = Core.Random.Next(1, 4);
        int y = (level - 2) * 10;
        int x = Tools.HalfChance() ? 10 : -10;
        SceneTools.Instantiate(Prefabs.Fish(), new Vector2(x, y)).GetComponent<ScorePickup>().Level = level;
    }

    public override void Update(GameTime gameTime)
    {
        // pause
        if (InputManager.Keyboard.WasKeyJustPressed(Keys.Escape))
        {
            SceneTools.Paused = !SceneTools.Paused;
        }

        // item spawning
        for (int i = 0; i < _spawnItems.Count; i++)
        {
            _spawnItems[i] = (_spawnItems[i].Item1, _spawnItems[i].Item2 - SceneTools.DeltaTime);

            if (_spawnItems[i].Item2 <= 0)
            {
                // determine which levels are available
                List<int> levels = new List<int> { 1, 2, 3 };

                for (int j = 2; j >= 0; j--)
                {
                    if (_itemCounts[j] >= _maxItems)
                    {
                        levels.RemoveAt(j);
                    }
                }

                // spawn the item
                if (levels.Count > 0)
                {
                    int level = levels[Core.Random.Next(levels.Count)];
                    int y = (level - 2) * 10 + 3;
                    float x = Tools.RandomFloat(-14f, 14f);
                    GameObject item = SceneTools.Instantiate(_spawnItems[i].Item1.Invoke(), new Vector2(x, y));

                    HealthPickup healthPickup = item.GetComponent<HealthPickup>();
                    if (healthPickup != null)
                    {
                        healthPickup.Level = level;
                    }

                    BuffPickup buffPickup = item.GetComponent<BuffPickup>();
                    if (buffPickup != null)
                    {
                        buffPickup.Level = level;
                    }


                    _itemCounts[level - 1]++;
                }

                _spawnItems[i] = (_spawnItems[i].Item1, Tools.RandomFloat(_itemMin, _itemMax));
            }
        }

        // enemy spawning
        for (int level = 1; level <= 3; level++)
        {
            if (_enemyCounts[level - 1] < _maxEnemies)
                _spawnTimers[level - 1] -= SceneTools.DeltaTime;

            if (_spawnTimers[level - 1] <= 0)
            {
                int y = (level - 2) * 10 + 3;
                int x = Tools.HalfChance() ? 17 : -17;
                int enemy = Core.Random.Next(_spawnEnemies.Count);
                SceneTools.Instantiate(_spawnEnemies[enemy].Invoke(), new Vector2(x, y)).GetComponent<EnemyBehavior>().Level = level;
                _enemyCounts[level - 1]++;

                _spawnTimers[level - 1] = _spawnTime;
            }
        }
    }

    public void NewFish(int level)
    {
        List<int> levels = new List<int> { 1, 2, 3 };
        levels.RemoveAt(level - 1);
        int newLevel = levels[Core.Random.Next(2)];
        int y = (newLevel - 2) * 10;
        int x = Tools.HalfChance() ? 10 : -10;
        SceneTools.Instantiate(Prefabs.Fish(), new Vector2(x, y)).GetComponent<ScorePickup>().Level = newLevel;
    }

    public void MinusEnemy(int level)
    {
        _enemyCounts[level - 1]--;
    }

    public void MinusItem(int level)
    {
        _itemCounts[level - 1]--;
    }
}
