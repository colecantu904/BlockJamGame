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
        playerMain.shootLocation.transform.rotation = Quaternion.Euler(0, 0, 90);
    }
    public void aimRight()
    {
        playerMain.shootLocation.transform.rotation = Quaternion.Euler(0, 0, 270);

    }
    public void aimUp()
    {
        playerMain.shootLocation.transform.rotation = Quaternion.Euler(0, 0, 0);

    }
    public void aimDown()
    {
        playerMain.shootLocation.transform.rotation = Quaternion.Euler(0, 0, 180);
    }
}
