using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Sound : MonoBehaviour
{
    public AudioSource player;

    public AudioClip Zwei_Swing_1;
    public AudioClip Zwei_Stab;

    public void ZweiSwing()
    {
        player.PlayOneShot(Zwei_Swing_1);
    }

    public void ZweiStab()
    {
        player.PlayOneShot(Zwei_Stab);
    }
}
