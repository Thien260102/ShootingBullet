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
        if(collision.gameObject.tag == "Ground")
        {
            if(collision.contactCount > 0)
            {
                Vector2 newDirection = direction;

                Vector2 hitPoint = collision.GetContact(0).normal;
                if (hitPoint.x != 0)
                    newDirection.x *= -1;
                if (hitPoint.y != 0)
                    newDirection.y *= -1;

                Direction = newDirection;
            }
        }
    }

}
