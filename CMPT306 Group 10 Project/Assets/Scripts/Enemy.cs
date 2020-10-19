using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Material material;
	public Transform goal;
    Vector3 goalLocation;
	public float speed = 3;
	Vector3[] pathToGoal;
    bool searchRunning = false;
	int searchIndex;
    public int timeBreak = 1;
    float timeCheck;

    void Start() {
        material = GetComponent<Renderer>().material;
        timeCheck = timeBreak;
    }

    void Update() {
        timeCheck += Time.deltaTime;
        if (Mathf.RoundToInt(timeCheck) >= timeBreak && !searchRunning && CheckGoalPosition()){
            searchRunning = true;
            ResetSearch();
            goalLocation = goal.position;
            SearchHandler.RequestSearch(transform.position,goalLocation, searchFinished);
            timeCheck = 0;
        }
	}

    public bool CheckGoalPosition() {
        return goal.position != goalLocation;
    }

    public void ResetSearch() {
        searchIndex = 0;
        pathToGoal = new Vector3[0];
    }

	public void searchFinished(Vector3[] searchPath, bool searchSuccess) {
		if (searchSuccess) {
			pathToGoal = searchPath;
			searchIndex = 0;

			StopCoroutine(FollowSearch());

			StartCoroutine(FollowSearch());

            searchRunning = false;
		}
	}

	IEnumerator FollowSearch() {
        if (0 < pathToGoal.Length) {            
            Vector3 presentIntermediate = pathToGoal[0];
            while (true) {
                if (presentIntermediate == transform.position) {
                    searchIndex += 1;
                    if (pathToGoal.Length <= searchIndex) {
                        ResetSearch();
                        yield break;
                    }
                    presentIntermediate = pathToGoal[searchIndex];
                }

                transform.position = Vector3.MoveTowards(transform.position,presentIntermediate,speed * (Time.deltaTime));
                if (CheckGoalPosition()) {
                    ResetSearch();
                    yield break;
                }
                yield return null;

            }
        } else yield break;
	}

	public void OnDrawGizmos() {
		if (null != pathToGoal) {
			for (int i = searchIndex; i < pathToGoal.Length; i ++) {
				Gizmos.color = material.color;
				if (i != searchIndex) Gizmos.DrawLine(pathToGoal[i-1],pathToGoal[i]);
				else Gizmos.DrawLine(transform.position, pathToGoal[i]);
			}
		}
	}
}
