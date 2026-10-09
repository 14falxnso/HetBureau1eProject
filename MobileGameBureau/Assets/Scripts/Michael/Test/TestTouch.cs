using UnityEngine;

public class TouchTest : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch!");

                Vector2 position = touch.position;

                Debug.Log("Touch positie: " + position);
            }
        }
    }
}