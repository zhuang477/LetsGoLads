using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Data_IN_UI : MonoBehaviour
{
    [SerializeField] public Player_Status playerstatus;
    [SerializeField] public Player_Movements movingstatus;
    [SerializeField] public AdditionalPoint Add_Point;
    [SerializeField] public Turn_Manager turnmanager;
    [SerializeField] public Player_Data playerdata;
    [SerializeField] public Waypoint_Select waypointselect;

    //Buttons
    public Button NextRoundButton;
    public Button InventoryButton;
    public Button MoveLocationButton;

    //Money, etc.
    public TMP_Text AddPointShown;
    public TMP_Text MoneyShown;
    public TMP_Text DicePointShown;
    public TMP_Text RoundLeftShown;

    //Receive Variables

    void Awake()
    {
        playerstatus = GameObject.FindObjectOfType<Player_Status>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ListenersEvent();
    }

    // Update is called once per frame
    void Update()
    {
        NumberStatusTrack();
        //MovableEvent();
    }

    void ListenersEvent()
    {
        //When the dice is tossed (means turn status is AFTER_TOSSING).
        NextRoundButton.onClick.AddListener(NextRoundEvent);

        //
        MoveLocationButton.onClick.AddListener(MoveEvent);
    }

    void NumberStatusTrack()
    {
        AddPointShown.text = Add_Point.Point.ToString();
        MoneyShown.text = playerdata.CurrentMoney.ToString();
        DicePointShown.text = movingstatus.moving_dicenumber.ToString();
        RoundLeftShown.text = turnmanager.Round_Left.ToString();
    }

    //Round left should minus 1, and reset the status.
    public void NextRoundEvent()
    {
        turnmanager.PressNextRoundButtonEvent();
    }
    
    public void MoveEvent()
    {
        movingstatus.ChessMove();
    }


    /**
    public void MovableEvent()
    {
        //problem: it will detect the previous number.
        if (movingstatus.waypointIndex <= 13)
        {
            if ((waypointselect.waypointSelector > movingstatus.waypointIndex && movingstatus.waypointIndex + movingstatus.moving_dicenumber >= waypointselect.waypointSelector)
            || (waypointselect.waypointSelector < movingstatus.waypointIndex && waypointselect.waypointSelector >= movingstatus.waypointIndex - movingstatus.moving_dicenumber))
            {
                MoveLocationButton.interactable = true;
            }
        }
        else
        {
            MoveLocationButton.interactable = false;
        }

    }**/
}
