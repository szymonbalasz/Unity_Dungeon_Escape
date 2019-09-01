using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //stats
    [SerializeField] protected int health, speed, gems;

    //movement
    [SerializeField] protected Transform pointA, pointB;
    protected Vector3 target, lastPosition;

    //animations
    protected Animator anim;
    protected const string ANIMATION_IDLE = "Idle";
    protected const string ANIMATION_WALK = "Walk";

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        target = pointB.position;
        lastPosition = transform.position;
        anim = GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        float step = speed * Time.deltaTime;
        bool wait = false;

        if (transform.position == pointA.transform.position)
        {
            anim.SetTrigger(ANIMATION_IDLE);
            wait = true;
            target = pointB.position;
        }
        else if (transform.position == pointB.transform.position)
        {
            anim.SetTrigger(ANIMATION_IDLE);
            wait = true;
            target = pointA.position;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(ANIMATION_IDLE))
        {
            return;
        }

        lastPosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        float deltaMove = transform.position.x - lastPosition.x;

        if (!wait)
        {
            FlipSprite(deltaMove);
            wait = false;
        }
    }

    private void FlipSprite(float d)
    {
        if (d > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (d < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}