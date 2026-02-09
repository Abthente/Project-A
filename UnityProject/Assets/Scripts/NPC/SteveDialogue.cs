using UnityEngine;
using DialogueEditor;

public class SteveDialogue : MonoBehaviour, IInterractable
{
    public NPCConversation steveConversation;
    
    public void Interact()
    {
        RemoveControl();
        ConversationManager.Instance.StartConversation(steveConversation);
    }

    public void RemoveControl()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().CanControl = false;
    }

    public void ReturnControl()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().CanControl = true;
    }
}
