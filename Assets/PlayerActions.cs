using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerActions : MonoBehaviour
{
    public int beeCounter = 0; 
    public int ressourceCounter = 60;

    [SerializeField] private GameObject beeObject;
    [SerializeField] private GameObject flowerDObject;
    [SerializeField] private GameObject flowerTObject;
    private BoxCollider2D beeSpawnArena;
    private bool _canPlantFlowers = true;
    private bool _canInteractWithFlowers = true;
    private CounterHandler _counterHandler;

    private void Awake()
    {
        _counterHandler = FindObjectOfType<CounterHandler>();
    }

    private void Start()
    {
        _counterHandler.updateHoneyCounter(ressourceCounter);
        _counterHandler.updateBeeCounter(beeCounter);
        beeSpawnArena = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ressource"))
        {
            ressourceCounter += 5;
            _counterHandler.updateHoneyCounter(ressourceCounter);
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("Flower"))
        {
            _canPlantFlowers = false;
            _canInteractWithFlowers = true;
        }
    }
    
    public Vector2 GetRandomPointInCollider(BoxCollider2D boxCollider)
    {
        Vector2 center = boxCollider.bounds.center;
        Vector2 size = boxCollider.bounds.size;

        float randomX = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float randomY = Random.Range(center.y - size.y / 2, center.y + size.y / 2);

        return new Vector2(randomX, randomY);
    }

    private void SpawnFlower()
    {
        if (!(ressourceCounter >= 20) || !_canPlantFlowers) return;
        if (Input.GetKeyDown("1"))
        {
            Instantiate(flowerDObject, GetRandomPointInCollider(beeSpawnArena), Quaternion.identity);
            ressourceCounter -= 20;
            _counterHandler.updateHoneyCounter(ressourceCounter);
        }
        else if (Input.GetKeyDown("2"))
        {
            Instantiate(flowerTObject, GetRandomPointInCollider(beeSpawnArena), Quaternion.identity);
            ressourceCounter -= 20;
            _counterHandler.updateHoneyCounter(ressourceCounter);
        }
    }

    private void SpawnBee()
    {
        if (!Input.GetKeyDown(KeyCode.E) || !(ressourceCounter >= 5)) return;
        ressourceCounter -= 5;
        beeCounter += 1;
        _counterHandler.updateBeeCounter(beeCounter);
        _counterHandler.updateHoneyCounter(ressourceCounter);
        Instantiate(beeObject, GetRandomPointInCollider(beeSpawnArena), Quaternion.identity, transform);
    }
    
    private void FeedFlowers()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || !(_canInteractWithFlowers)) return;
        beeCounter -= 1;
        _counterHandler.updateBeeCounter(beeCounter);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBee();
        SpawnFlower();
        FeedFlowers();
    }
}
