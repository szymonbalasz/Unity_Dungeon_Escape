using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    //movement
    private Vector3 target, lastPosition;

    //animations
    private Animator anim;
    private const string ANIMATION_IDLE = "Idle";
    private const string ANIMATION_WALK = "Walk";

    private void Start()
    {
        target = pointB.position;
        lastPosition = transform.position;
        anim = GetComponentInChildren<Animator>();
    }

    public override void Update()
    {
        Move();
    }

    private void Move()
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
