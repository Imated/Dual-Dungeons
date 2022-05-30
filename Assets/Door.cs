using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public bool changeScene;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isOpen)
        {
            changeScene = true;
        }
        else
        {
            changeScene = false;
        }
    }
}
