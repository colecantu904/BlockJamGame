using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButtonScript : MonoBehaviour
{

    public void beginGame()
    {
        SceneManager.LoadScene(1);
    }

}
