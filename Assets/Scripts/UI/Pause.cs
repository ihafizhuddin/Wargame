using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour{
    public TextMeshProUGUI pauseButtonText;
    public GameObject pausePanel;
    private enum GameStatus{play, pause};
    private GameStatus status = GameStatus.play;
    public void pauseGame(){
        if(status == GameStatus.play){
            pauseButtonText.text = " |>";
            status = GameStatus.pause;
            pausePanel.SetActive(true);
        }else{
            pauseButtonText.text = " ||";
            status = GameStatus.play;
            pausePanel.SetActive(false);

        }
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
