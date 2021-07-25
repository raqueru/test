﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HeatMapBool : MonoBehaviour
{
    private Grid<bool> grid;
    private Mesh mesh;
    private bool updateMesh;
    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    public void SetGrid(Grid<bool> grid)
    {
        this.grid = grid;
        UpdateHeatMapVisual();
        grid.OnGridValueChanged += Grid_OnGridValueChanged;

    }
    private void Grid_OnGridValueChanged(object sender,Grid<bool>.OnGridValueChangedEventArgs e)
    {
        UpdateHeatMapVisual();
    }
    private void UpdateHeatMapVisual()
    {
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth()*grid.GetHeight(), out Vector3[] vertices, out Vector2[] uvs, out int[] triangles);
        for(int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                int index = x * grid.GetHeight() + y;
                Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize();
                bool gridValue = grid.GetValue(x, y);
                float gridValueNormalized = gridValue ? 1f : 0f;
                Vector2 gridValueUV = new Vector2(gridValueNormalized, 0f);
                MeshUtils.AddToMeshArrays(vertices, uvs, triangles, index, grid.GetWorldPosition(x, y)+quadSize*.5f, 0f
                    , quadSize,gridValueUV,gridValueUV);

            }
        }
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;
    }
}

