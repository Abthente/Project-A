using UnityEngine;

public class WireBoxObject : InteractBehaviour, IInterractable
{
    public GameObject MG_WireBox_prefab;

    public void Interact()
    {
        RemoveControl();
        
        Vector3 spawnPos = Camera.main.transform.position;
        spawnPos.z = 0;
        
        GameObject creatingMinigame = Instantiate(MG_WireBox_prefab, spawnPos, transform.rotation);
        creatingMinigame.transform.parent = transform;
    }
}
