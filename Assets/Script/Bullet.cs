using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Fields and Properties
    private Rigidbody2D RidBody;

    private Vector2 direction;
    public Vector2 Direction
    {
        get { return direction; }
        set
        {
            direction = value.normalized;

            transform.up = direction;
        }
    }
    

    public float Speed;

    #endregion

    private void Awake()
    {
        RidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 currentPosition = RidBody.position;
        currentPosition += Speed * direction;

        RidBody.position = currentPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Direction = -Direction;
    }

}
