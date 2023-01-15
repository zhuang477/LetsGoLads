using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Waypoint_Select : MonoBehaviour
{
    [SerializeField] public GameObject waypointDetect;
    [SerializeField] public int waypointSelector;
    [SerializeField] public Player_Movements playermovements;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SelectAnyCollider();
    }

    public void SelectAnyCollider()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null && hit.collider.transform.parent.gameObject == waypointDetect)
            {

               waypointSelector = Convert.ToInt32(hit.collider.name);

            }
        }
    }
}
