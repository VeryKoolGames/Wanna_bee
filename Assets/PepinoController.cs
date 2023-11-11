using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepinoController : MonoBehaviour
{
    [SerializeField] private float pepinoSpeed = 3.5f;
    private GameObject _target;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Pepino Target is : " + getTargetTag()); // get target ok
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_target) // when enemy hit an ally before pepino touches it
        {
            Destroy(transform.parent.gameObject);
            return;
        }
        transform.position =
            Vector2.MoveTowards(transform.position, _target.transform.position, pepinoSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Destroy(col.transform.gameObject);
            Debug.Log("P: Enemy Down");
        }
    }

    public void setTarget(GameObject target)
    {
        _target = target;
        Debug.Log("I got set target pepino : " + _target.tag); // this works, but does not seem to save target
    }

    public string getTargetTag()
    {
        return (_target.tag);
    }
    
}
