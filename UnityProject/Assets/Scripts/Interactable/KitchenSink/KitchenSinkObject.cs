using System;
using UnityEngine;

public class KitchenSinkObject : InteractBehaviour, IInterractable
{
    public GameObject MG_KitchenSink_prefab;

    public void Interact()
    {
        RemoveControl();
            
        Vector3 spawnPos = Camera.main.transform.position;
        spawnPos.z = 0;
        
        GameObject creatingMinigame = Instantiate(MG_KitchenSink_prefab, spawnPos, transform.rotation);
        creatingMinigame.transform.parent = transform;
    }
}
