using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadSounds : MonoBehaviour
{
    public float impactDelay = .4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playDead());
    }



    public IEnumerator playDead()
    {

        yield return new WaitForSeconds(impactDelay);

        FindObjectOfType<audioManage>().play("hitGround1");
    }
}
