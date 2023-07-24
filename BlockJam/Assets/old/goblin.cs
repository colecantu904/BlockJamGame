using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{

    public int maxhealth = 100;
    private int currenthealth;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamge(int damage)
    {
        currenthealth -= damage;

        if (currenthealth == 0)
        {
            Debug.Log("The Goblin Died");
        } else
        {
            sr.color = Color.black;
        }
    }
}
