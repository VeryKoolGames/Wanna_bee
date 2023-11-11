using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerActions : MonoBehaviour
{
    public float beeCounter = 0f; 
    public float ressourceCounter = 60f;

    [SerializeField] private GameObject beeObject;
    [SerializeField] private GameObject flowerDObject;
    [SerializeField] private GameObject flowerTObject;

    [SerializeField] private HoneySpawnMonitor spawnMonitor;
    private BoxCollider beeSpawnArena;
    private bool _canPlantFlower = true;
    

    private void Start()
    {
        beeSpawnArena = GetComponent<BoxCollider>();
        spawnMonitor = FindObjectOfType<HoneySpawnMonitor>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Honey"))
        {
            Debug.Log("TOUCHÉ DA HONEY");
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

    private void SpawnFlower()
    {
        if (!(ressourceCounter >= 20) || !_canPlantFlower) return;
        if (Input.GetKeyDown("1"))
        {
            Instantiate(flowerDObject, RandomPointInBounds(beeSpawnArena.bounds), Quaternion.identity);
            ressourceCounter -= 20;
        }
        else if (Input.GetKeyDown("2"))
        {
            Instantiate(flowerTObject, RandomPointInBounds(beeSpawnArena.bounds), Quaternion.identity);
            ressourceCounter -= 20;
        }
    }

    private void SpawnBee()
    {
        if (!Input.GetKeyDown(KeyCode.E) || !(ressourceCounter >= 5)) return;
        ressourceCounter -= 5;
        beeCounter += 1;
        Instantiate(beeObject, RandomPointInBounds(beeSpawnArena.bounds), Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBee();
        SpawnFlower();
    }
}
