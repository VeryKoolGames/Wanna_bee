using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerTRadar : MonoBehaviour
{
    [SerializeField] private GameObject pepino;
    [SerializeField] private float coolDown = 4f;
    [SerializeField] private Animator mAnimator;
    private bool canShoot = true;
    private GameObject target;
    
    IEnumerator blockShooting()
    {
        canShoot = false;
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }

    private void Update()
    {
        if (canShoot && target)
        {
            mAnimator.SetTrigger("shoot");
            AudioManager.Instance.playSound("FT");
            StartCoroutine(blockShooting());
            GameObject ret = Instantiate(pepino, transform.position, Quaternion.identity, transform);
            ret.GetComponent<PepinoController>().setTarget(target); // set target ok
            target = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            target = col.gameObject;
        }
    }
}