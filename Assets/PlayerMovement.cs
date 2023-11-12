using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 23f;

    private Rigidbody2D rb;
    private PlayerActions playerScript;
    private bool canMove = true;

    private Vector2 movementDirection;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("MapLimit"))
        {
            canMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MapLimit"))
        {
            canMove = true;
        }
    }

    void Start()
    {
        playerScript = GetComponent<PlayerActions>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = movementDirection * (moveSpeed - playerScript.getBeeCounter() / 3);
        }
    }
}
