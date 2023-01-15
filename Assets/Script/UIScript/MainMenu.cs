using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string character_scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene(character_scene);
    }

    public void OpenOptions() { 
    
    }

    public void CloseOptions()
    {

    }

    public void QuitGame() {
        Application.Quit();
    }
}
