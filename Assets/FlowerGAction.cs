using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGAction : MonoBehaviour
{
    private float timeToProduce = 200;
    private float currentState = 0;
    private int beeNumber = 0;
    public bool isReadyToHarvest = false;
    [SerializeField] private List<GameObject> beeUI = new List<GameObject>(5);
    [SerializeField] private GameObject canvasBeeUI;
    // Start is called before the first frame update

    private void updateBeeUI()
    {
        beeUI[beeNumber].SetActive(true);
    }
    
    public void showBeeUI()
    {
        canvasBeeUI.SetActive(true);
    }
    
    public void hideBeeUI()
    {
        canvasBeeUI.SetActive(false);
    }

    private void Start()
    {
        startLaunchGrowth();
    }

    public bool updateBeeNumber()
    {
        if (beeNumber < 5)
        {
            updateBeeUI();
            beeNumber++;
            return true;
        }

        return false;
    }

    public void startLaunchGrowth()
    {
        isReadyToHarvest = true;
        StartCoroutine(launchGrowthTimer());
    }
    
    public IEnumerator launchGrowthTimer()
    {
        while (!isReadyToHarvest)
        {
            currentState += 10 * (1 + beeNumber);
            if (currentState >= timeToProduce)
            {
                isReadyToHarvest = true;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
