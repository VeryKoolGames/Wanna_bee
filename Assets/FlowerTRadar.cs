using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerTRadar : MonoBehaviour
{
    [SerializeField] private GameObject pepino;
    private Animator mAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponentInParent<Animator>(); // for detect animation
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            // Debug.Log("T: Pepino goo !!!");
            GameObject ret = Instantiate(pepino, transform.position, Quaternion.identity, transform);
            ret.GetComponent<PepinoController>().setTarget(col.gameObject); // set target ok
            if (mAnimator != null)
            {
                mAnimator.SetTrigger("RadarOn");
                // mAnimator.SetTrigger("RadarOff");
            }
        }
    }
}