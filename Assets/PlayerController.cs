using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float checkRadius;
    public float speed = 1.0f;
    public float jumpHeight = 1.0f;
    private bool _isFacingRight;
    private bool _isGrounded = true;
    public AudioSource jumpSource;
    [HideInInspector] public int keysCollected;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var jump = Input.GetButton("Jump");

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        switch (_isFacingRight)
        {
            case false when horizontal > 0:
                FlipRight();
                break;
            case true when horizontal < 0:
                FlipLeft();
                break;
        }

        if (jump && _isGrounded)
        {
            _rb.velocity = Vector2.up * jumpHeight;
            jumpSource.Play();
        }

        var moveAmount = new Vector2(horizontal * speed, _rb.velocity.y);
        _rb.velocity = moveAmount;
    }

    private void FlipLeft()
    {
        _isFacingRight = false;
        var transform1 = transform;
        var scaler = transform1.localScale;
        scaler.x = -1;
        transform1.localScale = scaler;

    }

    private void FlipRight()
    {
        _isFacingRight = true;
        var transform1 = transform;
        var scaler = transform1.localScale;
        scaler.x = 1;
        transform1.localScale = scaler;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z));
    }
}
