using UnityEngine;

public class WireBoxObject : MonoBehaviour, IInterractable
{
    private GameObject player;
    public GameObject MG_WireBox_prefab;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    public void Interact()
    {
        RemoveControl();
        
        Vector3 spawnPos = Camera.main.transform.position;
        spawnPos.z = 0;
        
        GameObject creatingMinigame = Instantiate(MG_WireBox_prefab, spawnPos, transform.rotation);
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
