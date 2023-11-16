using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private GameObject _target;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject destroyParticles;
    private bool isQuitting;

    public void setIsQuitting(bool value)
    {
        isQuitting = value;
    }
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

    void OnApplicationQuit()
    {
        isQuitting = true;
    }


    private void OnDestroy()
    {
        if (!isQuitting && Time.timeScale != 0f)
        {
            Instantiate(destroyParticles, transform.position, Quaternion.identity);
        }
    }
}
