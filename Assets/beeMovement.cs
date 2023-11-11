using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class beeMovement : MonoBehaviour
{
    [SerializeField] private float speed = 700f;
    private BoxCollider2D _playerCollider;
    private Vector2 _dest;

    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        _playerCollider = GetComponentInParent<BoxCollider2D>();
        transform.LookAt(GetComponentInParent<Transform>());
        StartCoroutine(moveBee());
    }
    
    public IEnumerator moveBee()
    {
        while (true)
        {
            _dest = GetRandomPointInCollider(_playerCollider);
            yield return new WaitForSeconds(.1f);
        }
    }

    public Vector2 GetRandomPointInCollider(BoxCollider2D boxCollider)
    {
        Vector2 center = boxCollider.bounds.center;
        Vector2 size = boxCollider.bounds.size;

        float randomX = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float randomY = Random.Range(center.y - size.y / 2, center.y + size.y / 2);

        return new Vector2(randomX, randomY);
    }

    private void Update()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, _dest, speed * Time.deltaTime);
    }
}
