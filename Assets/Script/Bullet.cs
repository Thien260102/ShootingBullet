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
        RidBody.isKinematic = false;
        RidBody.gravityScale = 0;
    }

    void FixedUpdate()
    {
        Vector2 currentPosition = RidBody.position;
        currentPosition += Speed * direction;

        RidBody.position = currentPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if(tag == "Ground")
        {
            if(collision.contactCount > 0)
            {
                Vector2 newDirection = direction;

                Vector2 hitPoint = collision.GetContact(0).normal;
                if(hitPoint.x != 0.0f)
                {
                    newDirection.x *= -1;
                    
                }
                else if(hitPoint.y != 0.0f)
                {
                    newDirection.y *= -1;
                }

                Direction = newDirection;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Enemy")
        {
            Raider raider = collision.gameObject.GetComponent<Raider>();
            raider.SetState(RaiderState.DEAD);
        }
    }

}
