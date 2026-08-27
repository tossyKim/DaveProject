using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using TMPro;

public class gigController : MonoBehaviour
{
    public bool isaim = false;
    public GameObject aimUI;


    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))            
        {
            Debug.Log("조준 시작");
            isaim = true;
            aimUI.SetActive(true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("조준 해제");
            isaim = false;
            Time.timeScale = 1f;
            aimUI.SetActive(false);

            //===========================

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 clickedPoint = hit.point;
                Debug.Log("클릭한 오브젝트/지형 위치: " + clickedPoint);
            }
        }

        if(isaim == true)
        {
            Time.timeScale = 0.1f;
        }
    }
}
