using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Victory : MonoBehaviour{
    // public static GameObject victoryPanel;
    public TextMeshProUGUI headerText;

    // void Start(){
    //     victoryPanel = gameObject;
    // }

    public void backToMainMenu(){
        SceneManager.LoadScene(0);
    }
    public void restartGame(){
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);

    }
    public void exitGame(){
        Application.Quit();
    }
}
