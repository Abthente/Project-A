using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fuse : MonoBehaviour
{
    public Sprite[] fuseSprites;
    
    public FuseSocket myFuseSocket;

    public bool _isConnected = false;
    public bool _isDragged = false;

    private void Awake()
    {
        bool IsBroken = Random.value < 0.5f;

        if (IsBroken)
        {
            _isConnected = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = fuseSprites[1];
        }
        else
        {
            _isConnected = true;
            myFuseSocket.SocketRepaired();
        }
        
        if (myFuseSocket != null)
        {
            myFuseSocket.haveFuse = true;
            SetPosition(myFuseSocket.transform.position);
        }
    }

    private void Update()
    {
        if (_isDragged == true)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 converted = Camera.main.ScreenToWorldPoint(mousePos);
            converted.z = 0;

            SetPosition(converted);
        }
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void OnMouseDown()
    {
        if (_isConnected == false)
        {
            _isDragged = true;
            
            myFuseSocket.haveFuse = false;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
    }

    private void OnMouseUp()
    {
        if (_isConnected == false)
        {
            _isDragged = false;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<FuseDrop>() != null) { Destroy(gameObject) ;}
        
        if (other.gameObject.GetComponent<FuseSocket>() == null) { return; }
        
        if (other.gameObject.GetComponent<FuseSocket>().haveFuse == true) { return; }
        
        if (myFuseSocket != null) { myFuseSocket.haveFuse = false; }
        
        Repaired(other);
    }

    private void Repaired(Collision2D fuseSocket)
    {
        myFuseSocket = fuseSocket.gameObject.GetComponent<FuseSocket>();
        myFuseSocket.haveFuse = true;
        
        _isDragged = false;
        _isConnected = true;
        transform.parent = fuseSocket.gameObject.transform;
        SetPosition(myFuseSocket.transform.position);
        
        myFuseSocket.SocketRepaired();
    }
}
