using System;
using System.Collections.Generic;
using UnityEngine;

public class WireBox : MonoBehaviour
{
    public List<Wire> wires;
    public int connectedWires = 0;

    private void ShuffleWires()
    {
        List<Vector3> EndWiresPositions = new List<Vector3>();

        foreach (Wire wire in wires)
        {
            Vector3 wirePosition = wire._endWire.transform.position;
            EndWiresPositions.Add(wirePosition);
        }
        
        foreach (Wire wire in wires)
        {
            int randomIndex = UnityEngine.Random.Range(0, EndWiresPositions.Count);
            wire._endWire.transform.position = EndWiresPositions[randomIndex];
            EndWiresPositions.RemoveAt(randomIndex);
        }
    }

    public void WinCondition()
    {
        if (connectedWires == wires.Count)
        {
            transform.root.gameObject.GetComponent<InteractBehaviour>().ReturnControl();
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ShuffleWires();
    }
}
