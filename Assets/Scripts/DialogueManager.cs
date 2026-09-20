using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;

    public float typingSpeed = 0.03f;

    DialogueList dialogueList;
    int currentDialogue = 0;

    string currentPage;

    //public KeyCode debugKey = KeyCode.Space;
    public MonsterSpawner enemySpawner;
    public Vector3 spawnPosition = new Vector3(-2.5f, 0, 0);
    public  Vector3 LeftSpawnPosition = new Vector3(-2.5f, 0, 0);
    public Vector3 RightSpawnPosition = new Vector3(2.5f, 0, 0);
    public Animator BookAnimator;


  


void Update()
{
   // if (Input.GetKeyDown(debugKey))
   // {
 //       NextDialogue();
 //   }

    if (enemySpawner.complete == true)
    {
        NextDialogue();

        if (currentDialogue < dialogueList.dialogues.Length)
        {
            if (dialogueList.dialogues[currentDialogue].page == "left")
            {
                BookAnimator.SetTrigger("SwitchBookPage");
            }
        }

        enemySpawner.complete = false;
    }
}

   public void LoadJSON()
    {
        TextAsset json = Resources.Load<TextAsset>("dialogues");
        dialogueList = JsonUtility.FromJson<DialogueList>(json.text);
    }

    public void StartDialogue()
    {
        Dialogue d = dialogueList.dialogues[currentDialogue];

        StopAllCoroutines();

        currentPage = d.page;

        if (d.page == "left")
        {
            StartCoroutine(TypeText(leftText, d.message));
            spawnPosition= LeftSpawnPosition;
        }
        else
        {
            StartCoroutine(TypeText(rightText, d.message));
            spawnPosition= RightSpawnPosition;
        }

    }

    IEnumerator TypeText(TextMeshProUGUI textBox, string message)
    {
        Dialogue d = dialogueList.dialogues[currentDialogue];
        textBox.text = "";

        foreach (char c in message)
        {
            textBox.text += c;
            yield return new WaitForSeconds(typingSpeed);
         
        }
         enemySpawner.SpawnMonsters(d.bugs, spawnPosition);

    }

    void SpawnBugs(int amount)
    {
        Debug.Log("Spawn bugs: " + amount);
    }

    public void NextDialogue()
    {
        // SOLO borrar si el último diálogo fue en la derecha
        if (currentPage == "right")
        {
            leftText.text = "";
            rightText.text = "";
        }

        currentDialogue++;

        if (currentDialogue < dialogueList.dialogues.Length)
        {
            StartDialogue();
        }
    }
}

