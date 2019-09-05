using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    public int Health { get; set; }

    //stats
    [SerializeField] protected int health, speed, gems;

    //movement
    [SerializeField] protected Transform pointA, pointB;
    protected Vector3 target, lastPosition;

    //animations
    protected Animator anim;
    protected const string 
        ANIMATION_IDLE = "Idle", 
        ANIMATION_WALK = "Walk",
        ANIMATION_HIT = "Hit",
        ANIMATION_DEATH = "Death",
        ANIMATION_INCOMBAT = "InCombat";

    //combat
    protected Player player;
    protected const string PLAYERTAG_STRING = "Player";
    protected bool dead = false;

    private void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        target = pointB.position;
        lastPosition = transform.position;
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag(PLAYERTAG_STRING).GetComponent<Player>();
        Health = health;
    }

    protected virtual void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        if (IsInCombat() || !anim.GetCurrentAnimatorStateInfo(0).IsName(ANIMATION_WALK)) { return; }

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

    public virtual void Hit()
    {
        anim.SetTrigger(ANIMATION_HIT);
    }

    public IEnumerator Death()
    {
        dead = true;
        anim.SetTrigger(ANIMATION_DEATH);
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    private bool IsInCombat()
    {
        if (dead)
        {
            anim.SetBool(ANIMATION_INCOMBAT, false);
            return true;
        }
        float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceFromPlayer < 2.0f)
        {
            anim.SetTrigger(ANIMATION_IDLE);
            anim.SetBool(ANIMATION_INCOMBAT, true);

            Vector3 direction = player.transform.localPosition - transform.localPosition;
            FlipSprite(direction.x);
            if (direction.x < 0) { target = pointA.position; }
            else { target = pointB.position; }

            return true;
        }
        else
        {
            anim.SetBool(ANIMATION_INCOMBAT, false);
            return false;
        }
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
}