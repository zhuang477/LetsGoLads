using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation_Lock : MonoBehaviour
{
    public Transform AnimationObject;


    // Update is called once per frame
    void Update()
    {
        AnimationObject.rotation = Quaternion.Euler(0, 0, 0);
    }
}
