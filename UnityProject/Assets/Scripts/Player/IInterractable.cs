using Unity.VisualScripting;
using UnityEngine;

public interface IInterractable
{
    void Interact();

    void RemoveControl();

    void ReturnControl();
}
