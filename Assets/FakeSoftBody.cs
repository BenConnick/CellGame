using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeSoftBody : MonoBehaviour {

    public GameObject tailPrefab;
    public int NumTailSegments; // set in inspector
    public float TailMinScale; // set in inspector
    float initialScale;

    GameObject[] tailSegments;

    List<Vector3> positions;
    Vector3[] scales;

    int count = 0;
    int countCheck = 1;

    // Use this for initialization
    void Start () {
        initialScale = transform.localScale.x;
        // create an array for the tail segments
        tailSegments = new GameObject[NumTailSegments];
        scales = new Vector3[NumTailSegments];
        for (int i=0; i<NumTailSegments; i++)
        {
            tailSegments[i] = GameObject.Instantiate(tailPrefab,transform.parent);
            float scaleDelta = 1 - TailMinScale;
            float scale = 1 - (i*i / (float)(NumTailSegments*NumTailSegments)) * scaleDelta;
            scales[i] = new Vector3(scale, scale, scale);
            tailSegments[i].transform.localScale = scales[i];
        }
        // create an array for the positions
        positions = new List<Vector3>();
        for (int i = 0; i < NumTailSegments; i++)
        {
            positions.Add(transform.position);
        }
    }
	
	// Update is called once per frame
	void Update () {
        float speed = 0;

        // check if the positions has changed
        if (positions[NumTailSegments - 1] != transform.position)
        {
            // get speed
            speed = (transform.position - positions[NumTailSegments - 1]).magnitude;

            // remove oldest
            positions.RemoveAt(0);
            // add newest
            positions.Add(transform.position);
        }
        for (int i=0; i<NumTailSegments; i++)
        {
            float newScale = (initialScale / (speed / 2 + 1));
            transform.localScale = Vector3.one * newScale;
            tailSegments[i].transform.localScale = scales[i] * newScale;
            tailSegments[i].transform.position = positions[NumTailSegments - 1 - i];
        }
	}
}
