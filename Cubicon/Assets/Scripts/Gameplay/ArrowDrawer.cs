using UnityEngine;

public class ArrowDrawer : MonoBehaviour
{
    public float Height = 4.3f;
    [SerializeField] private LineRenderer _arrow;
    private Vector3[] _points;

    public void DrawArrow(Transform topPosition)
    {
        _points = new Vector3[]
        {
            new Vector3(topPosition.position.x, topPosition.position.y - Height, topPosition.position.z),
            topPosition.position
        };
        _arrow.SetPositions(_points);
    }

    public void ActiveArrow()
    {
        _arrow.enabled = true;
    }

    public void DisableArrow()
    {
        _arrow.enabled = false;
    }
}
