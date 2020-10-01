using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUtama : MonoBehaviour{
    public GameObject levelPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame(){
        levelPanel.SetActive(true);
    }
    public void exitGame(){
        Application.Quit();
    }
    public void loadLevel(int levelScene){
        SceneManager.LoadScene(levelScene);

    }
}
