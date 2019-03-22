using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePeep : MonoBehaviour {

    [SerializeField]
    float AngularSpeed = 180.0f;
    [SerializeField]
    float MoveSpeed = 10.0f;
    [SerializeField]
    float TiltDownLimit = 20.0f;
    [SerializeField]
    float TiltUpLimit = -35.0f;

    float mCamXRotate = 0.0f;       //Camera tilt
    Camera mCamera; //Get Parented Camera;
    void Start () {
        mCamera = GetComponentInChildren<Camera>(); //Find Camera if there
    }
    void Update () {
        DoMovement(); //Move Character & Camera
    }
    void    DoMovement() {
        float tVertMove = Input.GetAxis("Vertical");    //Forward
        float tHorzMove = Input.GetAxis("Horizontal");  //Rotate

        float tMouseMoveX = Input.GetAxis("Mouse X");  //Also Rotate
        float tMouseMoveY = Input.GetAxis("Mouse Y"); //Tilt camera

        transform.Rotate(0, tHorzMove * AngularSpeed * Time.deltaTime, 0);      //Rotate object
        transform.Rotate(0, tMouseMoveX * AngularSpeed * Time.deltaTime, 0);      //Rotate object

        transform.position += transform.forward * tVertMove * MoveSpeed * Time.deltaTime; //Move object in direction its facing i.e. forward

        if(mCamera!=null) { //If we have camera Parented then allow it to tilt up and down
            mCamXRotate += tMouseMoveY * Time.deltaTime * AngularSpeed * 0.25f;   //Get tilt Angle & slow it down a bit
            mCamXRotate = Mathf.Clamp(mCamXRotate, Mathf.Min(TiltUpLimit, TiltDownLimit), Mathf.Max(TiltUpLimit, TiltDownLimit)); //Clamp tilt
            mCamera.transform.localRotation = Quaternion.Euler(mCamXRotate, 0, 0); //Set local ration to affect tilt
        }
    }
}
