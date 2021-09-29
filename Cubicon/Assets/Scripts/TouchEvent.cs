using UnityEngine;
using UnityEngine.Events;

public class TouchEvent : MonoBehaviour
{
    public bool WorkOnce = false;
    public UnityAction OnTouchEvent;

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
