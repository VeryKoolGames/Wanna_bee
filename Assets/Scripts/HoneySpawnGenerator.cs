using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneySpawnGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] honeySpawnMonitors;
    [SerializeField] private int minSwitchTime = 10;
    [SerializeField] private int maxSwitchTime = 15;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnOtherMap());
    }

    private IEnumerator SpawnOtherMap()
    {
        int rand = Random.Range(0, honeySpawnMonitors.Length);
        while (true)
        {
            Instantiate(honeySpawnMonitors[rand], transform.position, Quaternion.identity, transform);
            int old = rand;
            while (rand == old)
                rand = Random.Range(0, honeySpawnMonitors.Length);
            yield return new WaitForSeconds(Random.Range(minSwitchTime, maxSwitchTime));
            // ClearChildren();
            while (transform.childCount > 0) {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
    
    public void ClearChildren()
    {
        Debug.Log("You're in Clear Children");
        
        //Find all transf child (monit)
        GameObject[] allChildren = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            allChildren[i] = transform.GetChild(i).gameObject;
            Debug.Log("transf child : " + i);
        }
        
        //Find all transf child2 (spawn)
        GameObject[] allChildrenTwo = new GameObject[allChildren.Length];
        for (int j = 0; j < allChildren.Length; j++)
        {
            for (int k = 0; k < allChildren.Length; k++)
            {
                allChildrenTwo[k] = allChildren[j].transform.GetChild(k).gameObject;
                Debug.Log("k = " + k);
            }
        }
        
        // Destroy all spawns not having childs 
        for (int k = 0; k < allChildrenTwo.Length; k++)
            if (allChildrenTwo[k].transform.childCount == 0)
            {
                DestroyImmediate(allChildrenTwo[k].transform.GetChild(0).gameObject);
                Debug.Log(k + ": has been destroyed");
            }


        // Destroy all monitors not having childs 
        for (int j = 0; j < allChildren.Length; j++)
            if (allChildren[j].transform.childCount == 0)
            {
                DestroyImmediate(allChildrenTwo[j].transform.GetChild(0).gameObject);
                Debug.Log(j + " has been destroyed");
            }
    }
}
