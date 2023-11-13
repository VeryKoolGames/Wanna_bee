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
    
    IEnumerator blockShooting()
    {
        canShoot = false;
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && canShoot)
        {
            AudioManager.Instance.playSound("FT");
            GameObject ret = Instantiate(pepino, transform.position, Quaternion.identity, transform);
            ret.GetComponent<PepinoController>().setTarget(col.gameObject); // set target ok
            StartCoroutine(blockShooting());
            mAnimator.SetTrigger("shoot");
        }
    }
}