using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class FlowerGAction : MonoBehaviour
{
    private float timeToProduce = 200;
    private float currentState = 0;
    private int beeNumber = 0;
    public bool isReadyToHarvest = false;
    [SerializeField] private List<GameObject> beeUI = new List<GameObject>(5);
    [SerializeField] private GameObject canvasBeeUI;
    [SerializeField] private GameObject canvasHarvestUI;

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
    }
    
    public void HideBeeUI()
    {
        if (!isReadyToHarvest)
        {
            canvasBeeUI.SetActive(false);
        }
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
            res = HoneyState.Ready;
            _startLaunchGrowth();
        }
        if (beeNumber < 5)
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
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
