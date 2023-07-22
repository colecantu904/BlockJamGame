using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTeleportScript : MonoBehaviour
{
    [SerializeField]
    playerMain playerMain;

    public GameObject Uteleport;
    public GameObject Iteleport;
    public GameObject Oteleport;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        placeTeleport();
    }

    void placeTeleport()
    {
        if (playerMain.playerInput.teleport1 && !playerMain.playerInput.teleport1out)
        {
            Instantiate(Uteleport, playerMain.shootLocation.transform.position, playerMain.transform.rotation);
            playerMain.playerInput.teleport1out = true;
        }
        if (playerMain.playerInput.teleport2 && !playerMain.playerInput.teleport2out)
        {
            Instantiate(Iteleport, playerMain.shootLocation.transform.position, playerMain.transform.rotation);
            playerMain.playerInput.teleport2out = true;
        }
        if (playerMain.playerInput.teleport3 && !playerMain.playerInput.teleport3out)
        {
            Instantiate(Oteleport, playerMain.shootLocation.transform.position, playerMain.transform.rotation);
            playerMain.playerInput.teleport3out = true;
        }
    }
}
