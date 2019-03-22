using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePeep : MonoBehaviour {

    [SerializeField]
    float AngularSpeed = 10.0f;

    float MoveSpeed = 1.0f;

    void Start () {

    }

    void Update () {
        DoMovement();
    }

    void    DoMovement() {
        float tVertMove = Input.GetAxis("Vertical");
        float tHorzMove = Input.GetAxis("Horizontal");

        transform.Rotate(0, tHorzMove * AngularSpeed, 0);
        transform.position += transform.forward * tVertMove * MoveSpeed;

    }
}
