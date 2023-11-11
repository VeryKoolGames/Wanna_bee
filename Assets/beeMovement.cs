using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeMovement : MonoBehaviour
{
    [SerializeField] private float speed = 70f;

    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(GetComponentInParent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(GetComponentInParent<Transform>().position, Vector3.up, speed * Time.deltaTime);
    }
}
