using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FuseBox : MonoBehaviour
{
    public int fuseSockets;
    public int workingFuses;
    
    public void WinCondition()
    {
        if (fuseSockets - 1 == workingFuses)
        {
            transform.root.gameObject.GetComponent<InteractBehaviour>().ReturnControl();
            Destroy(gameObject);
        }
    }
}
