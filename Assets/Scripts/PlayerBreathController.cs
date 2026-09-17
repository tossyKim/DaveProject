using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreathController : MonoBehaviour
{
    public float MaxHP;
    public float breathSpeed;
    public float HPState;
    public bool isLive;

    public void DoBreath()
    {
        HPState -= Time.deltaTime * breathSpeed;
    }

    private void Start()
    {
        HPState = MaxHP;
        isLive = true;
    }

    private void Update()
    {
        if (HPState < 0)
        {
            isLive = true;
            Debug.Log("게임오버");
        }
        DoBreath();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Fish_Aggressive")
        {
            HPState -= 10;
        }
    }

}
