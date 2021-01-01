using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl control;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(control == null)
        {
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

    }
}
