﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peed : MonoBehaviour
{
    public float speed = 1.5f;
    public float rotateSpeed = 5.0f;
    public float rangex = 10f;
    public float rangey = 4.0f;
    private bool notDead = true;
    private bool locked = false;
    public Sprite deadimage;
    public static bool PeedOn = false;


    Vector3 newPosition;
    public AudioClip Splat;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PositionChange();
    }

    void PositionChange()
    {
        newPosition = new Vector2(Random.Range(-rangex, rangex), transform.position.y);
    }

    void Update()
    {
        if (notDead)
        {
            if (Vector2.Distance(transform.position, newPosition) < 1)
                PositionChange();
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);

            LookAt2D(newPosition);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * .1f);
            SpinToEnd2D(newPosition);
        }
    }

    void LookAt2D(Vector3 lookAtPosition)
    {
        float distanceX = lookAtPosition.x - transform.position.x;
        float distanceY = lookAtPosition.y - transform.position.y;
        float angle = Mathf.Atan2(distanceX, distanceY) * Mathf.Rad2Deg + 45;

        Quaternion endRotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime * rotateSpeed);
    }
    void SpinToEnd2D(Vector3 lookAtPosition)
    {

        transform.Rotate(Vector3.forward * -10);
    }
    private void OnMouseDown()
    {
        if (!locked && !Hand._inputLocked)
        {
            XSpawn.killPeeds++;
            XSpawn.currentPeedcount--;
            locked = true;
            this.GetComponent<SpriteRenderer>().sprite = deadimage;
            notDead = false;
            newPosition = new Vector2(transform.position.x, -30f);
            AudioSource.PlayClipAtPoint(Splat, this.transform.position);
        }
    }
}




