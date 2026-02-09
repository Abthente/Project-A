using System;
using UnityEngine;

public class KitchenSinkObject : MonoBehaviour, IInterractable
{
    private GameObject player;
    public GameObject MG_KitchenSink_prefab;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Interact()
    {
        RemoveControl();
            
        Vector3 spawnPos = Camera.main.transform.position;
        spawnPos.z = 0;
        
        GameObject creatingMinigame = Instantiate(MG_KitchenSink_prefab, spawnPos, transform.rotation);
        creatingMinigame.transform.parent = transform;
    }
    
    public void RemoveControl()
    {
        player.GetComponent<PlayerController>().CanControl = false;
    }

    public void ReturnControl()
    {
        player.GetComponent<PlayerController>().CanControl = true;
    }
}
