using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        Health--;
        if (Health < 1)
        {
            StartCoroutine(Death());
        }
        else
        {
            Hit();
        }
    }

    public override void Hit()
    {
        return;
    }
}
