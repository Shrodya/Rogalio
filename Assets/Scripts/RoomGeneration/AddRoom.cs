using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    public GameObject[] doors;
    
    public GameObject[] enemyTypes;
    public Transform[] enemySpawners;

    public List<GameObject> enemies;
    private RoomVariants variants;
    private bool spawned;
    private bool doorsDestroyed;
    private int totalEnemies;
    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !spawned)
        {
            spawned = true;
            foreach(Transform spawner in enemySpawners)
            {
                int rand = Random.Range(0,27);
                if(rand % 2 == 0 )
                {
                    GameObject enemyType = enemyTypes[Random.Range(0,enemyTypes.Length)];
                    GameObject enemy = Instantiate(enemyType, spawner.position, Quaternion.identity) as GameObject;
                    enemy.transform.parent = transform;
                    enemies.Add(enemy);
                }
            }
            totalEnemies=enemies.Count;
            StartCoroutine(CheckEnemies());
        }
    }
    IEnumerator CheckEnemies()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => enemies.Count == 0);
        PlayerStats.playerStats.CashAdd(totalEnemies*4);
        DestroyDoors();

    } 
    public void DestroyDoors()
    {
        foreach(GameObject Door in doors)
        {
            if(Door != null)
            {
                Destroy(Door);
            }
        }
        doorsDestroyed = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (doorsDestroyed && other.CompareTag("Door"))
        {
            Destroy(other.gameObject);
        }
    }
}
