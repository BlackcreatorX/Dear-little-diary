using UnityEngine;

public class OpenedBook : MonoBehaviour
{
   public GameObject BookScript;
   void startDWriting()
   {
    BookScript.GetComponent<DialogueManager>().LoadJSON();
    BookScript.GetComponent<DialogueManager>().StartDialogue();
   }
}
