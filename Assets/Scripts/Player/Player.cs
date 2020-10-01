using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public int jumlahHero = 0;
    // Start is called before the first frame update
    void Start(){
        foreach (Transform child in transform){
            jumlahHero++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void enableActivePlayer(){
        foreach (Transform child in transform){
            child.gameObject.SendMessage("newTurn");
        }
        // foreach (BoxCollider2D box in TurnManager.activePlayer.GetComponentsInChildren<BoxCollider2D>()){
        //     box.enabled = true;    
        // }
    }
    public void disableActivePlayer(){
        // TurnManager.activePlayer.GetComponentsInChildren<BoxCollider2D>().enabled = false;
        // foreach (BoxCollider2D box in TurnManager.activePlayer.GetComponentsInChildren<BoxCollider2D>()){
        //     box.enabled = false;    
        // }
    }
}
