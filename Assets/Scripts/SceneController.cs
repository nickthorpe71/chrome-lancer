using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void moveToLevel()
    {
        SceneManager.LoadScene("fantastic_scene");
    }

    public void moveToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
