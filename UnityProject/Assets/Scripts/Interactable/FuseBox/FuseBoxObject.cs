using UnityEngine;

public class FuseBoxObject : InteractBehaviour, IInterractable
{
    public GameObject MG_FuseBox_prefab;

    public void Interact()
    {
        RemoveControl();
        
        Vector3 spawnPos = Camera.main.transform.position;
        spawnPos.z = 0;
        
        GameObject creatingMinigame = Instantiate(MG_FuseBox_prefab, spawnPos, transform.rotation);
        creatingMinigame.transform.parent = transform;
    }
}
