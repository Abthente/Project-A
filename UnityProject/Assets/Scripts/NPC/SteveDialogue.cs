using UnityEngine;
using DialogueEditor;

public class SteveDialogue : MonoBehaviour, IInterractable
{
    public NPCConversation steveConversation;
    
    public void Interact()
    {
        ConversationManager.Instance.StartConversation(steveConversation);
    }
}
