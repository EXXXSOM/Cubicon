using UnityEngine;

public class FrozenFigure : Figure
{
    public override void OnHit()
    {
        _rigidBody.isKinematic = true;
        transform.rotation = Quaternion.identity;
    }
}
