using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public SpriteRenderer[] keys;
    public Sprite keyComplete;
    public AudioSource audio;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<PlayerController>().keysCollected++;
        if (keys[0].sprite == keyComplete)
            keys[1].sprite = keyComplete;
        else
            keys[0].sprite = keyComplete;
        audio.Play();
        gameObject.SetActive(false);
    }
}
