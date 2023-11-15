using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

enum ResType
{
    BEE,
    HONEY
}

public class CounterHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI beeCounterText;
    [SerializeField] private TextMeshProUGUI beeUpdateCounterText;
    [SerializeField] private TextMeshProUGUI honeyCounterText;
    [SerializeField] private TextMeshProUGUI honeyUpdateCounterText;
    [SerializeField] private Animator counterUpdateAnim;
    private float animLength = 0.5f;

    private IEnumerator updateCanvas(int oldValue, int addedValue, ResType resType)
    {
        if (resType == ResType.BEE)
        {
            beeUpdateCounterText.text = "+" + addedValue;
            counterUpdateAnim.SetTrigger("updateBeeCanvas");
        }
        else if (resType == ResType.HONEY)
        {
            honeyUpdateCounterText.text = "+" + addedValue;
            counterUpdateAnim.SetTrigger("updateRessourceCanvas");
        }
        yield return new WaitForSeconds(animLength);
        TextMeshProUGUI canvas = resType == ResType.BEE ? beeCounterText : honeyCounterText;
        for (int i = oldValue; i <= oldValue + addedValue; i++)
        {
            canvas.text = i.ToString();
            yield return new WaitForSeconds(.05f);
        }
    }
    
    public void updateBeeCounter(int newValue, int addedValue)
    {
        if (addedValue > 0)
        {
            StartCoroutine(updateCanvas(newValue - addedValue, addedValue, ResType.BEE));
        }
        else
        {
            beeCounterText.text = newValue.ToString();
        }
    }
    
    public void updateHoneyCounter(int newValue, int addedValue)
    {
        if (addedValue > 0)
        {
            StartCoroutine(updateCanvas(newValue - addedValue, addedValue, ResType.HONEY));
        }
        else
        {
            honeyCounterText.text = newValue.ToString();
        }
    }
}
