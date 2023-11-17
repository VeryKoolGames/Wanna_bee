using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepinoController : MonoBehaviour
{
    [SerializeField] private float pepinoSpeed = 3.5f;
    private GameObject _target;
    private GameObject _audioManager;

    // Update is called once per frame
    private void Update()
    {
        if (!_target) // when enemy hit an ally before pepino touches it
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                _target.transform.position,
                pepinoSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy")) // only works if rigidbody on enemy !
        {
            AudioManager.Instance.playSound("HitHurt2");
            Destroy(col.transform.gameObject);
            Destroy(gameObject);
        }
    }

    public void setTarget(GameObject target)
    {
        _target = target;
    }
    
}
