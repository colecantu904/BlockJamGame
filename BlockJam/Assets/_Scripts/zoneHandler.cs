using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class zoneHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent enteredZone;
    [SerializeField]
    private playerMain playerMain;
    private void Awake()
    {
        playerMain = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMain>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            enteredZone.Invoke();
        }
    }
    public void aimLeft()
    {
        playerMain.attackScript.shootLocation.transform.rotation = Quaternion.Euler(0, 0, 90);
        playerMain.attackScript.heavySliceAngle = 90f;
    }
    public void aimRight()
    {
        playerMain.attackScript.shootLocation.transform.rotation = Quaternion.Euler(0, 0, 270);
        playerMain.attackScript.heavySliceAngle = 90f;

    }
    public void aimUp()
    {
        playerMain.attackScript.shootLocation.transform.rotation = Quaternion.Euler(0, 0, 0);
        playerMain.attackScript.heavySliceAngle = 0f;

    }
    public void aimDown()
    {
        playerMain.attackScript.shootLocation.transform.rotation = Quaternion.Euler(0, 0, 180);
        playerMain.attackScript.heavySliceAngle = 0f;

    }
}
