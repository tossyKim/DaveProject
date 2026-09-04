using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harpoonAttackController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject harpoon;
    public GameObject Attack_Start;
    public bool Attack_End;

    private void Update()
    {        
        if (Vector2.Distance(harpoon.transform.position, Attack_Start.transform.position) > 10)
            harpoon.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.gameObject.tag);        
    }
}
