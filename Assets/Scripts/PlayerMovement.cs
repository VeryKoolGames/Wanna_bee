using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody rb;
    private Vector2 movementDirection;
    
    CharacterController ch;

    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        ch = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        ch.Move(new Vector3(x,0,z));

    }

    // private void FixedUpdate()
    // {
    //     rb.velocity = movementDirection * moveSpeed;
    // }
}
