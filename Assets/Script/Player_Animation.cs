using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    public Animator anim;
    public Player_2D_Movement player2dmovement;
    public Transform hands;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player2dmovement = GameObject.FindObjectOfType<Player_2D_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        PressLeftMouse();
        PressRightMouse();
        zwei();
        Moving();
        FacingTo();
        SprintAnimationSpeedChange();
    }

    void PressLeftMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Attack", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Attack", false);
        }
    }

    void PressRightMouse()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("Halt", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("Halt", false);
        }
    }

    void zwei()
    {
        if (hands.Find("Zweihander"))
        {
            anim.SetBool("Zweihander", true);
        }
    }

    void Moving()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("PressW", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("PressA", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("PressS", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("PressD", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("PressW", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("PressA", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("PressS", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("PressD", false);
        }

    }

    void FacingTo()
    {
        if(player2dmovement.aimdirection == AimDirection.north)
        {
            anim.SetBool("fNorth", true);
            anim.SetBool("fSouth", false);
            anim.SetBool("fEast", false);
            anim.SetBool("fWest", false);
        }

        if (player2dmovement.aimdirection == AimDirection.south)
        {
            anim.SetBool("fNorth", false);
            anim.SetBool("fSouth", true);
            anim.SetBool("fEast", false);
            anim.SetBool("fWest", false);
        }

        if (player2dmovement.aimdirection == AimDirection.east)
        {
            anim.SetBool("fNorth", false);
            anim.SetBool("fSouth", false);
            anim.SetBool("fEast", true);
            anim.SetBool("fWest", false);
        }

        if (player2dmovement.aimdirection == AimDirection.west)
        {
            anim.SetBool("fNorth", false);
            anim.SetBool("fSouth", false);
            anim.SetBool("fEast", false);
            anim.SetBool("fWest", true);
        }
    }

    void SprintAnimationSpeedChange()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(anim.GetBool("PressW")|| anim.GetBool("PressA")|| anim.GetBool("PressS")|| anim.GetBool("PressD"))
            {
                anim.SetFloat("MovingSpeed", 1.5f);
            }
        }
        else
        {
            anim.SetFloat("MovingSpeed", 1f);
        }
    }
}
