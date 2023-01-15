using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movements : MonoBehaviour
{
    //Waypoint Settings
    [SerializeField] public Transform[] waypoints;
    [SerializeField] public Waypoint_Select waypointselect;
    [HideInInspector] public int waypointIndex;
    [SerializeField] public Player_Data_IN_UI playerdatainui;

    //Dice Settings
    [SerializeField] public Transform tossdetection;


    [HideInInspector] public Board_Dice dicenumber;
    [HideInInspector] public int local_dicenumber;
    [HideInInspector] public int moving_dicenumber;

    //Data Exchange settings
    public Player_Data playerdata;

    //Detect whether player is tossing the dice.
    [HideInInspector] public bool IsItTossing = false;

    void Awake()
    {
        dicenumber = GameObject.FindObjectOfType<Board_Dice>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Receive the player's nation and respawn to the right location.
        SpawnLocationManager();
    }

    // Update is called once per frame
    void Update()
    {
        TossingAndMove();
    }

    public void TossingAndMove()
    {
        ReceiveDice();

        if (IsItTossing == false)
        {
            //If the dice is tossed.
            if (tossdetection.childCount > 0)
            {
                IsItTossing = true;
                moving_dicenumber = local_dicenumber;
            }
        }
    }

    public void ChessMove()
    {
        //tips: pass the original point part is not done.

        //choose 13 because 13 +6 is the extreme point of passing start point.
        if(waypointIndex <= 13)
        {
            if (waypointselect.waypointSelector > waypointIndex)
            {
               // BackwardCheck();
                if (waypointIndex + moving_dicenumber - waypointselect.waypointSelector >= 0)
                {
                    transform.position = waypoints[waypointselect.waypointSelector].transform.position;
                    moving_dicenumber = waypointIndex + moving_dicenumber - waypointselect.waypointSelector;
                    waypointIndex = waypointselect.waypointSelector;
                }
            }


            if (waypointselect.waypointSelector < waypointIndex)
            {
                if (moving_dicenumber - (waypointIndex - waypointselect.waypointSelector) >= 0)
                {
                    transform.position = waypoints[waypointselect.waypointSelector].transform.position;
                    moving_dicenumber = moving_dicenumber - (waypointIndex - waypointselect.waypointSelector);
                    waypointIndex = waypointselect.waypointSelector;
                }
            }
        }


        if(waypointIndex > 13)
        {
                //
                if (waypointselect.waypointSelector > waypointIndex)
                {
                    if (waypointIndex + moving_dicenumber - waypointselect.waypointSelector >= 0)
                    {
                        transform.position = waypoints[waypointselect.waypointSelector].transform.position;
                        moving_dicenumber = waypointIndex + moving_dicenumber - waypointselect.waypointSelector;
                        waypointIndex = waypointselect.waypointSelector;
                    }
                }

                //
                if(waypointselect.waypointSelector < waypointIndex)
                {
                    if(waypointselect.waypointSelector > 13)
                    {
                        transform.position = waypoints[waypointselect.waypointSelector].transform.position;
                        moving_dicenumber = moving_dicenumber - (waypointIndex - waypointselect.waypointSelector);
                    }

                    //need to determine whether is passing the start point.
                    if(waypointselect.waypointSelector <= 13)
                    {
                        DecisionCheck();
                        transform.position = waypoints[waypointselect.waypointSelector].transform.position;
                        moving_dicenumber = moving_dicenumber - (waypointIndex - waypointselect.waypointSelector);
                        waypointIndex = waypointselect.waypointSelector;
                    }
                }
        }
    }

    void BackwardCheck()
    {
        if (waypointselect.waypointSelector > 13 && waypointIndex <6)
        {
            transform.position = waypoints[waypointselect.waypointSelector].transform.position;
            moving_dicenumber = moving_dicenumber - ((waypointIndex + 20) - waypointselect.waypointSelector);
            waypointIndex = waypointselect.waypointSelector;
        }
    }


    void DecisionCheck()
    {
        if(waypointselect.waypointSelector < 6)
        {
            //if pass the start point
            if(waypointIndex + moving_dicenumber > 19)
            {
                int temp = 20+ waypointselect.waypointSelector;
                transform.position = waypoints[waypointselect.waypointSelector].transform.position;
                moving_dicenumber = moving_dicenumber -(temp -19);
                waypointIndex = waypointselect.waypointSelector;
            }

        }

        
    }

    //Getting dice number from Board_Dice script, need to put inside update() or functions which use update() method to activate.
    void ReceiveDice()
    {
        local_dicenumber = dicenumber.DiceNumber;
    }

    //West_Empire, East_Empire, L_Auto, Erania_II, Lealtrod, Oriental, Individual_Tower
    //Companion, Sword_Keeper, Merchant, Wizard, Professor
    void SpawnLocationManager()
    {
        //1
        if (playerdata.chosen_Country == CitizenShip.West_Empire)
        {
            transform.position = waypoints[11].transform.position;
            waypointIndex = 11;
        }

        //2
        if (playerdata.chosen_Country == CitizenShip.East_Empire)
        {
            transform.position = waypoints[14].transform.position;
            waypointIndex = 14;
        }

        //3
        if (playerdata.chosen_Country == CitizenShip.L_Auto)
        {
            transform.position = waypoints[3].transform.position;
            waypointIndex = 3;
        }

        //4
        if (playerdata.chosen_Country == CitizenShip.Erania_II)
        {
            transform.position = waypoints[8].transform.position;
            waypointIndex = 8;
        }

        //5
        if (playerdata.chosen_Country == CitizenShip.Lealtrod)
        {
            transform.position = waypoints[9].transform.position;
            waypointIndex = 9;
        }

        //6
        if (playerdata.chosen_Country == CitizenShip.Oriental)
        {
            transform.position = waypoints[0].transform.position;
            waypointIndex = 0;
        }

        //7
        if (playerdata.chosen_Country == CitizenShip.Individual_Tower)
        {
            transform.position = waypoints[15].transform.position;
            waypointIndex = 15;
        }
    }
}
