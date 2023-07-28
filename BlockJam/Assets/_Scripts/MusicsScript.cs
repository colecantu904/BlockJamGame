using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public float introTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playMusic());
    }


    public IEnumerator playMusic()
    {
        FindObjectOfType<audioManage>().play("loopIntro");

        yield return new WaitForSeconds(introTime);

        FindObjectOfType<audioManage>().play("loopMusic");
    }


}
