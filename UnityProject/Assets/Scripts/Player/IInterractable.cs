using Unity.VisualScripting;
using UnityEngine;

public interface IInterractable
{
    void Interact();

    static void RemoveControl()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().CanControl = false;
    }

    void OnDestroy()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().CanControl = false;
    }
}
