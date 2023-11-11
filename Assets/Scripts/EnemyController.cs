using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject _target;
    [SerializeField] private float speed = 3f;
    void Start()
    {
        enemyManager.Register(gameObject.GetInstanceID(), this);
        findTarget();
    }
    
    private void findTarget()
    {
        _target = FlowerManager.Instance.getRandomAlly();
    }

    private void Update()
    {
        Transform target = _target.transform;
        Vector2 direction = target.position - transform.position;
        
        
        transform.position =
            Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
