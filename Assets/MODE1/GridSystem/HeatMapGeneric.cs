using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HeatMapGeneric : MonoBehaviour
{
    private Grid<Tilemap.TilemapObject> grid;
    private Mesh mesh;
    private bool updateMesh;

    public class TileMapUV : MonoBehaviour
    {
        public struct TilemapSpriteUV
        {
            public Tilemap.TilemapObject.TilemapSprite tilemapSprite;
        } 
    }

    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    public void SetGrid( Grid<Tilemap.TilemapObject> grid)
    {
        this.grid = grid;
        UpdateHeatMapVisual();
        this.GetComponent<MeshRenderer>().sortingOrder = 2;
        grid.OnGridValueChanged += Grid_OnGridValueChanged;
    }

    private void Grid_OnGridValueChanged(object sender, Grid<Tilemap.TilemapObject>.OnGridValueChangedEventArgs
        e)
    {
        updateMesh = true;
    }

    private void LateUpdate()
    {
        if (updateMesh)
        {
            updateMesh = false;
            UpdateHeatMapVisual();
        }
    }

    private void UpdateHeatMapVisual()
    {
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                int index = x * grid.GetHeight() + y;
                Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize();

                Tilemap.TilemapObject gridObject = grid.GetValue(x, y);
                Tilemap.TilemapObject.TilemapSprite tilemapsprite = gridObject.GetTilemapSprite();
                Vector2 gridValueUV00, gridValueUV11;
                if(tilemapsprite== Tilemap.TilemapObject.TilemapSprite.Ground)
                {
                    gridValueUV00 = Vector2.zero;
                    gridValueUV11 = Vector2.zero;
                    quadSize = Vector3.zero;
                }
                else
                {
                    gridValueUV00 = Vector2.zero;
                    gridValueUV11 = Vector2.one;
                }
                MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y) + quadSize * .5f, 0f, quadSize, gridValueUV00, gridValueUV11);
                

            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

}