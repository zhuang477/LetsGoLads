using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Manager : MonoBehaviour
{
    [SerializeField] public Turn_Status turnstatus;
    [SerializeField] public Player_Movements playermovements;
    [SerializeField] public AdditionalPoint additionalpoint;
    [SerializeField] public Collider2D tossdicebutton;
    [SerializeField] public Board_Dice boarddice;

    [SerializeField] public int Round_Left = 40;

    // Start is called before the first frame update
    void Start()
    {
        turnstatus = Turn_Status.BEFORE_TOSSING;
    }

    // Update is called once per frame
    void Update()
    {
        TossDiceEvent();
    }

    public void TossDiceEvent()
    {
        if(turnstatus == Turn_Status.BEFORE_TOSSING)
        {
            if(playermovements.IsItTossing == true)
            {
                tossdicebutton.GetComponent<BoxCollider2D>().enabled = false;
                turnstatus = Turn_Status.AFTER_TOSSING;
            }
        }
    }

    public void PressNextRoundButtonEvent()
    {
        if(turnstatus == Turn_Status.AFTER_TOSSING)
        {
            playermovements.IsItTossing = false;
            additionalpoint.RoundPointGiven = false;
            tossdicebutton.GetComponent<BoxCollider2D>().enabled = true;
            turnstatus = Turn_Status.BEFORE_TOSSING;
            Round_Left--;
        }

    }
}
