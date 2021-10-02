using UnityEngine;

public class LoseWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Lose");
    }
}
