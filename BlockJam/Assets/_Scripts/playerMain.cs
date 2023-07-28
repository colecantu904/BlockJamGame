using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this is a main script that cenrtalizes all interactions between other scripts
// this exponentially helps with orginzaiton, Debugging, and scripting
// to access something fomr another field in a differtn script, call playerMain.<fieldneed>.<component needed>
// more information here https://www.youtube.com/watch?v=_vj1GASSO9U

public class playerMain : MonoBehaviour
{

    void Awake()
    {       

    }

    [SerializeField]
    internal logicScript logicScript;

    [SerializeField]
    internal playerInput playerInput;

    [SerializeField]
    internal playerMove playerMove;

    [SerializeField]
    internal HealthScript HealthScript;

    [SerializeField]
    internal Animator animator;

    [SerializeField]
    internal sceneLoaderScript sceneLoader;

    [SerializeField]
    internal playerAttack attackScript;

    [SerializeField]
    internal playerAnimate playerAnimate;

    [Header("Movement Objects")]
    public SpriteRenderer rend;

    [Header("UI Objects")]
    public int health;



}
