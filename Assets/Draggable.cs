using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour {

    bool dragging = false;
    bool useMouse = false;
    float initialScale = 1;

    RectTransform rt;

	// Use this for initialization
	void Start () {
        initialScale = transform.localScale.x;
        rt = GetComponent<RectTransform>();
	}

    void Drag(Vector2 screenPos)
    {
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(screenPos);
        targetPos.z = 0;
        transform.localPosition = targetPos;
    }

    void DetectTouch(Vector2 screenPos)
    {
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(screenPos);
        targetPos.z = 0;
        float radius = (rt.rect.width * transform.localScale.x) / 2;
        if ((targetPos - transform.position).sqrMagnitude < radius * radius)
        {
            dragging = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // touch
        if (Input.touchCount > 0) {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                DetectTouch(Input.GetTouch(0).position);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                dragging = false;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (dragging) Drag(Input.GetTouch(0).position);
            }
        }
        if (Input.GetMouseButton(0))
        {
            useMouse = true;
            DetectTouch(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        if (useMouse && dragging)
        {
            Drag(Input.mousePosition);
        }

        if (dragging)
        {
            transform.localScale = Vector3.one * initialScale * 1.2f;
        } else
        {
            transform.localScale = Vector3.one * initialScale;
        }
    }
}
