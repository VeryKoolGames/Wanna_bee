using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer treeRenderer;
    [SerializeField] private Sprite baseSprite;
    [SerializeField] private Sprite highlightSprite;
    [SerializeField] private GameObject finalSprite;
    [SerializeField] private GameObject popUp;
    // Start is called before the first frame update

    public void setFinalSprite()
    {
        finalSprite.SetActive(true);
    }
    public void highlightTree()
    {
        popUp.SetActive(true);
        treeRenderer.sprite = highlightSprite;
    }
    
    public void baseTree()
    {
        popUp.SetActive(false);
        treeRenderer.sprite = baseSprite;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
