using UnityEngine;

public class RTSCameraController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;


    [Header("Zoom Settings")]
    public float zoomSpeed = 10f;
    public float minZoom = 5f;
    public float maxZoom = 50f;
    public float zoomDampening = 5f;

    private Vector3 dragOrigin;
    private Vector3 cameraVelocity;
    private float targetZoom;
    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        targetZoom = cam.orthographic ? cam.orthographicSize : cam.transform.position.y;
    }

    void Update()
    {
        HandleCameraMovement();
        HandleZoom();
    }

    void HandleCameraMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        // Перемещение при зажатии ПКМ
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 difference = cam.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
            moveDirection = new Vector3(difference.x, 0, difference.y) * moveSpeed;
            dragOrigin = Input.mousePosition;
        }

       

        // Применяем движение
        if (moveDirection != Vector3.zero)
        {
            Vector3 desiredMove = transform.forward * moveDirection.z + transform.right * moveDirection.x;
            desiredMove.y = 0; // Не двигаем по Y (высоте)
            
            if (Input.GetMouseButton(1))
            {
                transform.position += desiredMove * moveSpeed * Time.deltaTime;
            }

        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        print(scroll);
        if (scroll != 0f)
        {
            if (cam.orthographic)
            {
                targetZoom -= scroll * zoomSpeed;
                targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomDampening);
            }
            else
            {
                targetZoom -= scroll * zoomSpeed;
                targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
                
                Vector3 newPosition = transform.position;
                newPosition.y = Mathf.Lerp(transform.position.y, targetZoom, Time.deltaTime * zoomDampening);
                transform.position = newPosition;
            }
        }
    }
}