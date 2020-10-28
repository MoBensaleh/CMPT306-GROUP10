using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    public bool ShowGrid;
    public LayerMask blockedLayer;
    public Vector2 size;
    int xLength, yLength;
    float sectionDiameter;
    public float sectionRadius;
    State[,] gridMap;
    public int LargestSize {
        get {
            return xLength*yLength;
        } set {
            LargestSize = value;
        }
    }

    void Awake() {
        sectionDiameter = 2 * sectionRadius;
        xLength = Mathf.RoundToInt(size.x/sectionDiameter);
        yLength = Mathf.RoundToInt(size.y/sectionDiameter);

        gridMap = new State[xLength, yLength];
        Vector3 leftCorner = transform.position - (size.y)/2 * Vector3.up - (size.x)/2 * Vector3.right;
            
        for (int i = 0; i < xLength; i++) {
            for (int j = 0; j < yLength; j++) {
                Vector3 location = leftCorner + Vector3.up * (sectionRadius + j * sectionDiameter) + Vector3.right * (sectionRadius + i * sectionDiameter);
                bool unblocked = !(Physics.CheckSphere(location, sectionRadius, blockedLayer));
                gridMap[i,j] = new State(unblocked, location, i, j);
            }
        }
    }

    public State RetrieveState(Vector3 location) {
        int i = Mathf.RoundToInt((xLength - 1) * Mathf.Clamp01(((size.x)/2 + location.x) / size.x));
        int j = Mathf.RoundToInt((yLength - 1) * Mathf.Clamp01(((size.y)/2 + location.y) / size.y));

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
                else Gizmos.color = Color.black;
                Gizmos.DrawCube(s.location, (sectionDiameter - 0.1f) * Vector3.one);
            }
        }
    }
}
