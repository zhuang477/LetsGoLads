using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Hitbox : MonoBehaviour
{
    public Collider2D hitbox;

    // Start is called before the first frame update
    void Start()
    {
        hitbox.GetComponent<Collider2D>().enabled = false;
    }

    void UsingHitbox()
    {
        hitbox.GetComponent<Collider2D>().enabled = true;
    }

    void StopHitBox()
    {
        hitbox.GetComponent<Collider2D>().enabled = false;
    }
}
