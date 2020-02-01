using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed;

    private Renderer renderer;
    private Vector2 savedOffset;

    void Start()
    {
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + scrollSpeed * Time.deltaTime, 100);
    }
}
