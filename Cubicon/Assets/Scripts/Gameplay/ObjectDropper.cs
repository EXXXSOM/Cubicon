using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropper
{
    public void DropPhysicObject(Rigidbody rigidBody)
    {
        rigidBody.isKinematic = false;
    }
}
