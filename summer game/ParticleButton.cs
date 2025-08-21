using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class ParticleButton : Button
{
    private Check _check;

    public ParticleButton(Sprite normal, Sprite hover) : base(normal, hover)
    {
    }

    public ParticleButton(Sprite normal, Sprite hover, Sprite press) : base(normal, hover, press)
    {
    }

    public override void Start()
    {
        _check = Parent.GetChild(0).GetComponent<Check>();
        _check.On();

        base.Start();
    }

    public override void Clicked()
    {
        if (Core.Particles)
        {
            Core.Particles = false;
            _check.Off();
        }
        else
        {
            Core.Particles = true;
            _check.On();
        }
    }
}
