using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllyHP : MonoBehaviour
{
    [SerializeField] private float hp = 20;
    [SerializeField] private enemySpawner _enemySpawner;
    [SerializeField] private GameObject gameOverCanvas;

    private void Start()
    {
        FlowerManager.Register(gameObject.GetInstanceID(), this);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            AudioManager.Instance.playSound("HitHurt1");
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
                playerActions.removeBees();
                return;
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
                _enemySpawner.StopEnemiesSpawn();
                gameOverCanvas.SetActive(true);
            }
        }
    }

}
