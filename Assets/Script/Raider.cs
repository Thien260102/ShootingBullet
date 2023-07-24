using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RaiderState : int
{
    IDLE = 0,
    DEAD = 1,
}

public class Raider : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(RaiderState state)
    {
        animator.SetInteger("State", (int)state);
    }

    public void StopAnimation()
    {
        animator.enabled = false;
    }
}
