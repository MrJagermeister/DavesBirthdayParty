using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    private CinemachineVirtualCamera cm;
    private Transform Player;

    public Transform lookPoint;
    public Transform rotatePoint;

    private bool shaking;

    void Start()
    {
        cm = GetComponent<CinemachineVirtualCamera>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!shaking)
        {
            cm.Follow = lookPoint;
        }
        
        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        rotatePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        
    }
}
