using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerTRadar : MonoBehaviour
{
    [SerializeField] private GameObject pepino;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy")) // UI : faire un halo de protection autour de FT ?
        {
            Debug.Log("T: Pepino go !!!");
            GameObject ret = Instantiate(pepino, transform.position, Quaternion.identity, transform);
            ret.GetComponent<PepinoController>().setTarget(col.gameObject); // set target ok
        }
    }
}