using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void barDamage(int damage)
    {
        slider.value -= damage;
        Debug.Log("hit");
    }
}
