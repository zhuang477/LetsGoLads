using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZweihanderR : MonoBehaviour
{
    public Transform zweihander;
    public Collider2D pickupBox;

    // Update is called once per frame
    void Update()
    {
        ZweiRelate();
    }

    void ZweiRelate()
    {
        if (zweihander.transform.parent != null && zweihander.transform.parent.name == "hand")
        {
            pickupBox.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }
}
