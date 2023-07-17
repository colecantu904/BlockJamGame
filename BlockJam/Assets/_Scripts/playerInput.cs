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

    // attack variables
    internal bool shurikenDown =false;
    internal bool sliceDown = false;
    internal bool heavySliceDown = false;
    internal bool wasdDown = false;
    internal bool attacking = false;
    public KeyCode shuriken = KeyCode.J;
    public KeyCode slice = KeyCode.K;
    public KeyCode heavyslice = KeyCode.L;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xplayer = Input.GetAxisRaw("Horizontal");
        yplayer = Input.GetAxisRaw("Vertical");
        wasdDown = Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical");

        shurikenDown = Input.GetKeyDown(shuriken);
        sliceDown = Input.GetKeyDown(slice);
        heavySliceDown = Input.GetKeyDown(heavyslice);

        attacking = shurikenDown || sliceDown || heavySliceDown;
    }
}
