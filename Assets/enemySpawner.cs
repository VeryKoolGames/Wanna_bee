using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<BoxCollider2D> spawnZones = new List<BoxCollider2D>(1);

    [SerializeField] private float spawningRate = 20f;

    private bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    
    public void StopEnemiesSpawn()
    {
        canSpawn = false;
    }

    public IEnumerator SpawnEnemy()
    {
        while (canSpawn)
        {
            int y = Random.Range(0, spawnZones.Count);
            BoxCollider2D spawnZone = spawnZones[0];
            Vector2 pos = GetRandomPointInCollider(spawnZone);
            Instantiate(enemyPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(spawningRate);
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
}
