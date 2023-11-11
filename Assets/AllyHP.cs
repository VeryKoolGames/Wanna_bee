using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllyHP : MonoBehaviour
{
    [SerializeField] private float hp = 20;
    // Start is called before the first frame update

    private void Start()
    {
        FlowerManager.Register(gameObject.GetInstanceID(), this);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            loseHP();
            Destroy(col.gameObject);
        }
    }

    private void loseHP()
    {
        hp -= 10;
        if (hp <= 0)
        {
            Destroy(gameObject);
            if (tag == "Player")
            {
                SceneManager.LoadScene(2);
            }
        }
    }

}
