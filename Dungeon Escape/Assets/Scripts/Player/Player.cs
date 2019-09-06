using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    //stats
    public int Health { get; set; }
    [SerializeField] private int gems = 0;

    private Rigidbody2D myBody;

    //movement
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    private bool resetJump = false;
    private bool grounded = false;

    //animations
    private PlayerAnimation playerAnim;
    private SpriteRenderer playerSprite;

    //combat
    private bool inCombat = false;
    
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        playerSprite = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!inCombat)
        {
            
            Jump();
        }
        Move();
        Attack();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        grounded = isGrounded();
        myBody.velocity = new Vector2(horizontalInput, myBody.velocity.y);
        if (inCombat)
        {
            myBody.velocity = new Vector2(0, 0);
        }
        playerAnim.Move(horizontalInput);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
            playerAnim.Jump(true);
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && grounded)
        {
            playerAnim.Attack();
            inCombat = true;
        }        
    }

    private bool isGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if(hitInfo.collider != null)
        {
            if (resetJump == false)
            {
                playerAnim.Jump(false);
                return true;
            }            
        }
        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }

    public void Damage()
    {
        Debug.Log("Player damaged");
    }

    public void ResetInCombat()
    {
        inCombat = false;
    }

    public void AddGems(int g)
    {
        gems += g;
    }
}
