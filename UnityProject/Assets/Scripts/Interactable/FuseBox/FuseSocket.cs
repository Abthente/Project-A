using System;
using UnityEngine;

public class FuseSocket : MonoBehaviour
{
    private FuseBox myFuseBox;

    public bool haveFuse = false;

    private void Start()
    {
        myFuseBox = transform.root.gameObject.GetComponentInChildren<FuseBox>();
        myFuseBox.fuseSockets += 1;
    }

    public void SocketRepaired()
    {
        myFuseBox.workingFuses += 1;
    }
}
