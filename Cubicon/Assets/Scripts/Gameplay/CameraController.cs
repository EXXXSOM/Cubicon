using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Speed = 2f;

    private float _distanceCameraX = 3f;
    private float _distanceCameraZ = 3f;
    private Vector3 _futurePositionCamera;
    private Vector3 _startCameraPosition;

    private void Awake()
    {
        _startCameraPosition = transform.position;
        _distanceCameraX = Mathf.Abs(_startCameraPosition.x);
        _distanceCameraZ = Mathf.Abs(_startCameraPosition.z);

        _futurePositionCamera = transform.position;
    }

    public void RaiseCamera(float heightSize, Transform target)
    {
        _futurePositionCamera.y += heightSize;
        _futurePositionCamera.x = target.position.x - _distanceCameraX;
        _futurePositionCamera.z = target.position.z - _distanceCameraZ;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _futurePositionCamera, Speed * Time.deltaTime);
    }

    public void ResetState()
    {
        _futurePositionCamera = _startCameraPosition;
        transform.position = _startCameraPosition;
    }
}
