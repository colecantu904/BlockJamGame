using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour
{
    [SerializeField]
    playerMain playermain;

    // movement variables
    internal float xplayer;
    internal float yplayer;
    internal bool xDown;
    internal bool yDown;

    // attack variables
    internal bool shurikenDown =false;
    internal bool sliceDown = false;
    internal bool heavySliceDown = false;
    internal bool wasdDown = false;
    internal bool attacking = false;
    public KeyCode shuriken = KeyCode.J;
    public KeyCode slice = KeyCode.K;
    public KeyCode heavyslice = KeyCode.L;


    // teleport variables
    internal bool teleport1;
    internal bool teleport2;
    internal bool teleport3;
    public bool teleport1out;
    public bool teleport2out;
    public bool teleport3out;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        xplayer = Input.GetAxisRaw("Horizontal");
        yplayer = Input.GetAxisRaw("Vertical");
        xDown = Input.GetButtonDown("Horizontal");
        yDown =  Input.GetButtonDown("Vertical");

        shurikenDown = Input.GetKeyDown(shuriken);
        sliceDown = Input.GetKeyDown(slice);
        heavySliceDown = Input.GetKeyDown(heavyslice);

        attacking = shurikenDown || sliceDown || heavySliceDown;


        teleport1 = Input.GetKeyDown(KeyCode.U);
        teleport2 = Input.GetKeyDown(KeyCode.I);
        teleport3 = Input.GetKeyDown(KeyCode.O);
    }
}
