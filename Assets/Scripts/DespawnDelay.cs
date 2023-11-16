using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnDelay : MonoBehaviour
{
    [SerializeField] private float despawnDelay;
    void Start()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(despawnDelay);
        Destroy(this.gameObject);
    }

    
}
