using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launchpad : MonoBehaviour
{
    public float height = 5.0f;
    private IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        
        colliders[1].edgeRadius = Vector2.Lerp(Vector2.zero, new Vector2(height, 0), 0.5f).x;
        if (colliders[1].edgeRadius < height)
        {
            yield return new WaitForSecondsRealtime(0.25f);
            colliders[1].edgeRadius = 0;
        }
    }
}
