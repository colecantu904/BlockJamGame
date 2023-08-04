using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyClass : MonoBehaviour
{
    [SerializeField] logicScript logicScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public int updateHealth(int currHealth, int damage, GameObject healthBar)
    {
        currHealth -= damage;

        return currHealth;
    }

    public int setHealth(int maxHealth, int currHealth, GameObject healthBar)
    {
        // this function should aslo set the health bar UI
        currHealth = maxHealth;


        return currHealth;
    }

    




}
