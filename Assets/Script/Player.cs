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
    #endregion

    // Update is called once per frame
    void Update()
    {
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                
                Debug.Log("Input position: " + Input.GetTouch(0).position);
                PlayerShooting(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - transform.position);
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
