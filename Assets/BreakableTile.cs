using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableTile : MonoBehaviour
{
    public Animation anim;
    private IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        anim.Play();
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
