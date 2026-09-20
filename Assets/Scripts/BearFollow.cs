using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BearFollow : MonoBehaviour
{
    public Sprite idleSprite;
    public Sprite clickSprite;

    Camera cam;
    SpriteRenderer sr;

    void Start()
    {
        Cursor.visible = false;
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // distancia de la cámara (-10) al plano (0)

        Vector3 worldPos = cam.ScreenToWorldPoint(mousePosition);

        transform.position = worldPos;
          
if (Input.GetMouseButtonDown(0) && clickSprite != null)
{
    sr.sprite = clickSprite;
}

if (Input.GetMouseButtonUp(0) && idleSprite != null)
{
    sr.sprite = idleSprite;
}

}
}