using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float h;
    public float v;
    public float speed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2 (h, v);        
        rb.velocity = dir*speed;
    }
}
