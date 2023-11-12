using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class FlowerGAction : MonoBehaviour
{
    [SerializeField] private float timeToProduce = 200f;
    private float currentState = 0;
    private int beeNumber = 0;
    public bool isReadyToHarvest = false;
    [SerializeField] private List<GameObject> beeUI = new List<GameObject>(5);
    [SerializeField] private GameObject canvasBeeUI;
    [SerializeField] private GameObject canvasHarvestUI;
    [SerializeField] private Sprite highlightedSprite;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private SpriteRenderer spriteRendered;
    // [SerializeField] private Animator beePopupAnimator;
    // [SerializeField] private Animator flowerMoveAnimator;
    // [SerializeField] private Animator rdyPopupAnimator;

    private void UpdateBeeUI()
    {
        beeUI[beeNumber].SetActive(true);
    }

    public void ShowBeeUI()
    {
        if (!isReadyToHarvest)
        {
            canvasBeeUI.SetActive(true);
        }
        // beePopupAnimator.SetBool("shouldClose", false);
        // beePopupAnimator.SetBool("shouldOpen", true);
        spriteRendered.sprite = highlightedSprite;
        spriteRendered.sortingOrder = 5;
    }
    
    public void HideBeeUI()
    {
        // canvasBeeUI.SetActive(true);
        // beePopupAnimator.SetBool("shouldOpen", false);
        // beePopupAnimator.SetBool("shouldClose", true);
        // yield return new WaitForSeconds(.4f);
        if (!isReadyToHarvest)
        {
            canvasBeeUI.SetActive(false);
        }
        spriteRendered.sprite = normalSprite;
        spriteRendered.sortingOrder = 5;
        // StartCoroutine(LaunchCloseAnim());
    }
    
    // private IEnumerator LaunchCloseAnim()
    // {
    //     canvasBeeUI.SetActive(true);
    //     // beePopupAnimator.SetBool("shouldOpen", false);
    //     // beePopupAnimator.SetBool("shouldClose", true);
    //     yield return new WaitForSeconds(.4f);
    //     if (!isReadyToHarvest)
    //     {
    //         canvasBeeUI.SetActive(false);
    //     }
    //     spriteRendered.sprite = normalSprite;
    // }

    private void Start()
    {
        _startLaunchGrowth();
    }

    public HoneyState UpdateBeeNumber()
    {
        HoneyState res = HoneyState.Full;
        if (isReadyToHarvest)
        {
            res = HoneyState.Ready;
            _startLaunchGrowth();
        }
        else if (beeNumber < 5)
        {
            UpdateBeeUI();
            beeNumber++;
            res = HoneyState.Added;
        }

        return res;
    }

    private void _startLaunchGrowth()
    {
        currentState = 0;
        isReadyToHarvest = false;
        canvasBeeUI.SetActive(true);
        canvasHarvestUI.SetActive(false);
        // beePopupAnimator.SetBool("shouldClose", false);
        // beePopupAnimator.SetBool("shouldOpen", true);
        // flowerMoveAnimator.SetBool("isReady", false);
        // rdyPopupAnimator.SetTrigger("isDone");
        StartCoroutine(LaunchGrowthTimer());
    }

    private IEnumerator LaunchGrowthTimer()
    {
        while (!isReadyToHarvest)
        {
            currentState += 10 * (1 + beeNumber);
            if (currentState >= timeToProduce)
            {
                isReadyToHarvest = true;
                canvasBeeUI.SetActive(false);
                canvasHarvestUI.SetActive(true);
                // flowerMoveAnimator.SetBool("isReady", true);
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
