using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    public void setHealth(int health)
    {
        slider.value = health;
    }
}
