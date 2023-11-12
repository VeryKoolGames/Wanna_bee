using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject _target;
    [SerializeField] private float speed = 1f;
    void Start()
    {
        enemyManager.Register(gameObject.GetInstanceID(), this);
        findTarget();
    }
    
    public void findTarget()
    {
        if (!_target)
        {
            _target = FlowerManager.Instance.getRandomAlly();
        }
    }

    private void Update()
    {
        if (_target)
        {
            Transform target = _target.transform;
            Vector2 direction = target.position - transform.position;

            transform.position =
                Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            findTarget();
        }
    }
}
