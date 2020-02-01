using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hornet : MonoBehaviour
{
    //public float speed = Random.Range(0.8f, 15.8f);
    //public float rotateSpeed = Random.Range(1.0f, 15.0f);
    public float rangex = 10f;
    public float rangey = 4.5f;


    Vector3 newPosition;

    void Start()
    {
        PositionChange();
    }

    void PositionChange()
    {
        newPosition = new Vector2(Random.Range(-rangex, rangex), Random.Range(-rangey, rangey));
    }

    void Update()
    {
        float speed = Random.Range(0.8f, 3.8f);
        if (Vector2.Distance(transform.position, newPosition) < 1)
            PositionChange();

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);

        LookAt2D(newPosition);
    }

    void LookAt2D(Vector3 lookAtPosition)
    {
        float rotateSpeed = Random.Range(1.0f, 5.0f);
        float distanceX = lookAtPosition.x - transform.position.x;
        float distanceY = lookAtPosition.y - transform.position.y;
        float angle = Mathf.Atan2(distanceX, distanceY) * Mathf.Rad2Deg;

        Quaternion endRotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime * rotateSpeed);
    }
}