using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coffee : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = (new Vector3(x, y) * Time.deltaTime).normalized * speed;
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Evil") {
            SceneManager.LoadScene("Menu");
        }

        if (other.tag == "Coffee") {
            SceneManager.LoadScene("End");
        }
    }
}
