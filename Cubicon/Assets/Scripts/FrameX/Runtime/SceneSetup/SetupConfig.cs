using UnityEngine;

public abstract class SetupConfig : MonoBehaviour
{
    //Устанавливает все зависимости сцены
    public virtual void OnAwake() { }
    public virtual void OnStart() { }

    //При выгрузке сцены выгружает ненужные объекты
    public virtual void OnDispose() { }
}
