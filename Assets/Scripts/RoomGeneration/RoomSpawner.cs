using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    private RoomVariants variants;
    private int rand;
    private bool spawned = false;
    private float waitTime =3f;

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        Destroy(gameObject,waitTime);
        Invoke("Spawn", 0.2f);
    }

    public void Spawn()
    {
        variants.counter++;
        if(!spawned && variants.counter<20)
        {
            
            if (variants.counter % 5 == 0)
            {
                Instantiate(variants.RoomWithMage[0],transform.position, variants.RoomWithMage[0].transform.rotation);
               
            }
            else if (variants.counter % 9 ==0)
            {
                Instantiate(variants.RoomWithFountain[0],transform.position, variants.RoomWithFountain[0].transform.rotation);
        
            }
            else if (variants.counter == 19)
            {
                Instantiate(variants.FinalRoom[0],transform.position, variants.FinalRoom[0].transform.rotation);
                
            }
            else 
            {
                rand = Random. Range(0, variants.CasualRooms.Length);
                Instantiate(variants.CasualRooms[rand],transform.position, variants.CasualRooms[rand].transform.rotation);
             
            } 
            spawned = true; 
        }
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("RoomPoint") && other.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(gameObject);
        }
    } 
}
