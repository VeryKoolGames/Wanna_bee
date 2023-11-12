using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHoney : MonoBehaviour
{
    private bool startLerping;
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform playerPos;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerLerp"))
        {
            startLerping = true;
        }
    }

    void Update()
    {
        if (startLerping)
        {
            transform.position = Vector3.Lerp(transform.position, playerPos.position, Time.deltaTime * speed);
        }
    }
}
