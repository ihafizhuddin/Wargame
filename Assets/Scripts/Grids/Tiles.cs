using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour{
    // public float width;
    // public float height;
    // public Character activeCharacter;
    public float xPosition;
    public float yPosition;
    public int column;//xPos
    public int row;//row
    private Grids grid;



    private Renderer rend;

    private Vector3 firstPosition;
    private Vector3 finalPosition;
    private Vector3 tempPosition;



    // Start is called before the first frame update
    void Start(){
        grid = FindObjectOfType<Grids>();
        rend = GetComponent<Renderer>();
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        // row = Mathf.RoundToInt((xPosition - grid.startPosition.x)/grid.offset.x);
        // column = Mathf.RoundToInt((yPosition - grid.startPosition.y)/grid.offset.x);
    }

    // Update is called once per frame
    void Update(){
        
    }
    void OnMouseDown(){
        // Debug.Log("("+column+","+row+")" + "is clicked");
        if(Character.activeCharacter != null)
        moveCharacter();
        // Character.activeCharacter.SendMessage("moveCharacter", this.transform.position);
        // rend.material.color = Color.red;
        
    }
    void changeColor(){
        rend.material.color = Color.blue;
    }

    void setColumn(int value){
        column = value;
    }
    void setRow(int value){
        row = value;
    }
    
    // public void setCollumnAndRow(int collumn, int row){
    //     this.column = collumn;
    //     this.row = row;
    // }
    void moveCharacter(){
        // Character.activeCharacter;
        int x0 = Character.activeCharacter.GetComponent<Character>().xPos;
        int y0 = Character.activeCharacter.GetComponent<Character>().yPos;
        int xDistance = Mathf.Abs(x0 - column);// Debug.Log("xDistance = " + xDistance);
        int yDistance = Mathf.Abs(y0 - row);// Debug.Log("yDistance = " + yDistance);
        float distance = (Mathf.Sqrt(xDistance*xDistance + yDistance*yDistance));
        // int distance = (int)(Mathf.Abs(Mathf.Sqrt(((column-x0)^2)+((row-y0)^2))));
        Debug.Log("Distance = " + distance);
        if(distance <= (float)Character.activeCharacter.GetComponent<Character>().moveRange){
            Character.activeCharacter.GetComponent<Character>().xPos = column;
            Character.activeCharacter.GetComponent<Character>().yPos = row;
            Character.activeCharacter.SendMessage("moveCharacter", this.transform.position);
        }
    }
    void calculateTileDistance(){
        int x0 = Character.activeCharacter.GetComponent<Character>().xPos;
        int y0 = Character.activeCharacter.GetComponent<Character>().yPos;
        int x1 = column;
        int y1 = row;
        int distance = Mathf.Abs(x0 - x1) + Mathf.Abs(y0-y1);
        if(distance <= Character.activeCharacter.GetComponent<Character>().moveRange){
            rend.material.color = Color.cyan;
        }else{
            rend.material.color = Color.white;

        }
    }
    void decoloringTile(){
        rend.material.color = Color.white;
        
    }
}
