using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public PlayerController[] players;
    public SpriteRenderer doorRenderer;
    public Sprite doorOpenSprite;
    public Door door;
    public bool six;
    
    private void Update()
    {
        if (players[0].keysCollected == 1 && players[1].keysCollected == 1)
        {
            doorRenderer.sprite = doorOpenSprite;
            door.isOpen = true;
        }

        if (door.changeScene && !six)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if (six)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LoadLevel(int index) 
    {
        SceneManager.LoadScene(index);
    }
}
