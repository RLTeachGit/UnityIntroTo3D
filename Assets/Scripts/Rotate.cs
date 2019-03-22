using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    [SerializeField]
    float Speed = 180.0f;    //Rotation Speed

	void Update () {
        transform.Rotate(0, Speed * Time.deltaTime, 0);
		
	}
}
