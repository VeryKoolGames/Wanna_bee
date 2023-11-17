using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllyHP : MonoBehaviour
{
    [SerializeField] private int hp = 20;
    [SerializeField] private enemySpawner _enemySpawner;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private int oldId;
    [SerializeField] private PlayerActions playerActions;
    private bool isImmun;
    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        FlowerManager.Register(gameObject.GetInstanceID(), this);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && !isImmun)
        {
            AudioManager.Instance.playSound("HitHurt1");
            loseHP();
            Destroy(col.gameObject);
            enemyManager.Instance.RemoveEnemy(col.gameObject.GetInstanceID());
            isImmun = true;
            StartCoroutine(immunTimer());
        }
    }

    private IEnumerator immunTimer()
    {
        yield return new WaitForSeconds(1f);
        isImmun = false;
    }
    

    private void loseHP()
    {
        if (CompareTag("Player"))
        {
            PlayerActions playerActions = gameObject.GetComponent<PlayerActions>();
            if (playerActions.beeCounter >= 5)
            {
                playerActions.removeBees();
                return;
            }
            hp -= 10 - (2 * playerActions.beeCounter);
            playerActions.removeBees();
            this.playerActions.playHitAnim();
            healthBar.setHealth(hp);
        }
        else
        {
            hp -= 10;
        }
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
