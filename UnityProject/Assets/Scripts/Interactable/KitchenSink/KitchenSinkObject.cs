using UnityEngine;

public class KitchenSinkObject : MonoBehaviour, IInterractable
{
    public GameObject MG_KitchenSink_prefab;
    
    public void Interact()
    {
        Vector3 spawnPos = Camera.main.transform.position;
        spawnPos.z = 0;
        
        Instantiate(MG_KitchenSink_prefab, spawnPos, transform.rotation);
    }
}
