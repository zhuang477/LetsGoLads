using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpDetect : MonoBehaviour
{
    public Transform backpack;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Weapon")
        {
            if (Input.GetKey(KeyCode.E))
            {
                other.gameObject.transform.parent.SetParent(backpack);
            }
        }
    }
}
