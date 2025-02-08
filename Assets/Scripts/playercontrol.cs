using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public float speed = 10f;
    public Transform movePoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
    }
}
