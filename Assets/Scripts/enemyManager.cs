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
        Debug.Log(Instance.Enemies.Count);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}