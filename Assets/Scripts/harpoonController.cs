using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class HarpoonController : MonoBehaviour
{
    public bool isAiming = false;
    public GameObject aimUI; //현재 임시 샘플 ui 출력
    public GameObject Prediction_Line; //조준선 출력
    private Camera mainCam;    

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        if (aimUI == null)
        {
            Debug.LogWarning("aimUI가 할당되지 않았습니다.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 조준 시작 (누른 순간 1회)
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("조준 시작");
            isAiming = true;
            Time.timeScale = 0.1f;
            if (aimUI != null)
            {
                aimUI.SetActive(true);
                Prediction_Line.SetActive(true);
            }
        }

        // 조준 중: 매 프레임 마우스 방향으로 조준선 갱신
        if (isAiming == true)
        {
            float angle = UpdateAimDirection();
        }

        // 조준 중 발사
        if (isAiming == true && Input.GetMouseButtonDown(0))
        {
            Debug.Log("작살 나감");            
        }

        // 조준 해제
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("조준 해제");
            isAiming = false;
            Time.timeScale = 1f;
            if (aimUI != null)
            {
                aimUI.SetActive(false);
                Prediction_Line.SetActive(false);
            }
        }
    }    

    // 마우스 방향으로 조준선 회전값 갱신 , 조준선 제한 
    float UpdateAimDirection()
    {
        Vector3 mouseWorldPos = GetMouseWorldPosition();
        Vector3 dir = mouseWorldPos - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //============= 오른쪽 보고있는 경우
        if(angle > 30 && angle <= 180 && transform.localScale.x > 0)
        {
            Debug.Log($"우상");
            angle = 30;
        }

        else if (angle <= -30 && angle >= -180 && transform.localScale.x > 0)
        {
            angle = -30;
            Debug.Log($"우하");
        }
        
        //============= 왼쪽 보고있는 경우        

        if (angle >= 0 && angle < 150 && transform.localScale.x < 0)
        {            
            angle = 150;
            Debug.Log($"좌상");
        }
        else if (angle >= -150 && angle < -0 && transform.localScale.x < 0)
        {
            angle = -150;
            Debug.Log($"좌하");
        }
        
        Prediction_Line.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        return angle;
    }

    // 현재 마우스 포인터의 월드 좌표 반환
    public Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCam.transform.position.z);
        return mainCam.ScreenToWorldPoint(mouseScreenPos);
    }
}