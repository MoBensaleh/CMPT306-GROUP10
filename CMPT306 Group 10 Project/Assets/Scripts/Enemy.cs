using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{
    Material material;
	Transform goal;
    Vector3 goalLocation;
	public float speed = 1f;
	Vector3[] pathToGoal;
    bool searchRunning = false;
    bool followingInProgress = false;
	int searchIndex;
    public int timeBreak = 0;
    float timeCheck;
    float freezeTime;
    bool stunned;
    GameObject grid;
    GridMap gridMap;
    Tilemap groundMap;
    Tile groundTile;
    Tile secondGroundTile;
    Renderer renderer;


    void Start() {
        
        material = GetComponent<Renderer>().material;
        timeCheck = timeBreak;
        freezeTime = 0;
        stunned = false;

        grid = GameObject.Find("Grid");
        gridMap = grid.GetComponent<GridMap>();
        groundMap = grid.GetComponent<DungeonGenerator>().getGroundMap();
        groundTile = grid.GetComponent<DungeonGenerator>().getGroundTile();
        secondGroundTile = grid.GetComponent<DungeonGenerator>().getSecondGroundTile(); 

        GameObject player = GameObject.Find("Player");
        goal = player.GetComponent<Transform>();

        renderer = GetComponent<Renderer>();
    }

    void FixedUpdate() {
        
        timeCheck += Time.deltaTime;
        if (Mathf.RoundToInt(freezeTime) > 0 && stunned) {
            freezeTime -= Time.deltaTime;
        }
        else if (Mathf.RoundToInt(timeCheck) >= timeBreak && !searchRunning && CheckGoalPosition()){
            freezeTime = 0;
            stunned = false;
            searchRunning = true;
            // ResetSearch();
            goalLocation = goal.position;
            SearchHandler.RequestSearch(transform.position,goalLocation, searchFinished);
            timeCheck = 0;

        
        }
	}

    public void StunEnemy(int time) {
        freezeTime += time;
        stunned = true;

        if (searchRunning) {
            searchRunning = false;
            StopCoroutine(FollowSearch());
            ResetSearch();
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
            while (!stunned) {
                if (presentIntermediate == transform.position) {
                    searchIndex += 1;
                    if (pathToGoal.Length <= searchIndex) {
                        ResetSearch();
                        break;
                    }
                    presentIntermediate = pathToGoal[searchIndex];
                }

                int tileCost = 4;
                int lightCost = 1;
                Vector3Int pos = new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0);
                if (groundMap.GetTile(pos) == secondGroundTile) tileCost *= 2;
                if (renderer.isVisible) lightCost *= 2;
                transform.position = Vector3.MoveTowards(transform.position,presentIntermediate,speed * lightCost / tileCost * (Time.deltaTime) );
                if (CheckGoalPosition()) {
                    ResetSearch();
                    break;
                } 
                yield return null;
            }
        } 
	}
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Cross" ||  other.gameObject.tag == "Awakening" || other.gameObject.tag == "Blessing"
            || other.gameObject.tag == "Candle" || other.gameObject.tag == "Key" || other.gameObject.tag == "Boost" ||
            other.gameObject.tag == "BoxandPlate" || other.gameObject.tag == "Box" || other.gameObject.tag == "Statue")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            
        }
        
    }

    public bool onTerminus() {
        bool check = gridMap.checkTerminus(transform.position);
        Debug.Log(check);
        return check;
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
