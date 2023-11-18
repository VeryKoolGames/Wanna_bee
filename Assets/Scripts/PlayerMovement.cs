using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 23f;

    private Rigidbody2D rb;
    private PlayerActions playerScript;
    private Vector2 movementDirection;
    public Animator animator;

    void Start()
    {
        playerScript = GetComponent<PlayerActions>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("speed", movementDirection.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        float newSpeed = moveSpeed - playerScript.getBeeCounter() / 7;
        if (newSpeed <= 0.5)
        {
            newSpeed = 0.5f;
        }
        rb.velocity = movementDirection * (newSpeed);
    }
}
