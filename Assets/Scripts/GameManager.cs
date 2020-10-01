using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour{
    public static GameObject gameManager;
    public GameObject grid;
    public Character[] hero;
    public GameObject pemain1;
    public GameObject pemain2;
    public TextMeshProUGUI victoryHeaderText;
    public GameObject victoryPanel;
    public int jumlahHeroPlayer1;
    public int jumlahHeroPlayer2;
    // Start is called before the first frame update
    void Start(){
        
        gameManager = gameObject;
        InitializeCharacterPosition();
        jumlahHeroPlayer1 = pemain1.GetComponent<Player>().jumlahHero;
        jumlahHeroPlayer2 = pemain2.GetComponent<Player>().jumlahHero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InitializeCharacterPosition(){
        for (int i = 0; i < hero.Length; i++){
            string characterOrdinat = "("+hero[i].xPos +"," + hero[i].yPos+")"; 
            hero[i].transform.position = Grids.grid.transform.Find(characterOrdinat).gameObject.transform.position;
        }

    }
    void gameOver(){
        Debug.Log("Permainan berakhir");
        if(pemain2.GetComponent<Player>().jumlahHero == 0){
            Debug.Log("Player 1 Victory");
            victoryHeaderText.text= "Player 1 Victory";
        }else if(pemain1.GetComponent<Player>().jumlahHero == 0){
            Debug.Log("Player 2 Victory");
            victoryHeaderText.text = "Player 2 Victory";
        }
        victoryPanel.SetActive(true);
    }
    
}
