using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoaderScript : MonoBehaviour
{

    public Animator sceneAnimator;
    public float transitinTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void deathScene()
    {
        StartCoroutine(loadScene(2));
    }

    public IEnumerator loadScene(int index)
    {
        Debug.Log("loading");
        sceneAnimator.SetTrigger("DeathTransition");

        yield return new WaitForSeconds(transitinTime);

        SceneManager.LoadScene(index);
    }
}
