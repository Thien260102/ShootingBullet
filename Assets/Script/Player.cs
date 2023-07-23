using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Fields and Properties
    [SerializeField]
    List<Bullet> Bullets;
    int currentBullet = 0;

    [SerializeField]
    Transform GunTop;

    private Vector2 direction = new Vector2(1, 0);
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            if (Input.touchCount > 0)
            {
                Vector2 newDirection = (Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - transform.position).normalized;

                float angle = Vector2.SignedAngle(newDirection, direction);
                //Debug.Log(angle);
                
                transform.Rotate(0, 0, -angle);
                direction = newDirection;

                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    //Debug.Log("Input position: " + Input.GetTouch(0).position);
                    PlayerShooting(newDirection);
                }
            }
        }
    }

    void PlayerShooting(Vector2 direction)
    {
        if(Bullets.Count > currentBullet)
        {
            Bullet Instantiate_Bullet = Instantiate<Bullet>(Bullets[currentBullet]);
            Instantiate_Bullet.transform.position = GunTop.position;
            Instantiate_Bullet.Direction = direction;
        }
    }

}
