using UnityEngine;

public class BookPage : MonoBehaviour
{
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
        if (GetComponent<Collider2D>() == null)
            Debug.LogError("Este objeto necesita un Collider2D");
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log($"Click en {gameObject.name}");
                
                Vector3 centro = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 0));
                centro.z = transform.position.z;
                transform.position = centro;
                
                Debug.Log($"Movido a {centro}");
            }
        }
    }
}