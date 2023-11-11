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
        Debug.Log("Hello I exist" + tag);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("ENNEMY PASSING THROUGH" + tag);
            loseHP();
            Destroy(col.gameObject);
        }
    }

    private void loseHP()
    {
        hp -= 10;
        if (hp <= 0)
        {
            FlowerManager.Remove(gameObject.GetInstanceID());
            enemyManager.Instance.ResetTargets();
            Destroy(gameObject);
            if (tag == "Player")
            {
                SceneManager.LoadScene(2);
            }
        }
    }

}
