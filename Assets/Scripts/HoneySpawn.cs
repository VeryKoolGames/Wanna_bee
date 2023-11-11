using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HoneySpawn : MonoBehaviour
{
    public GameObject[] objects;
    public bool isTriggered;
    
    private void Start()
    {
        StartCoroutine(SpawnHoney());
    }

    private IEnumerator SpawnHoney()
    {
        while (isTriggered)
        {
            int rand = Random.Range(0, objects.Length); // rand in asset array
            yield return new WaitForSeconds( Random.Range( 1,4 ) ); // waits 1 to 4 sec
            Instantiate(objects[rand], transform.position, Quaternion.identity); // pops in fixed position
        }
    }
}