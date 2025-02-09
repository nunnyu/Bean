using System;
using Unity.Mathematics;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public float speed = 10f;
    public Transform movePoint;

    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if ((Math.Abs(movePoint.position.x - transform.position.x) < 0.05f)) {
            rb.SetRotation(0);
        } else {
            rb.SetRotation(90);
        }
    }
}
