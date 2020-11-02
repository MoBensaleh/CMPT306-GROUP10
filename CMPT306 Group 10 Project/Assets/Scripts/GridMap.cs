using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMap : MonoBehaviour
{
    public bool ShowGrid;
    public LayerMask blockedLayer;
    Vector2 size;
    int xLength, yLength;
    float sectionDiameter;
    public float sectionRadius;
    State[,] gridMap;
    DungeonGenerator dungeonGenerator;
    int xStart, xEnd, yStart, yEnd;
    BoundsInt bounds;
    public int LargestSize {
        get {
            return xLength*yLength;
        } set {
            LargestSize = value;
        }
    }

    void Awake() {
        dungeonGenerator = GetComponent<DungeonGenerator>();
        // updateGridMap();
    }

    public void updateGridMap() {
        Tilemap tileMap = dungeonGenerator.getPitMap();
        bounds = tileMap.cellBounds;
        size = new Vector2(bounds.xMax - bounds.xMin, bounds.yMax - bounds.yMin);

        sectionDiameter = 2 * sectionRadius;
        xLength = Mathf.RoundToInt(size.x/sectionDiameter);
        yLength = Mathf.RoundToInt(size.y/sectionDiameter);

        gridMap = new State[xLength, yLength];
        // Vector2 transform2D = new Vector2(transform.position.x, transform.position.y);
        Vector3 transformAdjusted = new Vector3(bounds.center.x, bounds.center.y, 0);
        Vector3 leftCorner = transformAdjusted - (size.y)/2 * Vector3.up - (size.x)/2 * Vector3.right;
            
        for (int i = 0; i < xLength; i++) {
            for (int j = 0; j < yLength; j++) {
                Vector3 location = leftCorner + Vector3.up * (sectionRadius + j * sectionDiameter) + Vector3.right * (sectionRadius + i * sectionDiameter);
                // bool unblocked = !(Physics2D.OverlapCircle(location, sectionRadius, blockedLayer));
                bool unblocked = !(checkBlocked(location));
                gridMap[i,j] = new State(unblocked, location, i, j);
            }
        }
    }

    public bool checkBlocked(Vector3 location) {
        Vector3Int pos = new Vector3Int(Mathf.FloorToInt(location.x), Mathf.FloorToInt(location.y), 0);

        Tilemap pitmap = dungeonGenerator.getPitMap();
        // Tilemap wallmap = dungeonGenerator.getWallMap();
        Tilemap groundmap = dungeonGenerator.getGroundMap();

        Tile pitTile = dungeonGenerator.getPitTile();
        // Tile topWallTile = dungeonGenerator.getTopWallTile();
        // Tile botWallTile = dungeonGenerator.getBotWallTile();
        Tile groundTile = dungeonGenerator.getGroundTile();

        if (pitmap.GetTile(pos) == pitTile && groundmap.GetTile(pos) != groundTile) {
            return true;
        } else {
            return false;
        }

    }

    public State RetrieveState(Vector3 location) {
        // int i = Mathf.RoundToInt((xLength - 1) * Mathf.Clamp01(((size.x)/2 + location.x) / size.x));
        // int j = Mathf.RoundToInt((yLength - 1) * Mathf.Clamp01(((size.y)/2 + location.y) / size.y));
        int i = Mathf.RoundToInt((xLength - 1) * Mathf.Clamp01(((size.x)/2 + location.x - bounds.center.x) / size.x));
        int j = Mathf.RoundToInt((yLength - 1) * Mathf.Clamp01(((size.y)/2 + location.y - bounds.center.y) / size.y));

        return gridMap[i,j];
    }

    public List<State> RetrieveAdjacentStates(State s) {
        List<State> adjacentStates = new List<State>();
        for (int i = -1; i <= 1; i ++) {
            for (int j = -1; j <= 1; j++) {
                if (i == 0 && j ==0) {
                    continue;
                }
                if ( 0 <= i + s.xCoordinate && i + s.xCoordinate < xLength && j + 0 <= s.yCoordinate && j + s.yCoordinate < yLength) {
                    adjacentStates.Add(gridMap[i + s.xCoordinate, j + s.yCoordinate]);
                }
            }
        }
        return adjacentStates;
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(size.x, size.y, 1));
        if (ShowGrid && gridMap != null) {
            foreach (State s in gridMap) {
                if (s.unblocked) Gizmos.color = Color.white;
                else Gizmos.color = Color.red;
                Gizmos.DrawCube(s.location, (sectionDiameter - 0.1f) * Vector3.one);
            }
        }
    }
}
