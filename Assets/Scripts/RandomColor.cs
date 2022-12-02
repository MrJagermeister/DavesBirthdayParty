using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    private SpriteRenderer sr;
    public Color[] colors;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        var chosenColor = colors[Random.Range(0, colors.Length - 1)];

        sr.color = new Color(chosenColor.r, chosenColor.g, chosenColor.b, 1f);
    }
}
