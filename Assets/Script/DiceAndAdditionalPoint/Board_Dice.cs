using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_Dice : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public Transform diceLocation;
    public BoxCollider2D RollTheDice;
    public Transform NewTossDetection;
    private int round = 1;
    [HideInInspector] public int DiceNumber;


    private void OnMouseDown()
    {
        StartCoroutine("TossingDiceEvent");
    }
    

    public IEnumerator TossingDiceEvent()
    {
        DiceNumber = Random.Range(1, 7);
        Vector2 init_loc = diceLocation.position;
        //
        //
            gameObject.GetComponent<Renderer>().enabled = false;
            if (DiceNumber == 1)
            {
                GameObject clone = (GameObject)Instantiate(one, init_loc, Quaternion.identity, NewTossDetection);
                yield return new WaitForSeconds(0.5f);
                Destroy(clone);
            }
            if (DiceNumber == 2)
            {
                GameObject clone = (GameObject)Instantiate(two, init_loc, Quaternion.identity, NewTossDetection);
                yield return new WaitForSeconds(0.5f);
                Destroy(clone);
            }
            if (DiceNumber == 3)
            {
                GameObject clone = (GameObject)Instantiate(three, init_loc, Quaternion.identity, NewTossDetection);
                yield return new WaitForSeconds(0.5f);
                Destroy(clone);
            }
            if (DiceNumber == 4)
            {
                GameObject clone = (GameObject)Instantiate(four, init_loc, Quaternion.identity, NewTossDetection);
                yield return new WaitForSeconds(0.5f);
                Destroy(clone);
            }
            if (DiceNumber == 5)
            {
                GameObject clone = (GameObject)Instantiate(five, init_loc, Quaternion.identity, NewTossDetection);
                yield return new WaitForSeconds(0.5f);
                Destroy(clone);
            }
            if (DiceNumber == 6)
            {
                GameObject clone = (GameObject)Instantiate(six, init_loc, Quaternion.identity, NewTossDetection);
                yield return new WaitForSeconds(0.5f);
                Destroy(clone);
            }
            gameObject.GetComponent<Renderer>().enabled = true;
            round--;
            
    }
}
