using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrpt : MonoBehaviour
{
    [Header("Collectable assets")]
    [SerializeField] private int collectibles = 0;
    [SerializeField] private GameObject colHolder;
    int maxCol = 8;

    void Start()
    {
    }
    void Update()
    {
        if (collectibles == maxCol)
        {

            //winnerRoomDoor.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("fe");
        switch(other.gameObject.tag)
        {
            case "Collectible":

                //CollectibleScript ot = other.gameObject.GetComponent<CollectibleScript>();
                collectibles++;
                break;

            case "Finish":
                //finishAnimation
                break;
        }
    }
}
