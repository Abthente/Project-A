using UnityEngine;

public class WireBoxObject : MonoBehaviour, IInterractable
{
    public GameObject MG_WireBox_prefab;
    
    public void Interact()
    {
        Debug.Log("Interact");
        
        Vector3 spawnPos = Camera.main.transform.position;
        spawnPos.z = 0;
        
        Instantiate(MG_WireBox_prefab, spawnPos, transform.rotation);
    }
}
