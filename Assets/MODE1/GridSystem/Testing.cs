using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private HeatMapBool heatmapbool;

    [SerializeField] private HeatMapGeneric HeatMapGeneric;
    [SerializeField] private PathFinderHeatMap NodeHeatMap;
    [SerializeField] private GridCharacter character;
    [SerializeField] private GridCharacter Enemy;
    private PathFinder pathFinder;
    private Tilemap tilemap;
    private bool teste=true;
    private Vector2 movement;

    private Grid<HeatMapGridObject> grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid<HeatMapGridObject>(10, 10, 20f, Vector3.zero, (Grid<HeatMapGridObject> g, int x, int y) => new HeatMapGridObject(g, x, y),false);

        
        pathFinder = new PathFinder(10, 10,20);
        tilemap = new Tilemap(10, 10, 20, Vector3.zero);
        tilemap.SetTilemapVisual(HeatMapGeneric);
        Enemy.SetTargetPosition(character.GetPosition());
        //HeatMapGeneric.SetGrid(grid);
        //  NodeHeatMap.SetGrid(pathFinder.GetGrid());



    }
    void Update()
    {
     

        Enemy.setSpeed(20f);



        Enemy.SetTargetPosition(character.GetPosition());

        if (Input.GetMouseButtonDown(0))
            {
                Vector3 position = Utils.GetMouseWorldPosition();
                 
            
                pathFinder.GetGrid().GetXY(position, out int x, out int y);
                List<PathNode> path = pathFinder.FindPath(0, 0, x, y);
                if (path != null)
                {
                    for (int i = 0; i < path.Count - 1; i++)
                    {

                        // Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.black, 2f);
                    }
                }
                character.SetTargetPosition(position);
                




        }
        
        if (Input.GetMouseButtonDown(1))
        {
            

            Vector3 position = Utils.GetMouseWorldPosition();
            tilemap.SetTilemapSprite(position, Tilemap.TilemapObject.TilemapSprite.Wall);
            pathFinder.GetGrid().GetXY(position, out int x, out int y);
            pathFinder.GetNode(x, y).IsWalkable = !pathFinder.GetNode(x, y).IsWalkable;
            HeatMapGridObject obj = grid.GetWorldValue(position);
            if (obj != null)
            {
                obj.AddValue(1);
            }
        }
        
    }
    public class HeatMapGridObject {
        private const int MIN = 0;
        private const int MAX =1;
        private int value;
        private Grid<HeatMapGridObject> grid;
        private int x;
        private int y;

        public HeatMapGridObject (Grid<HeatMapGridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }

        public void AddValue(int addvalue)
        {
            if (value == MAX)
            {
                value = MIN;
            }
            else
            {
                value += addvalue;
            }
            value = Mathf.Clamp(value, MIN, MAX);
             
            grid.TriggerGridObjectsChanged(x, y);
            Debug.Log(value);

        }
        public float GetValueNormalized()
        {
            return (float)(value / MAX);
        }

        public override string ToString()
        {
            return value.ToString();
            
        }
    }
}
