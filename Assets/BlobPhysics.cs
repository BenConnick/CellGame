using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobPhysics : MonoBehaviour {

    public GameObject[] OtherParts;
    public GameObject root;

    // Force Weights
    public float CenterWt;
    public float AvoidWt;

    public Vector3 netForce;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddCenterForce()
    {

    }
}
