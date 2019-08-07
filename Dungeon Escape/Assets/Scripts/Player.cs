using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myBody;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    private bool resetJump = false;
    private bool grounded = false;

    private PlayerAnimation playerAnim;
    private SpriteRenderer playerSprite;
    
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        grounded = isGrounded();
        myBody.velocity = new Vector2(horizontalInput, myBody.velocity.y);
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

}
