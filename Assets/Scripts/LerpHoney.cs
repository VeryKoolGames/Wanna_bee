using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHoney : MonoBehaviour
{
    private bool startLerping;
    [SerializeField] private float speed = 2f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

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
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed);
        }
    }
}
