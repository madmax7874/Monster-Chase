using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] MonsterReference;
    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos,rightPos;

    private int randomIndex,randomSide;

    void Start(){
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster(){

        while(true){
            yield return new WaitForSeconds(Random.Range(1,5));
            randomIndex = Random.Range(0,MonsterReference.Length);
            randomSide = Random.Range(0,2); 
            spawnedMonster = Instantiate(MonsterReference[randomIndex]);

            if(randomSide == 0){
                spawnedMonster.transform.position=leftPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range(4,10);
            }else{
                spawnedMonster.transform.position=rightPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = -Random.Range(4,10);
                spawnedMonster.transform.localScale = new Vector3(-1f,1f,1f);
            }
        }
    }
}
