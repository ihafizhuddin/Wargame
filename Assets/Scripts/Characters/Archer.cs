using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Character{
    public override void attackEnemy(GameObject enemy){
        if (yPos == enemy.GetComponent<Character>().yPos && hasAttacked == false){
            Debug.Log(name + " Attacking " + enemy.name);
            if (enemyDistance(enemy) >= 2){
                anim.SetTrigger("Shoot");
                enemy.SendMessage("getHit", (int)(basicDamage * 1.5f));
            }else{
                anim.SetTrigger("Mele");
                enemy.SendMessage("getHit", basicDamage / 2);
            }
            hasAttacked = true;
            Character.activeCharacter.SendMessage("setIdle");
            Grids.grid.SendMessage("decoloringEveryTile");
        }else if (enemyDistance(enemy) == 1){
            anim.SetTrigger("Mele");
            enemy.SendMessage("getHit", basicDamage / 2);
            hasAttacked = true;
            Character.activeCharacter.SendMessage("setIdle");
            Grids.grid.SendMessage("decoloringEveryTile");
        }
    }
    protected override IEnumerator counterAttack(){
        yield return new WaitForSeconds(1f);
        // attackEnemy(Character.activeCharacter);
        Debug.Log(name + " counter attacking " + Character.activeCharacter.name);
        anim.SetTrigger("Mele");
        Character.activeCharacter.SendMessage("getHit", basicDamage);
    }
}
