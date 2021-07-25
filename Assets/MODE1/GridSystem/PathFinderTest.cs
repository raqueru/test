using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderTest : MonoBehaviour
{
    [SerializeField] private PathFinderHeatMap NodeHeatMap;
    private PathFinder pathFinder;
    // Start is called before the first frame update
    void Start()
    {
         pathFinder = new PathFinder(10,10,20);
         //NodeHeatMap.SetGrid(pathFinder.GetGrid());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = Utils.GetMouseWorldPosition();
            pathFinder.GetGrid().GetXY(position, out int x, out int y);
            List<PathNode> path = pathFinder.FindPath(0, 0,x,y);
            if (path != null)
            {
                for (int i=0;i<path.Count-1;i++)
                {

                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green, 5f);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 position = Utils.GetMouseWorldPosition();
            pathFinder.GetGrid().GetXY(position, out int x, out int y);
            pathFinder.GetNode(x, y).IsWalkable = !pathFinder.GetNode(x, y).IsWalkable;
        }
    }
}
