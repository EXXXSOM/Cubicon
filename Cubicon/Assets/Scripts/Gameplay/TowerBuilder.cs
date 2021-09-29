using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public int NumberOfSimulatingFigures = 5;

    private Queue<Figure> _activeFigureInTower = new Queue<Figure>(10);

    public void AddFigure(Figure newFigure)
    {
        if (_activeFigureInTower.Count + 1 >= NumberOfSimulatingFigures)
        {
            Debug.Log(_activeFigureInTower.Count);
            Figure lastFigure = _activeFigureInTower.Dequeue();
            FrozeFigure(lastFigure.Rigidbody);
        }

        _activeFigureInTower.Enqueue(newFigure);
    }

    private void FrozeFigure(Rigidbody figureRigidBody)
    {
        figureRigidBody.isKinematic = true;
    }
}
