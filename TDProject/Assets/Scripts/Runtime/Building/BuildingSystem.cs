using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem instance;

    public GridLayout gridLayout;
    private Grid _grid;
    [SerializeField] private Tilemap mainTileMap;
    [SerializeField] private TileBase whiteTile;

    public GameObject prefab1;

    private PlaceableObjects _objectToPlace;

    private void Awake()
    {
        instance = this;
        _grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            InitialzeWithObject(prefab1);
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray , out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        return Vector3.zero;
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = _grid.GetCellCenterWorld(cellPos);
        return position;
    }
    
    public void InitialzeWithObject(GameObject prefab)
    {
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);
        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        _objectToPlace = obj.GetComponent<PlaceableObjects>();
        obj.AddComponent<ObjectDrag>();
    }
}
