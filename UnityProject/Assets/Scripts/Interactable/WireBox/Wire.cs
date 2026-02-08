using System;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public LineRenderer _lineRenderer;
    public Transform _endWire;

    private bool _isDragged = false;
    private bool _isConnected = false;
    private Vector3 _originalPosition;

    private void Start()
    {
        _originalPosition = transform.position;
    }

    private void Update()
    {
        if (_isDragged == true)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 converted = Camera.main.ScreenToWorldPoint(mousePos);
            converted.z = 0;

            SetPosition(converted);

            Vector3 endWireDifference = converted - _endWire.position;
            
            if (endWireDifference.magnitude < 0.5f)
            {
                transform.position = _endWire.position;
                _isDragged = false;
                _isConnected = true;
                SendThatIsConnected();
                
                SetPosition(_endWire.position);
            }
        }
    }

    private void SendThatIsConnected()
    {
        WireBox wireBox = transform.root.gameObject.GetComponent<WireBox>();
        wireBox.connectedWires += 1;
        wireBox.WinCondition();
    }

    void SetPosition(Vector3 position)
    {
        transform.position = position;
        Vector3 positionDifference = position - _lineRenderer.transform.position;
        _lineRenderer.SetPosition(2, positionDifference - new Vector3(0.5f, 0, 0));
        _lineRenderer.SetPosition(3, positionDifference - new Vector3(0.2f, 0, 0));
    }

    public void ResetPosition()
    {
        _isConnected = false;
        _isDragged = false;
        SetPosition(_originalPosition);
    }

    private void OnMouseDown()
    {
        if (_isConnected != true)
        {
            _isDragged = true;
        }
    }
    
    private void OnMouseUp()
    {
        if (_isConnected != true)
        {
            _isDragged = false;
            ResetPosition();
        }
    }

    public bool IsConnected
    {
        get => _isConnected;
        set => _isConnected = value;
    }
}
