using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{

    public float speed = 0.3f;
    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, pos.y+(newY*0.5f), pos.z);
    }
}
