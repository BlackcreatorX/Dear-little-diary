using UnityEngine;

public class Move : MonoBehaviour
{
    Camera cam;
    public BoxCollider2D Area;
    public BoxCollider2D Page1;
    public BoxCollider2D Page2;
    Vector3 target;
    public float speed = 2f;
    

    void Start()
    {
        cam = Camera.main;
    }
    void OnEnable()
    {
        if(this.transform.position.x <0)
        {
            Area = Page1;
             GetNewTarget();
        }
        else
        {
            Area = Page2;
             GetNewTarget();
        }
        
    }

public void Moving()
{
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            GetNewTarget();
        }
}
void GetNewTarget()
{
    Bounds bounds = Area.bounds;

    float x = Random.Range(bounds.min.x, bounds.max.x);
    float y = Random.Range(bounds.min.y, bounds.max.y);

    target = new Vector3(x, y, 0);
}
}