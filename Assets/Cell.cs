using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    Vector3 targetPos;
    public float MaxSpeed; // set in inspector
    public float Acceleration;
    Vector3 velocity;
    float slowingRadius = 1f;

    bool goToFinger = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // trigger
            goToFinger = true;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // set target position
            targetPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            goToFinger = true;
        }
        if (Input.GetMouseButton(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            goToFinger = true;
        }
        if (goToFinger)
        {
            targetPos.z = transform.position.z; // stay on plane
            // get distance
            Vector3 toVec = targetPos - transform.position;
            float dist = toVec.magnitude;

            // if outside slowing
            if (dist > slowingRadius)
            {
                // max speed to target
                velocity += toVec.normalized * Acceleration * Time.deltaTime;
            } else
            {
                // slow down to zero on arrival
                //Vector3 desiredvelocity = Acceleration * toVec.normalized * (dist / slowingRadius);
                Vector3 desiredvelocity = toVec.normalized * MaxSpeed * (dist / slowingRadius);
                //Debug.DrawLine(transform.position, -Vector3.forward + transform.position + desiredvelocity,Color.red,1.1f);
                velocity = velocity + Vector3.ClampMagnitude((desiredvelocity - velocity),Acceleration);
                // vel = vel + ( toVec.norm * d / r ) - vel
            }
            velocity = Vector3.ClampMagnitude(velocity, MaxSpeed);
            transform.position += velocity * Time.deltaTime;
            goToFinger = false;
        } else
        {
            if (velocity.sqrMagnitude < 0.1)
            {
                velocity = Vector3.zero;
            } else
            {
                transform.position += velocity * Time.deltaTime;
                velocity = velocity * Mathf.Min(0.9f,0.17f/Time.deltaTime);
            }
        }
    }
}
