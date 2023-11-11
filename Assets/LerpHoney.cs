using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHoney : MonoBehaviour
{
    private bool startLerping;
    [SerializeField] private Transform playerPos;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerLerp"))
        {
            Debug.Log("FOUND HIM");
            transform.position = Vector3.Lerp(transform.position, playerPos.position, Time.deltaTime);
            startLerping = true;
        }
    }

    void Update()
    {
        // while (startLerping)
        // {
        //     transform.position = Vector3.Lerp(transform.position, playerPos.position, Time.deltaTime);
        // }
    }
}
