using UnityEngine;
using DialogueEditor;

public class SteveDialogue : InteractBehaviour, IInterractable
{
    public NPCConversation steveConversation;
    
    public void Interact()
    {
        RemoveControl();
        ConversationManager.Instance.StartConversation(steveConversation);
    }
}
