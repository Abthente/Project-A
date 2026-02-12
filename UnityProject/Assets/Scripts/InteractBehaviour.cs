using System;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player =  GameObject.FindGameObjectWithTag("Player");
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
