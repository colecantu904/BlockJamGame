using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script : MonoBehaviour
{
    public Slider slider;



    // function to set health
    public void setHealth(int maxhealth)
    {
        slider.maxValue = maxhealth;
        slider.value = maxhealth;
    }


    // function to reduce health
    public void healthLoss(int damage)
    {
        slider.value -= damage;
        Debug.Log("healthbar");
    }
}
