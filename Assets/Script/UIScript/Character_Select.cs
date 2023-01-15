using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public enum CitizenShip { West_Empire, East_Empire, L_Auto, Erania_II, Lealtrod, Oriental, Individual_Tower }
public enum Career { Companion, Sword_Keeper, BusinessMan, Wizard, Professor }

public class Character_Select : MonoBehaviour
{
    [HideInInspector] public CitizenShip Citizen;
    [HideInInspector] public Career Job;
    [HideInInspector] public int money =1000;

    public string board_Scene;
    public TMP_Dropdown Difficulty_select;
    [HideInInspector] public bool IsCountrySelect, IsCareerSelect, IsDifficultySelect;
    [SerializeField] private Player_Data playerdata;

    // Start is called before the first frame update
    void Start()
    {
        IsCountrySelect = false;
        IsCareerSelect = false;
        IsDifficultySelect = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //
    public void SelectWest() {
        Citizen = CitizenShip.West_Empire;
        IsCountrySelect = true;
    }

    public void SelectEast(){
        Citizen = CitizenShip.East_Empire;
        IsCountrySelect = true;
    }

    public void SelectLauto(){
        Citizen = CitizenShip.L_Auto;
        IsCountrySelect = true;
    }

    public void SelectEraniaII(){
        Citizen = CitizenShip.Erania_II;
        IsCountrySelect = true;
    }

    public void SelectLealtrod(){
        Citizen = CitizenShip.Lealtrod;
        IsCountrySelect = true;
    }

    public void SelectOriental(){
        Citizen = CitizenShip.Oriental;
        IsCountrySelect = true;
    }

    public void SelectIndividual_Tower(){
        Citizen = CitizenShip.Individual_Tower;
        IsCountrySelect = true;
    }
    //

    //
    public void JobCompanion()
    {
        Job = Career.Companion;
        IsCareerSelect = true;
    }

    public void JobSword_Keeper()
    {
        Job = Career.Sword_Keeper;
        IsCareerSelect = true;
    }

    public void JobBusinessMan()
    {
        Job = Career.BusinessMan;
        IsCareerSelect = true;
    }

    public void JobWizard()
    {
        Job = Career.Wizard;
        IsCareerSelect = true;
    }

    public void JobProfessor()
    {
        Job = Career.Professor;
        IsCareerSelect = true;
    }
    //

    public void Ready_ToGo()
    {
        if (IsCountrySelect == true && IsCareerSelect == true) {
            if (Difficulty_select == false){
                Difficulty_select.value = 0;
            }
                playerdata.CurrentMoney = money;
                playerdata.chosen_Country = Citizen;
                playerdata.chosen_Job = Job;
            SceneManager.LoadScene(board_Scene);
        }

    }

}
