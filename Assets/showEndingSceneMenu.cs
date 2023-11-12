using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showEndingSceneMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuButtons;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showButtons());
    }
    
    public IEnumerator showButtons()
    {
        yield return new WaitForSeconds(10f);
        menuButtons.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
