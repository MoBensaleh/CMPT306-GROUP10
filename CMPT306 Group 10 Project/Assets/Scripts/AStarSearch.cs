using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarSearch : MonoBehaviour
{
	GridMap gridMap;
    SearchHandler searchHandler; 

	void Awake() {
		gridMap = GetComponent<GridMap> ();
        searchHandler = GetComponent<SearchHandler>();
	}

    public void StartSearch(Vector3 beginning, Vector3 end) {
        StartCoroutine(Search(beginning, end));
    }

	IEnumerator Search(Vector3 beginning, Vector3 end) {
        HeapArray<State> openSet = new HeapArray<State>(gridMap.LargestSize);
        State goal = gridMap.RetrieveState(end);
		State start = gridMap.RetrieveState(beginning);
        openSet.Enqueue(start);

        HashSet<State> cameFrom = new HashSet<State>();
        Vector3[] intermediates = new Vector3[0];

        bool foundPath = false;
        while (openSet.Count > 0) {
            State present = openSet.Dequeue();
            cameFrom.Add(present);

            if (present == goal) {
                foundPath = true;
                intermediates = ReconstructPath(start, goal);
                break;
            } else {
                List<State> adjacents = gridMap.RetrieveAdjacentStates(present);
                foreach (State s in adjacents) {
                    if (cameFrom.Contains(s) || !(s.unblocked)) continue;
                    else {
                        int yWeight = Mathf.Abs(present.yCoordinate - s.yCoordinate);
                        int xWeight = Mathf.Abs(present.xCoordinate - s.xCoordinate);
                        int edgeWeight = 0;
                        if (xWeight < yWeight){
                            edgeWeight = 10 * (yWeight-xWeight) + 14 * xWeight;
                        }
                        else {
                            edgeWeight = 10 * (xWeight-yWeight) + 14 * yWeight;
                        }
                        int tentativeCost = present.gOfN + edgeWeight;


                        if (!(openSet.Contains(s)) || tentativeCost < s.gOfN) {
                            s.parent = present;
                            s.gOfN = tentativeCost;
                            yWeight = Mathf.Abs(s.yCoordinate - goal.yCoordinate);
                            xWeight = Mathf.Abs(s.xCoordinate - goal.xCoordinate);
                            if (xWeight < yWeight) {
                                s.hOfN =  (10 * (yWeight-xWeight) + 14 * xWeight) * s.cost;
                            }
                            else {
                                s.hOfN =  (10 * (xWeight-yWeight) + 14 * yWeight) * s.cost;
                            }
                
                            if (!openSet.Contains(s))
                                openSet.Enqueue(s);
                            else 
                                openSet.UpdateState(s);
                        }
                    }
                }
            }
        }
        yield return null;

        searchHandler.FinishedPresentSearch(intermediates, foundPath);
	}

	Vector3[] ReconstructPath(State beginning, State end) {
        State present = end;
		List<State> path = new List<State>();
        List<Vector3> intermediates = new List<Vector3>();
        Vector2 previousWay = Vector2.zero;

		while (beginning != present) {
			path.Add(present);
			present = present.parent;
		}

        for (int i = 1; i < path.Count; i++) {
            Vector2 newWay = new Vector2(path[i - 1].xCoordinate - path[i].xCoordinate, path[i - 1].yCoordinate - path[i].yCoordinate);
            if (previousWay != newWay) intermediates.Add(path[i - 1].location);
            previousWay = newWay;
        }

        Vector3[] intermediatesArray = intermediates.ToArray();
		Array.Reverse(intermediatesArray);

        return intermediatesArray;
	}
}