using UnityEngine;

public class ClickCircle : MonoBehaviour
{
  
    Camera cam;
    public bool CanMove = true;
    Move moveScript;
    public MonsterSpawner monsterSpawner;

    void Start()
    {

        cam = Camera.main;
         moveScript = GetComponent<Move>();
        
    }
    void  OnEnable()
    {
        CanMove = true;
    }

    void Update()
    {
       clickCheck();
         if (CanMove)
          {
                moveScript.Moving();
          }



    }


    
    void clickCheck()
    {
        
 if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;

            // distancia desde la cámara al plano Z = 0
            mouse.z = 14f;

            Vector3 worldPos = cam.ScreenToWorldPoint(mouse);

            Collider2D hit = Physics2D.OverlapPoint(worldPos);
if (hit.CompareTag("enemy") && hit.name == gameObject.name)
{
    Debug.Log("Tag: " + hit.tag);

    SpriteRenderer sr = hit.GetComponent<SpriteRenderer>();

    transform.position = new Vector3(8.66f, 0.033f, 0f);
    monsterSpawner.killed++;

    CanMove = false;

    gameObject.SetActive(false);
}
        }
        
    }
}