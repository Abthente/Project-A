using System;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private bool canInteract = false;
    private GameObject _interactionObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IInterractable>() != null)
        {
            canInteract = true;
            _interactionObject =  other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canInteract = false;
        _interactionObject =  null;
    }

    public void MakeInterraction()
    {
        if (canInteract)
        {
            _interactionObject.GetComponent<IInterractable>().Interact();
        }
    }
}
