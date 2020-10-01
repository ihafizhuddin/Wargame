using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grids : MonoBehaviour{
    public static GameObject grid;
    //Properties untuk ukuran grid
    public int gridSizeX, gridSizeY;
    //Prefab yang akan digunakan untuk background grid
    public GameObject tilePrefab;
    private Vector2 offset;
    private Vector2 startPosition;
    private Camera cam;


    void Start(){
        grid = gameObject;
        cam = Camera.main;
        //Menentukan offset
        offset = tilePrefab.GetComponent<SpriteRenderer>().bounds.size;
        //Menentukan posisi awal
        startPosition = transform.position + (Vector3.left * (offset.x * gridSizeX / 2)) + (Vector3.down * (offset.y * gridSizeY / 2));
        CreateGrid();
    }
    void CreateGrid(){
        //Menentukan offset
        offset = tilePrefab.GetComponent<SpriteRenderer>().bounds.size;
        //Menentukan posisi awal
        startPosition = transform.position + (Vector3.left * (offset.x * gridSizeX / 2)) + (Vector3.down * (offset.y * gridSizeY / 2));
        //looping tile
        for (int x = 0; x < gridSizeX; x++){
            for (int y = 0; y < gridSizeY; y++){
                Vector2 pos = new Vector3(startPosition.x + (x * offset.x), startPosition.y + (y * offset.y));
                GameObject backgroundTile = Instantiate(tilePrefab, pos, tilePrefab.transform.rotation);
                backgroundTile.transform.parent = transform;
                backgroundTile.transform.SendMessage("setColumn",x);
                backgroundTile.transform.SendMessage("setRow",y);
                backgroundTile.name = "("+x+","+y+")";
            }
        }
    }
    void detectReachableTile(){
        foreach(Transform child in transform){
            child.gameObject.SendMessage("calculateTileDistance");
        }
    }
    void decoloringEveryTile(){
        foreach(Transform child in transform){
            child.gameObject.SendMessage("decoloringTile");
        }

    }
    // void calculateDistance(int newXPos, int newPos){
        
    // }
    void OnGUI(){
        Vector2 mousePos = new Vector2();
        // Event currentEvent = currentEvent.current;
        
        //Get the mouse position from Event
        //Note that the y position from Event is inverted
        Vector2 screenPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
    }
}
