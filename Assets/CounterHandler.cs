using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI beeCounterText;
    [SerializeField] private TextMeshProUGUI honeyCounterText;
    // Start is called before the first frame update

    public void updateBeeCounter(int count)
    {
        beeCounterText.text = "bees: " + count;
    }
    
    public void updateHoneyCounter(int count)
    {
        honeyCounterText.text = "honey: " + count;
    }
}
