using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllyHP : MonoBehaviour
{
    [SerializeField] private float hp = 20;

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
        if (CompareTag("Player"))
        {
            PlayerActions playerActions = gameObject.GetComponent<PlayerActions>();
            if (playerActions.beeCounter > 0)
            {
                createShieldEffect();
                playerActions.removeBees();
            }
        }
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

    private void createShieldEffect()
    {
        throw new NotImplementedException();
    }
}
