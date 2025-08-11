using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;
    [SerializeField] private GameObject currentRoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (collision.transform.position.x < transform.position.x)
                cam.moveToNewRoom(nextRoom);
            else
                cam.moveToNewRoom(previousRoom);

            if (!AllLampsOffInCurrentRoom()) 
            {
                GameManager.gameManager.RuleBroken();
                return;
            }
            else
            {
                Debug.Log("Light rule is not broken!");
            }
            if (!AllCollectibleObjectsInCurrentRoom())
            {
                GameManager.gameManager.RuleBroken();
                return;
            }
            else
            {
                Debug.Log("Collectible rule is not broken!");
            }
        }
    }
    private bool AllLampsOffInCurrentRoom()
    {
        LightController[] lamps = currentRoom.GetComponentsInChildren<LightController>();
        foreach (LightController lamp in lamps)
        {
            if (lamp.isOn) // ako je bar jedna upaljena, pravilo JE prekršeno
                return false;
        }
        return true;
    }
    private bool AllCollectibleObjectsInCurrentRoom()
    {
        int totalInRoom = currentRoom.GetComponentsInChildren<CollectibleController>().Length;
        return totalInRoom == 0;
    }

}

