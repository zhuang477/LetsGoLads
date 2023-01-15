using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum fakeZaxis { ground, leg, chest, head, sky}

public class Combat : MonoBehaviour
{
    //
    public Transform backpack;

    //loc when in halt situation
    public Transform hand;
    [HideInInspector]public Transform ZweiParent;
    private fakeZaxis AimPart;

    // Start is called before the first frame update
    void Start()
    {
        AimPart = fakeZaxis.chest;
    }

    // Update is called once per frame
    void Update()
    {
        WeaponSetToHand();
        PartDamage();
    }

    public SpriteRenderer Aimhead;
    public SpriteRenderer Aimbody;
    public SpriteRenderer Aimfeet;

    void PartDamage()
    {
        SymbolIdentifier();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(AimPart == fakeZaxis.chest)
            {
                AimPart = fakeZaxis.head;
            }
            if (AimPart == fakeZaxis.leg)
            {
                AimPart = fakeZaxis.chest;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (AimPart == fakeZaxis.chest)
            {
                AimPart = fakeZaxis.leg;
            }
            if (AimPart == fakeZaxis.head)
            {
                AimPart = fakeZaxis.chest;
            }
        }
    }

    void SymbolIdentifier()
    {
        if (AimPart == fakeZaxis.head)
        {
            Aimhead.color = new Color(255, 255, 255, 255);
            Aimbody.color = new Color(0, 0, 0, 0);
            Aimfeet.color = new Color(0, 0, 0, 0);
        }
        if (AimPart == fakeZaxis.chest)
        {
            Aimhead.color = new Color(0, 0, 0, 0);
            Aimbody.color = new Color(255, 255, 255, 255);
            Aimfeet.color = new Color(0, 0, 0, 0);
        }
        if (AimPart == fakeZaxis.leg)
        {
            Aimhead.color = new Color(0, 0, 0, 0);
            Aimbody.color = new Color(0, 0, 0, 0);
            Aimfeet.color = new Color(255, 255, 255, 255);
        }
    }

    void WeaponSetToHand()
    {
        ZweiLoc();
    }

    void ZweiLoc()
    {
        if (backpack.transform.Find("Zweihander"))
        {
            ZweiParent = backpack.transform.Find("Zweihander");
            ZweiParent.transform.SetParent(hand);
        }
    }
}
