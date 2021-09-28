using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Speed = 2f;

    private Vector3 _futurePositionCamera;
    private Vector3 _startCameraPosition;

    private void Awake()
    {
        _startCameraPosition = transform.position;
        _futurePositionCamera = transform.position;
    }

    public void RaiseCamera(float heightSize)
    {
        _futurePositionCamera.y += heightSize;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _futurePositionCamera, Speed * Time.deltaTime);
    }
}
