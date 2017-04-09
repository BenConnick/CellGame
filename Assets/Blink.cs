using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    public GameObject eyesClosed;
    public GameObject eyesOpen;

    // how long the eyes should be open
    float[] eyesOpenForTime = { 1, 0.2f, 2 };

    // which value of eyesOpenForTime is next?
    int segment = 0;

	// Use this for initialization
	void Start () {
        BeginNextBlinkSegment();
	}

    void BeginNextBlinkSegment()
    {
        segment++;
        if (segment >= eyesOpenForTime.Length) segment = 0;
        // wait for a while then close the eyes, which will call this function again
        StartCoroutine(WaitThenClose(eyesOpenForTime[segment]));
    }

    void SetEyeOpen(bool open)
    {
        eyesClosed.SetActive(!open);
        eyesOpen.SetActive(open);
    }

    IEnumerator WaitThenClose(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SetEyeOpen(false);
        StartCoroutine(WaitThenOpen());
    }

    IEnumerator WaitThenOpen()
    {
        yield return new WaitForSeconds(0.1f);
        SetEyeOpen(true);
        BeginNextBlinkSegment();
    }
}
