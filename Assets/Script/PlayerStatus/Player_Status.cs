using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    //Components that no need to wake
    [SerializeField] public Player_Data playerdata;
    [SerializeField] public Turn_Manager turnmanager;

    //Components that needs to wake.
    [SerializeField] public Player_Movements playermovements;
    [SerializeField] public AdditionalPoint additionalpoint;

    void Awake() {
        playermovements = GameObject.FindObjectOfType<Player_Movements>();
        additionalpoint = GameObject.FindObjectOfType<AdditionalPoint>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
