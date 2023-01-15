using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalPoint : MonoBehaviour
{

    [HideInInspector] public int Point;
    //
    //
    //

    [SerializeField] public Player_Movements movingstatus;
    [SerializeField] public Player_Status playerstatus;
    [HideInInspector] public bool RoundPointGiven = false;

    void Awake()
    {
        movingstatus = GameObject.FindObjectOfType<Player_Movements>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AdditionalPointShow();
    }

    public void TossingAddtionalPoint() {
        //Restrict and Features...
        //--Different Settings make additional points--
        //...
       Point = Random.Range(0, 4);
    }

    public void AdditionalPointShow() {
        if (movingstatus.IsItTossing == true) {
            if(RoundPointGiven == false)
            {
                TossingAddtionalPoint();
                RoundPointGiven = true;
            }
        }
    }


}
