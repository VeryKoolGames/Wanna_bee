using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer treeRenderer;
    [SerializeField] private Sprite baseSprite;
    [SerializeField] private Sprite highlightSprite;
    [SerializeField] private GameObject popUp;
    // Start is called before the first frame update
    
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
    
}
