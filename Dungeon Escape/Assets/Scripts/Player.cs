using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myBody;

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpForce = 5f;
    private bool grounded;
    
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        myBody.velocity = new Vector2(horizontalInput, myBody.velocity.y);
    }
}
