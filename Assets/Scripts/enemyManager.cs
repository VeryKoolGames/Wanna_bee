using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public static enemyManager Instance;
    Dictionary<int, EnemyController> Enemies;
    private void Awake()
    {
        Instance = this;
        Enemies = new Dictionary<int, EnemyController>();
    }
    
    public static void Register(int id, EnemyController enemy) {
        if (Instance.Enemies.ContainsKey(id)) {
            Debug.Log("Duplicate registration attempted... " + id.ToString());
            return;
        }
 
        Instance.Enemies.Add(id, enemy);
    }
    
    public void RemoveEnemy(int id)
    {
        Enemies.Remove(id);
    }

    public void ResetTargets()
    {
        foreach (var x in Enemies)
        {
            x.Value.findTarget();
        }
    }
    
    public void KillAllEnemies()
    {
        foreach (var x in Enemies)
        {
            if (x.Value.gameObject)
            {
                Destroy(x.Value.gameObject);
            }
        }
    }
}
