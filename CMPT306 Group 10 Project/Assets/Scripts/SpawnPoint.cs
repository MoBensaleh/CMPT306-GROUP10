using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public int openingDirection = 0;
    private RoomTemplate template;
    private bool spawned = false;
    private int roomCount = 0;

    void Start()
    {
        int randomSize = Random.Range(7, 18);
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        for(int i=0; i < randomSize; i++)
        {
            Invoke("Spawn", 0.1f);
        }
        

    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                int randomRoom = Random.Range(0, template.topRooms.Length);
                Instantiate(template.topRooms[randomRoom], transform.position, Quaternion.identity);
                roomCount++;
            }
            else if (openingDirection == 2)
            {
                int randomRoom = Random.Range(0, template.bottomRooms.Length);
                Instantiate(template.bottomRooms[randomRoom], transform.position, Quaternion.identity);
                roomCount++;
            }
            else if (openingDirection == 3)
            {
                int randomRoom = Random.Range(0, template.rightRooms.Length);
                Instantiate(template.rightRooms[randomRoom], transform.position, Quaternion.identity);
                roomCount++;
            }
            else if (openingDirection == 4)
            {
                int randomRoom = Random.Range(0, template.leftRooms.Length);
                Instantiate(template.leftRooms[randomRoom], transform.position, Quaternion.identity);
                roomCount++;
            }

            spawned = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint")) Destroy(gameObject);    
    }
}
