using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerActions : MonoBehaviour
{
    public float beeCounter = 0f; 
    public float ressourceCounter = 20f;

    [SerializeField] private GameObject beeObject;
    private BoxCollider beeSpawnArena;

    private void Start()
    {
        beeSpawnArena = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("ressource"))
        {
            ressourceCounter += 5;
            Destroy(col.gameObject);
        }
    }
    
    private static Vector3 RandomPointInBounds(Bounds bounds) {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ressourceCounter >= 5)
        {
            ressourceCounter -= 5;
            Instantiate(beeObject, RandomPointInBounds(beeSpawnArena.bounds), Quaternion.identity, transform);
        }
    }
}
