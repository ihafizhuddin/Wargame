using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour{
    [SerializeField]
    public static GameObject activeCharacter;
    private enum characterState{idle, active, move, attack, hit};
    private characterState status = characterState.idle;
    public int health;
    public int mana;
    public bool hasAttacked;
    public int attackRange;
    public bool hasMoved;
    public int moveRange;
    public int basicDamage;
    public int xPos;
    public int yPos;
    [SerializeField]
    private Grids grid;
    private Tiles currentTile;
    private Tiles otherTile;
    [SerializeField]
    protected Renderer rend;
    [SerializeField]
    protected Animator anim;
    // Start is called before the first frame update
    protected virtual void Start(){
        anim = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
        newTurn();
        // grid = GetComponent<Grids>();

        // currentTile = GetChildWithName((GameObject)grid, "("+xPos+","+yPos+")");
        // if(currentTile != null){
        //     currentTile.changeColor();
        // }
    }

    // Update is called once per frame
    void Update(){
        
    }
    void initialPosition(){
        // GameObject initialTile = grid.transform.Find("("+xPos+","+yPos+")");
        // transform.position = grid
    }
    GameObject GetChildWithName(GameObject obj, string name){
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if(childTrans != null){
            return childTrans.gameObject;
        }else{
            Debug.Log(name + " not found");
            return null;
        }
    }
    protected virtual void OnMouseDown(){
        if(gameObject.transform.parent.name == TurnManager.activePlayer.transform.name){
            setActive();
            Debug.Log("our "+ name + "is selected");
        }else{
            Debug.Log("their "+ name + "is selected");
            if(Character.activeCharacter != null){
                Character.activeCharacter.SendMessage("attackEnemy",this.gameObject);
                // Debug.Log(Character.activeCharacter.name + "attacking" + name);
            }
        }
        // Debug.Log(name + " is selected");
        // Debug.Log("(x,y) = (" + xPos + "," + yPos + ")");
        // Debug.Log("yPos = " + yPos);
    }
    protected virtual void setActive(){
        if(hasAttacked == true){
            return;
        }
        if(activeCharacter != null){
            activeCharacter.transform.SendMessage("setIdle");
            // activeCharacter.setIdle();
        }
        status = characterState.active;
        rend.material.color = Color.blue;
        activeCharacter = gameObject;
        if(hasMoved == false){
            Grids.grid.SendMessage("detectReachableTile");
        }
    }
    protected virtual void setIdle(){
        status = characterState.idle;
        rend.material.color = Color.white;
    }
    protected virtual void moveCharacter(Vector3 newPosition){
        if(hasMoved == false){
            gameObject.transform.position = newPosition;
            hasMoved = true;
            Grids.grid.SendMessage("decoloringEveryTile");
        }
    }
    public virtual void attackEnemy(GameObject enemy){
        if(enemyDistance(enemy) <= attackRange && hasAttacked == false){
            Debug.Log(name + " Attacking " + enemy.name);
            anim.SetTrigger("Attacking");
            enemy.SendMessage("getHit", basicDamage);
            hasAttacked = true;
            Character.activeCharacter.SendMessage("setIdle");
            Grids.grid.SendMessage("decoloringEveryTile");
            // Character.activeCharacter = null;
        }
    }
    public virtual int enemyDistance(GameObject enemy){
        //Menghitung jarak musuh menggunakan manhattan distance
        int x0 = xPos;
        int y0 = yPos;
        int x1 = enemy.GetComponent<Character>().xPos;
        int y1 = enemy.GetComponent<Character>().yPos;
        int distance = Mathf.Abs(x0 - x1) + Mathf.Abs(y0-y1);
        return distance;
    }
    public virtual void getHit(int damage){
        health -= damage;
        Debug.Log(name + " take " + damage + " damage");
        Debug.Log(name + " have " + health +" health remaining ");

        if(health<=0){
            StartCoroutine("death");
            // death();
        }else{
            if(enemyDistance(Character.activeCharacter) == 1){
                StartCoroutine("counterAttack");
            }
        }
    }
    protected virtual IEnumerator counterAttack(){
        yield return new WaitForSeconds(1f);
        // attackEnemy(Character.activeCharacter);
        Debug.Log(name + " counter attacking " + Character.activeCharacter.name);
        anim.SetTrigger("Attacking");
        Character.activeCharacter.SendMessage("getHit", basicDamage/2);
    }
    // public void death(){
    //     Debug.Log(name + " is dead");
    //     StartCoroutine("wait");
    //     // wait();
    // }
    protected virtual IEnumerator death(){
        this.transform.parent.gameObject.GetComponent<Player>().jumlahHero--;
        Debug.Log(name + " is dead");
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        if(this.transform.parent.gameObject.GetComponent<Player>().jumlahHero == 0){
            GameManager.gameManager.SendMessage("gameOver");
        }
    }
    protected virtual void newTurn(){
        hasAttacked = false;
        hasMoved = false;
    }
}
