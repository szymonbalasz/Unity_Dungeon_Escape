using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnim, swordAnim;
    private SpriteRenderer playerSprite, playerSwordArc;

    void Start()
    {
        playerAnim = transform.Find("Sprite").GetComponent<Animator>();
        playerSprite = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        //playerSwordArc = transform.Find("Sword_Arc").GetComponent<SpriteRenderer>();
        swordAnim = transform.Find("Sword_Arc").GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void Move(float move)
    {
        FlipSprite(move);
        playerAnim.SetFloat("Move", Mathf.Abs(move));
    }

    private void FlipSprite(float move)
    {
        if (move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move < 0)
        {
           transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Jump(bool jumping)
    {
        playerAnim.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        playerAnim.SetTrigger("Attack");
        
    }
}
