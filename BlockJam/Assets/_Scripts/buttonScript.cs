using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{

    public void replay()
    {
        SceneManager.LoadScene(1);
    }

    public void resstart()
    {
        SceneManager.LoadScene(0);
    }



}
