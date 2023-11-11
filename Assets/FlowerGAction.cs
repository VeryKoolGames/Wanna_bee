using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGAction : MonoBehaviour
{
    private float timeToProduce = 200;
    private float currentState = 0;
    private float beeNumber = 0;
    public bool isReadyToHarvest = false;
    // Start is called before the first frame update

    private void Start()
    {
        startLaunchGrowth();
    }

    public void updateBeeNumber()
    {
        if (beeNumber < 5)
        {
            beeNumber++;
        }
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
