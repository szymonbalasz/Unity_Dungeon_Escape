using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    [SerializeField] GameObject projectile;

    public override void Hit()
    {
        return;
    }

    public void Attack()
    {
        var shooter = transform.Find("Shooter").transform.position;
        Instantiate(projectile, shooter, Quaternion.identity);
    }
}
