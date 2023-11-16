using System.Collections.Generic;
using System.Collections;
using UnityEngine;
public class HoneySpawnMonitor : MonoBehaviour
{
    [SerializeField] private GameObject[] assetsList;
    [SerializeField] private int minPopTime = 5;
    [SerializeField] private int maxPopTime = 7;

    private Dictionary<GameObject, int> spawnDictionary = new Dictionary<GameObject, int>();
    private GameObject[] spawnArray;
    private GameObject[] freeSpawnArray;
    
    private void Start()
    {
        // create spawnDic with all spawnArray
        spawnArray = GameObject.FindGameObjectsWithTag("Spawn");
        for (int i = 0; i < spawnArray.Length; i++)
        {
            spawnDictionary.Add(spawnArray[i], 0);
        }
        StartCoroutine(SpawnHoney());
    }

    private IEnumerator SpawnHoney()
    {
        while (true)
        {
            // instantiate freeSpawnArray length
            int i = 0;
            foreach(KeyValuePair<GameObject, int> entry in spawnDictionary)
            {
                if (entry.Value == 0)
                    i++;
            }
            freeSpawnArray = new GameObject[i]; // isn't it too demanding ?
        
            // populate freeSpawnArray
            i = 0;
            foreach(KeyValuePair<GameObject, int> entry in spawnDictionary)
            {
                if (entry.Value == 0)
                {
                    freeSpawnArray[i] = entry.Key;
                    i++;
                }
            }
        
            // if freeSpawnArray is populated, starts coroutine, deletes freeSpawnArray
            if (freeSpawnArray.Length > 0)
            {
                GameObject theChosenSpawn = freeSpawnArray[Random.Range(0, freeSpawnArray.Length - 1)];
                spawnDictionary[theChosenSpawn] = 1;
                int rand = Random.Range(0, assetsList.Length); // rand in asset array
                Instantiate(assetsList[rand], theChosenSpawn.transform.position, Quaternion.identity); // pops object in spawn position
            }
            yield return new WaitForSeconds( Random.Range( minPopTime, maxPopTime ) );
        }
    }

    public void resetSpawnPoint(GameObject usedSpawn)
    {
        spawnDictionary[usedSpawn] = 0;
    }
}
