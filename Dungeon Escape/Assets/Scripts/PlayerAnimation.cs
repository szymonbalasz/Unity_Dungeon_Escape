using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnim;
    private SpriteRenderer playerSprite;

    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
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
}
