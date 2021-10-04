using System.Collections.Generic;
using UnityEngine;

public class TowerLeveler : MonoBehaviour
{
    public void AlignTowerOfFigures(List<Figure> figures)
    {
        float postionY = figures[0].transform.position.y;
        for (int i = 0; i < figures.Count; i++)
        {
            figures[i].transform.position = new Vector3(0, postionY, 0);
            postionY += figures[i].Height;
        }
    }
}
