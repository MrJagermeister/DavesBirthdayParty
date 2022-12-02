using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCloud : MonoBehaviour
{
    public Sprite[] clouds;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = clouds[(Random.Range(0, clouds.Length))];
    }
}
