using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float h;
    public float v;
    public float speed;
    public Rigidbody2D rb;
    public GameObject Aim_Canbus;
    public GameObject PredictLine_Canbus;
    public HarpoonController harpoonController;   

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Vector2 dir;
        if (harpoonController.isAiming == false) //조준하지 않을 때에만 이동 가능
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            dir = new Vector2(h, v);

            if (h != 0 && v != 0)
            {
                dir = dir.normalized;
            }
            rb.velocity = dir * speed;
        }
        else //조준하는 중에는 물리값 0으로
        {
            dir = Vector2.zero;
            rb.velocity = dir;
        }

        if (h < 0)
        {
            transform.localScale = new Vector3((Mathf.Abs(transform.localScale.x) * -1), transform.localScale.y, transform.localScale.z);
            Aim_Canbus.transform.localScale = new Vector3(Mathf.Abs(Aim_Canbus.transform.localScale.x)*-1, Aim_Canbus.transform.localScale.y, Aim_Canbus.transform.localScale.z);
            PredictLine_Canbus.transform.localScale = new Vector3(Mathf.Abs(PredictLine_Canbus.transform.localScale.x) * -1, PredictLine_Canbus.transform.localScale.y, PredictLine_Canbus.transform.localScale.z);

        }
        else if(h > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            Aim_Canbus.transform.localScale = new Vector3(Mathf.Abs(Aim_Canbus.transform.localScale.x), Aim_Canbus.transform.localScale.y, Aim_Canbus.transform.localScale.z);
            PredictLine_Canbus.transform.localScale = new Vector3(Mathf.Abs(PredictLine_Canbus.transform.localScale.x), PredictLine_Canbus.transform.localScale.y, PredictLine_Canbus.transform.localScale.z);
        }
    }
}