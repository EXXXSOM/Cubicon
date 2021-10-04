using UnityEngine;

public class LoseWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameplayController.Instance.LoseGame();
    }
}
