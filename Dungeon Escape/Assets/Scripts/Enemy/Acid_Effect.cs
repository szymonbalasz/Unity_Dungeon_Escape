using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid_Effect : MonoBehaviour
{
    [SerializeField] float timeTillDeath = 5f;
    [SerializeField] float speed = 1f;

    private Vector3 playerDirection;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        playerDirection = player.transform.localPosition - transform.localPosition;
        Destroy(this.gameObject, timeTillDeath);
    }
    void Update()
    {
        if (playerDirection.x < 0)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IDamageable hit = collision.GetComponent<IDamageable>();

            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
