using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health, speed, gems;
    [SerializeField] protected Transform pointA, pointB;

    public virtual void Attack()
    {

    }

    public abstract void Update();
}