using UnityEngine;

public class Drag3D : MonoBehaviour
{
    private Transform _tr;
    
    private Camera _camera;   // Reference to the main camera
    private bool _isDragging;  // Flag to check if dragging
    private float _distanceToCamera;  // Distance from object to camera
    public float Traveled { get; private set; }

    void Start()
    {
        _tr = transform;
        _camera = Camera.main;  // Get the main camera
    }

    void OnMouseDown()
    {
        // Calculate the distance from the object to the camera
        Vector3 position = _tr.position;
        _distanceToCamera = Vector3.Distance(position, _camera.transform.position);

        _isDragging = true;  // Set the dragging flag
    }

    void OnMouseDrag()
    {
        if (_isDragging)
        {
            // Move the cube to follow the mouse
            Vector3 mouseWorldPoint = GetMouseWorldPosition();
            Vector3 aux = _tr.position;
            _tr.position = new Vector3(mouseWorldPoint.x, mouseWorldPoint.y, aux.z);

            Traveled += (_tr.position - aux).magnitude;
            Debug.Log(Traveled);
        }
    }

    void OnMouseUp()
    {
        _isDragging = false;  // Clear the dragging flag
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get the mouse position in screen space and convert it to world space
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        return ray.GetPoint(_distanceToCamera);  // Get the point in 3D space
    }

    public void ResetTraveledDistance()
    {
        Traveled = 0;
    }
}