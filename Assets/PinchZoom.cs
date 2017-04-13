using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public float zoomSpeed = 1f;        // The rate of change of the orthographic size in orthographic mode.
    float newScale = 1f;

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            newScale += deltaMagnitudeDiff * zoomSpeed;
            if (newScale <= 0) newScale = 0.1f;
            transform.localScale = Vector3.one * newScale;
        }
        else if (Input.touchCount == 0)
        {
            if (newScale == 1 || newScale == 2)
            {
                // do nothing
            } else {
                if (newScale < 1)
                {
                    newScale += Time.deltaTime;
                    if (newScale >= 1) newScale = 1;
                }
                else if (newScale > 2)
                {
                    newScale -= Time.deltaTime;
                    if (newScale <= 2) newScale = 2;
                }
                else if (newScale < 1.5f)
                {
                    newScale -= Time.deltaTime;
                    if (newScale <= 1) newScale = 1;
                }
                else if (newScale >= 1.5f)
                {
                    newScale += Time.deltaTime;
                    if (newScale >= 2) newScale = 2;
                }
                if (newScale <= 0) newScale = 0.1f;
                transform.localScale = Vector3.one * newScale;
            }
        }
    }
}