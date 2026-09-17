using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHPController : MonoBehaviour
{    
    public float MaxHP;
    public float HPState;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            var compWMC = collision.gameObject.GetComponent<WeaponMovementController>();

            if (compWMC == null)
            {
                Debug.LogError(collision.gameObject.name + " is WeaponMovementController is Null");
                return;
            }

            var damage = compWMC.power;
            GetDamage(damage);
            if (HPState <= 0)
            {
                gameObject.SetActive(false);
                Debug.Log(gameObject.name + " is Dead");
            }
        }
    }

    private void Start()
    {
        HPState = MaxHP;
    }

    public void GetDamage(float WeaponPower)
    {
        HPState -= WeaponPower;
        Debug.Log($"{HPState} -= {WeaponPower}");        
    }
}
