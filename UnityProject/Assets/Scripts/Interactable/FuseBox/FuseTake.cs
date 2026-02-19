using System;
using UnityEngine;

public class FuseTake : MonoBehaviour
{
    public GameObject FusePrefab;
    public FuseSocket TakeSocket;
    
    private void OnMouseDown()
    {
        GameObject objectCreated = Instantiate(FusePrefab, Vector3.zero, Quaternion.identity);
        objectCreated.transform.parent = null;
        objectCreated.transform.localScale = new Vector3(3, 3, 3);
        objectCreated.transform.parent = transform;
        
        Fuse FuseCreated = objectCreated.gameObject.GetComponent<Fuse>();
        
        FuseCreated.GetComponent<SpriteRenderer>().sprite = FuseCreated.fuseSprites[0];
        FuseCreated._isConnected = false;
        
        FuseCreated.myFuseSocket = TakeSocket;
        FuseCreated.myFuseSocket.haveFuse = true;
        FuseCreated.SetPosition(TakeSocket.transform.position);
    }
}
