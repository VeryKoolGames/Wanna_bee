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
    [SerializeField] private Animator beePopupAnimator;
    [SerializeField] private Animator flowerMoveAnimator;
    [SerializeField] private Animator rdyPopupAnimator;
    [SerializeField] private ParticleSystem test;

    private void UpdateBeeUI()
    {
        beeUI[beeNumber].SetActive(true);
    }

    public void ShowBeeUI()
    {
        beePopupAnimator.SetBool("shouldClose", false);
        beePopupAnimator.SetBool("shouldOpen", true);
        spriteRendered.sprite = highlightedSprite;
        spriteRendered.sortingOrder = 5;
    }
    
    public void HideBeeUI()
    {
        beePopupAnimator.SetBool("shouldOpen", false);
        beePopupAnimator.SetBool("shouldClose", true);
        spriteRendered.sprite = normalSprite;
        spriteRendered.sortingOrder = 5;
    }

    private void Start()
    {
        _startLaunchGrowth();
    }

    public HoneyState UpdateBeeNumber()
    {
        HoneyState res = HoneyState.Full;
        if (isReadyToHarvest)
        {
            test.Play();
            res = HoneyState.Ready;
            canvasBeeUI.SetActive(true);
            rdyPopupAnimator.SetBool("isOpen", false);
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
        beePopupAnimator.SetBool("shouldClose", false);
        beePopupAnimator.SetBool("shouldOpen", true);
        flowerMoveAnimator.SetBool("isReady", false);
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
                rdyPopupAnimator.SetBool("isOpen", true);
                flowerMoveAnimator.SetBool("isReady", true);
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
