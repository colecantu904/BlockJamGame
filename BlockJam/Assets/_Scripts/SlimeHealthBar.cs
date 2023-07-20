using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;



    public void setHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void barDamage(int damage)
    {
        slider.value -= damage;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
