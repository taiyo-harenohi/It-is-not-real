using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // pan speed of camera
    private float panSpeed = 15f;
    private float panBorderThickness = 20f;

    public Vector2 panLimitMin;
    public Vector2 panLimitMax;

    private float scrollSpeed = 30f;

    private float minScroll = 10f;
    private float maxScroll = 20f;

    void Update()
    {
        if(!Start_Cutscene.isVisible)
        {
            Vector3 pos = transform.position;

            // for going up
            if (Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                pos.y += panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.y <= panBorderThickness)
            {
                pos.y -= panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x <= panBorderThickness)
            {
                pos.x -= panSpeed * Time.deltaTime;
            }

            // scroll things
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            Camera.main.orthographicSize -= scroll * scrollSpeed * 50f * Time.deltaTime;

            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minScroll, maxScroll);
            // pan limits == map has certain size
            pos.x = Mathf.Clamp(pos.x, panLimitMin.x, panLimitMax.x);
            pos.y = Mathf.Clamp(pos.y, panLimitMin.y, panLimitMax.y);

            transform.position = pos;
        }
    }
}
