using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsion : MonoBehaviour {

    Rigidbody2D r2d;

    public Repulsion[] repulsiveObjects; // set in inspector

    public float radius = 1; // set in inspector

	// Use this for initialization
	void Start () {
        r2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 force = new Vector2();
        for (var i=0; i<repulsiveObjects.Length; i++)
        {
            Vector2 toVec = transform.position - repulsiveObjects[i].transform.position;
            float minDist = radius + repulsiveObjects[i].radius;
            if (toVec.sqrMagnitude < minDist*minDist)
            {
                force += toVec.normalized * 100 / toVec.sqrMagnitude;
            }
        }
        r2d.AddForce(force, ForceMode2D.Impulse);
	}
}
