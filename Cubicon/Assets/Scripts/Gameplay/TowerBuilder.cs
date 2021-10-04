using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder
{
    private int _numberOfSimulatingFigures = 5;

    private Queue<Figure> _activeFigureInTower = new Queue<Figure>(10);

    public TowerBuilder(int numberOfSimulatingFigures)
    {
        _numberOfSimulatingFigures = numberOfSimulatingFigures;
    }


    public void AddFigure(Figure newFigure)
    {
        _activeFigureInTower.Enqueue(newFigure);

        if (_activeFigureInTower.Count >= _numberOfSimulatingFigures)
        {
            Figure lastFigure = _activeFigureInTower.Dequeue();
            FrozeFigure(_activeFigureInTower.Peek().Rigidbody);
            PoolManager.Instance.ReturnObjectToPool(lastFigure.gameObject);
        }
        else if (_activeFigureInTower.Count == _numberOfSimulatingFigures - 1)
        {
            FrozeFigure(_activeFigureInTower.Peek().Rigidbody);
        }
    }

    public void ResetState()
    {
        foreach (var figure in _activeFigureInTower)
        {
            PoolManager.Instance.ReturnObjectToPool(figure.gameObject);
        }

        _activeFigureInTower.Clear();
    }

    private void FrozeFigure(Rigidbody figureRigidBody)
    {
        figureRigidBody.isKinematic = true;
    }
}
