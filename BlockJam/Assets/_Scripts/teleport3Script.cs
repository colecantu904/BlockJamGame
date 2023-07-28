using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport3Script : MonoBehaviour
{

    [SerializeField]
    playerMain playerMain;

    [SerializeField]
    Animator animator;

    private float teleportTime = .4f;
    public AnimationClip teleportAnimation;


    // Start is called before the first frame update
    void Start()
    {
        playerMain = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMain.playerInput.teleport3 && playerMain.playerInput.teleport3out)
        {
            playerMain.transform.position = transform.position;
            playerMain.playerMove.destination.transform.position = transform.position;
            StartCoroutine(teleport());
            // need to make a start couroutien for the smoke animation to destroy the game object and set it to false            
        }
    }

    public IEnumerator teleport()
    {
        animator.Play(teleportAnimation.name);

        yield return new WaitForSeconds(teleportTime);

        playerMain.playerInput.teleport3out = false;
        Destroy(gameObject);
    }
}
