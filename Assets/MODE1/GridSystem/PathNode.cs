using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private Grid<PathNode> grid;
    public int x;
    public int y;

    public int gCost;
    public int hCost;
    public int fCost;
    public PathNode cameFromNode;
    public bool IsWalkable;
    public PathNode(Grid<PathNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        IsWalkable = true;
    }
    public override string ToString()
    {
        return x + "," + y;
    }

   public void CalculateFcost()
    {
        fCost = gCost + hCost;
    }
}

