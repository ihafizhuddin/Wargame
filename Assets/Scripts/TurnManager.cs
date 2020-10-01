using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TurnManager : MonoBehaviour{
    private enum playerTurn{player1, player2};
    private playerTurn turn = playerTurn.player1;
    [SerializeField]
    public static GameObject activePlayer;
    public GameObject pemain1;
    public GameObject pemain2;
    public GameObject playerTurnPanel;
    public TextMeshProUGUI textGiliran;
    public TextMeshProUGUI textGiliranOnPanel;
    // Start is called before the first frame update
    void Start(){
        // activePlayer = pemain2;
        // Character.activeCharacter.transform.SendMessage("setIdle");
        pemain1.SendMessage("enableActivePlayer");
        pemain2.SendMessage("disableActivePlayer");
        TurnManager.activePlayer = pemain1;
        textGiliran.text = "Player 1";
        // activePlayer.transform.SendMessage("enableActivePlayer");
        // pemain2.transform.SendMessage("disableActivePlayer");
    }

    // Update is called once per frame
    void Update(){
        
    }
    public void changeTurn(){
        if(Character.activeCharacter != null){
            Character.activeCharacter.transform.SendMessage("setIdle");
            Character.activeCharacter = null;

        }
        activePlayer.SendMessage("disableActivePlayer");
        if(turn == playerTurn.player1){
            turn = playerTurn.player2;
            textGiliran.text = "Player 2";
            activePlayer = pemain2;
            // Pemain1.GetComponentInChildren<BoxCollider2D>().enabled = false;
            // Pemain2.GetComponentInChildren<BoxCollider2D>().enabled = true;
        }else if(turn == playerTurn.player2){
            turn = playerTurn.player1;
            textGiliran.text = "Player 1";
            activePlayer = pemain1;
        }
        activePlayer.SendMessage("enableActivePlayer");
        Grids.grid.SendMessage("decoloringEveryTile");
        // GameObject textOnPanel = playerTurnPanel.Find("Turn Text");
        // Text textTurn = textOnPanel.GetComponent<Text>();
        // textTurn = textGiliran;
        textGiliranOnPanel.text = "giliran " + textGiliran.text;
        playerTurnPanel.SetActive(true);
        StartCoroutine("activateTurnPanel");
        
    }
    IEnumerator activateTurnPanel(){
        yield return new WaitForSeconds(3f);
        playerTurnPanel.SetActive(false);
    }

}
