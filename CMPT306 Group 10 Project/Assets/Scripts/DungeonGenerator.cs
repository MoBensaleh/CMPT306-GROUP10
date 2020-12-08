using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DungeonGenerator : MonoBehaviour
{

    [SerializeField]
    private Tile groundTile;
    [SerializeField]
    private Tile secondGroundTile;
    [SerializeField]
    private Tile pitTile;
    [SerializeField]
    private Tile topWallTile;
    [SerializeField]
    private Tile botWallTile;
    [SerializeField]
    private Tilemap groundMap;
    [SerializeField]
    private Tilemap pitMap;
    [SerializeField]
    private Tilemap wallMap;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int deviationRate = 10;
    [SerializeField]
    private int roomRate = 15;
    [SerializeField]
    private int maxRouteLength;
    [SerializeField]
    private int maxRoutes = 20;
    public GameObject[] myObjects;

    

    public GameObject Bead;
    private int numOfBeads = 0;
    public int maxBeads;

    public GameObject enemy;
    private int numOfEnemies = 0;
    public int maxEnemies;

    public GameObject keyTask;
    private int task1Items = 0;
    public int maxTask1Items;

    public GameObject cursedStatueTask;
    private int task2Items = 0;
    public int maxTask2Items;

    public GameObject[] pressurePlateTask;
    private int task3Items = 0;
    public int maxTask3Items;





    private int routeCount = 0;

    private void Awake()
    {
        
        int x = 0;
        int y = 0;
        int routeLength = 0;

        GenerateSquare(x, y, 1);
        
        Vector2Int previousPos = new Vector2Int(x, y);
        y += 3;
        GenerateSquare(x, y, 1);
        NewRoute(x, y, routeLength, previousPos);
        



        FillWalls();

    }

    private void Start() {
       

        GridMap gridMap = GetComponent<GridMap>();
        gridMap.updateGridMap();
    }


        
    

    private void FillWalls()
    {
        BoundsInt bounds = groundMap.cellBounds;
        
        for (int xMap = bounds.xMin - 10; xMap <= bounds.xMax + 10; xMap++)
        {
            for (int yMap = bounds.yMin - 10; yMap <= bounds.yMax + 10; yMap++)
            {
               
                Vector3Int pos = new Vector3Int(xMap, yMap, 0);
                Vector3Int posBelow = new Vector3Int(xMap, yMap - 1, 0);
                Vector3Int posAbove = new Vector3Int(xMap, yMap + 1, 0);
                TileBase tile = groundMap.GetTile(pos);
                TileBase tileBelow = groundMap.GetTile(posBelow);
                TileBase tileAbove = groundMap.GetTile(posAbove);

                
                if (tile == null)
                {
                    pitMap.SetTile(pos, pitTile);
                    if (tileBelow != null)
                    {
                        wallMap.SetTile(pos, topWallTile);
                    }
                    else if (tileAbove != null)
                    {
                        wallMap.SetTile(pos, botWallTile);
                    }
                }
            }
        }
    }

    private void NewRoute(int x, int y, int routeLength, Vector2Int previousPos)
    {

        
        if (routeCount < maxRoutes)
        {

            routeCount++;
            while (++routeLength < maxRouteLength)
            {
                //Initialize
                
                bool routeUsed = false;
                int xOffset = x - previousPos.x; //0
                int yOffset = y - previousPos.y; //3
                int roomSize = 1; //Hallway size
                if (Random.Range(1, 100) <= roomRate)
                    roomSize = Random.Range(3, 6);
                previousPos = new Vector2Int(x, y);
                

                //Go Straight
                if (Random.Range(1, 100) <= deviationRate)
                {
                    if (routeUsed)
                    {
                        GenerateSquare(previousPos.x + xOffset, previousPos.y + yOffset, roomSize);
                        
                        

                        NewRoute(previousPos.x + xOffset, previousPos.y + yOffset, Random.Range(routeLength, maxRouteLength), previousPos);
                        
                        int randomIndex = Random.Range(0, myObjects.Length);
                        GameObject instantiatedObject = Instantiate(myObjects[randomIndex], new Vector3(previousPos.x, previousPos.y), Quaternion.identity) as GameObject;

                       

                        try {
                            for(int i = 0; i < GameObject.FindGameObjectsWithTag("Statue").Length; i++)
                            {
                                if (Mathf.Abs(Vector3.Distance(GameObject.FindGameObjectsWithTag("Statue")[i].transform.position, instantiatedObject.transform.position)) <= 5)
                                {
                                    Destroy(instantiatedObject);
                                }
                            }
                        } catch (System.Exception e) {
                            Debug.LogException(e, this);
                        }  

                        
                           
                        
                    }
                    else
                    {
                        x = previousPos.x + xOffset;
                        y = previousPos.y + yOffset;
                        GenerateSquare(x, y, roomSize);
                     
                        int randomIndex = Random.Range(0, myObjects.Length);
                        GameObject instantiatedObject = Instantiate(myObjects[randomIndex], new Vector3(previousPos.x, previousPos.y), Quaternion.identity) as GameObject;

                        if (numOfBeads < maxBeads)
                        {
                            if (Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, keyTask.transform.position)) >= 3)
                            {
                                GameObject instantiatedBead = Instantiate(Bead, new Vector3(previousPos.x + xOffset, previousPos.y + yOffset), Bead.transform.rotation) as GameObject;
                                if (Mathf.Abs(Vector3.Distance(Bead.transform.position, instantiatedBead.transform.position)) < 12)
                                {

                                    Destroy(instantiatedBead);
                                }
                                else
                                {
                                    Bead = instantiatedBead;
                                    numOfBeads++;

                                }
                            }


                        }
                        try {
                            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Statue").Length; i++)
                            {
                                if (Mathf.Abs(Vector3.Distance(GameObject.FindGameObjectsWithTag("Statue")[i].transform.position, instantiatedObject.transform.position)) <= 5)
                                {
                                    Destroy(instantiatedObject);
                                }
                            }
                        } catch (System.Exception e) {
                            Debug.LogException(e, this);
                        }  



                        routeUsed = true;
                    }
                }

                //Go left
                if (Random.Range(1, 100) <= deviationRate)
                {
                    if (routeUsed)
                    {
                        GenerateSquare(previousPos.x - yOffset, previousPos.y + xOffset, roomSize);

                        NewRoute(previousPos.x - yOffset, previousPos.y + xOffset, Random.Range(routeLength, maxRouteLength), previousPos);


                        int randomIndex = Random.Range(0, myObjects.Length);
                        GameObject instantiatedObject = Instantiate(myObjects[randomIndex], new Vector3(previousPos.x, previousPos.y), Quaternion.identity) as GameObject;

                        
                        try {
                            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Statue").Length; i++)
                            {
                                if (Mathf.Abs(Vector3.Distance(GameObject.FindGameObjectsWithTag("Statue")[i].transform.position, instantiatedObject.transform.position)) <= 5)
                                {
                                    Destroy(instantiatedObject);
                                }
                            }
                        } catch (System.Exception e) {
                            Debug.LogException(e, this);
                        }  


                    }
                    else
                    {
                        y = previousPos.y + xOffset;
                        x = previousPos.x - yOffset;
                        GenerateSquare(x, y, roomSize);

                        

                        if (task1Items < maxTask1Items)
                        {
                            if (Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, keyTask.transform.position)) >= 5)
                            {
                                GameObject instantiatedKey = Instantiate(keyTask, new Vector3(previousPos.x, previousPos.y), keyTask.transform.rotation) as GameObject;
                                if (Mathf.Abs(Vector3.Distance(keyTask.transform.position, instantiatedKey.transform.position)) < 30)
                                {

                                    Destroy(instantiatedKey);
                                }
                                else
                                {
                                    keyTask = instantiatedKey;
                                    task1Items++;

                                }
                            }


                        }

                        if (task2Items < maxTask2Items)
                        {
                            if (Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, cursedStatueTask.transform.position)) >= 5)
                            {
                                GameObject instantiatedCursedStatue = Instantiate(cursedStatueTask, new Vector3(previousPos.x, previousPos.y), Quaternion.identity) as GameObject;
                                if (Mathf.Abs(Vector3.Distance(cursedStatueTask.transform.position, instantiatedCursedStatue.transform.position)) < 30)
                                {

                                    Destroy(instantiatedCursedStatue);
                                }
                                else
                                {
                                    cursedStatueTask = instantiatedCursedStatue;
                                    task2Items++;

                                }
                            }


                        }

                        if (task3Items < maxTask3Items)
                        {
                            if (Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, pressurePlateTask[0].transform.position)) >= 5 &&
                                Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, pressurePlateTask[1].transform.position)) >= 5)
                            {
                                GameObject instantiatedBox = Instantiate(pressurePlateTask[0], new Vector3(previousPos.x, previousPos.y), Quaternion.identity) as GameObject;
                                GameObject instantiatedPressurePlate = Instantiate(pressurePlateTask[1], new Vector3(previousPos.x - yOffset, previousPos.y + xOffset), Quaternion.identity) as GameObject;
                                if (Mathf.Abs(Vector3.Distance(pressurePlateTask[0].transform.position, instantiatedBox.transform.position)) < 30 && Mathf.Abs(Vector3.Distance(pressurePlateTask[1].transform.position, instantiatedBox.transform.position)) < 30)
                                {

                                    Destroy(instantiatedBox);
                                    Destroy(instantiatedPressurePlate);
                                }
                                else
                                {
                                    pressurePlateTask[0] = instantiatedBox;
                                    pressurePlateTask[1] = instantiatedPressurePlate;
                                    task3Items++;

                                }
                            }


                        }


                        int randomIndex = Random.Range(0, myObjects.Length);
                        GameObject instantiatedObject = Instantiate(myObjects[randomIndex], new Vector3(previousPos.x, previousPos.y), Quaternion.identity) as GameObject;

                        if (numOfBeads < maxBeads)
                        {
                            if (Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, keyTask.transform.position)) >= 3)
                            {
                                GameObject instantiatedBead = Instantiate(Bead, new Vector3(previousPos.x - yOffset, previousPos.y + xOffset), Bead.transform.rotation) as GameObject;
                                if (Mathf.Abs(Vector3.Distance(Bead.transform.position, instantiatedBead.transform.position)) < 12)
                                {

                                    Destroy(instantiatedBead);
                                }
                                else
                                {
                                    Bead = instantiatedBead;
                                    numOfBeads++;

                                }
                            }


                        }
                        try
                        {
                            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Statue").Length; i++)
                            {
                                if (Mathf.Abs(Vector3.Distance(GameObject.FindGameObjectsWithTag("Statue")[i].transform.position, instantiatedObject.transform.position)) <= 5)
                                {
                                    Destroy(instantiatedObject);
                                }
                            }
                       } catch (System.Exception e) {
                            Debug.LogException(e, this);
                        }  


                        if (numOfEnemies < maxEnemies)
                        {
                            if (Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, enemy.transform.position)) >= 5)
                            {
                                GameObject instantiatedEnemy = Instantiate(enemy, new Vector3(previousPos.x, previousPos.y), Quaternion.identity) as GameObject;
                                if (Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, instantiatedEnemy.transform.position)) < 40)
                                {
                                    Destroy(instantiatedEnemy);
                                }
                                else
                                {
                                    numOfEnemies++;
                                    instantiatedEnemy.name = "Enemy(" + numOfEnemies.ToString() + ")";
                                }
                            }


                        }

                    
                    
                    
                        


                        routeUsed = true;
                    }
                }
                //Go right
                if (Random.Range(1, 100) <= deviationRate)
                {
                    if (routeUsed)
                    {
                        GenerateSquare(previousPos.x + yOffset, previousPos.y - xOffset, roomSize);


                        NewRoute(previousPos.x + yOffset, previousPos.y - xOffset, Random.Range(routeLength, maxRouteLength), previousPos);



                        int randomIndex = Random.Range(0, myObjects.Length);
                        GameObject instantiatedObject = Instantiate(myObjects[randomIndex], new Vector3(previousPos.x, previousPos.y), Quaternion.identity) as GameObject;

                        

                        try {
                            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Statue").Length; i++)
                            {
                                if (Mathf.Abs(Vector3.Distance(GameObject.FindGameObjectsWithTag("Statue")[i].transform.position, instantiatedObject.transform.position)) <= 5)
                                {
                                    Destroy(instantiatedObject);
                                }
                            }
                       } catch (System.Exception e) {
                            Debug.LogException(e, this);
                        }  

                    }
                    else
                    {
                        y = previousPos.y - xOffset;
                        x = previousPos.x + yOffset;
                        GenerateSquare(x, y, roomSize);

                        

                        if (task1Items < maxTask1Items)
                        {
                            if (Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, keyTask.transform.position)) >= 5)
                            {
                                GameObject instantiatedKey = Instantiate(keyTask, new Vector3(previousPos.x, previousPos.y), keyTask.transform.rotation) as GameObject;
                                if (Mathf.Abs(Vector3.Distance(keyTask.transform.position, instantiatedKey.transform.position)) < 30)
                                {

                                    Destroy(instantiatedKey);
                                }
                                else
                                {
                                    keyTask = instantiatedKey;
                                    task1Items++;

                                }
                            }


                        }

                        if (task2Items < maxTask2Items)
                        {
                            if (Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, cursedStatueTask.transform.position)) >= 5)
                            {
                                GameObject instantiatedCursedStatue = Instantiate(cursedStatueTask, new Vector3(previousPos.x, previousPos.y), Quaternion.identity) as GameObject;
                                if (Mathf.Abs(Vector3.Distance(cursedStatueTask.transform.position, instantiatedCursedStatue.transform.position)) < 30)
                                {

                                    Destroy(instantiatedCursedStatue);
                                }
                                else
                                {
                                    cursedStatueTask = instantiatedCursedStatue;
                                    task2Items++;

                                }
                            }


                        }


                        if (task3Items < maxTask3Items)
                        {
                            if (Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, pressurePlateTask[0].transform.position)) >= 5 &&
                                Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, pressurePlateTask[1].transform.position)) >= 5)
                            {
                                GameObject instantiatedBox = Instantiate(pressurePlateTask[0], new Vector3(previousPos.x, previousPos.y), Quaternion.identity) as GameObject;
                                GameObject instantiatedPressurePlate = Instantiate(pressurePlateTask[1], new Vector3(previousPos.x +yOffset, previousPos.y - xOffset), Quaternion.identity) as GameObject;
                                if (Mathf.Abs(Vector3.Distance(pressurePlateTask[0].transform.position, instantiatedBox.transform.position)) < 20 && Mathf.Abs(Vector3.Distance(pressurePlateTask[1].transform.position, instantiatedBox.transform.position)) < 20)
                                {

                                    Destroy(instantiatedBox);
                                    Destroy(instantiatedPressurePlate);
                                }
                                else
                                {
                                    pressurePlateTask[0] = instantiatedBox;
                                    pressurePlateTask[1] = instantiatedPressurePlate;
                                    task3Items++;

                                }
                            }


                        }

                        int randomIndex = Random.Range(0, myObjects.Length);
                        GameObject instantiatedObject = Instantiate(myObjects[randomIndex], new Vector3(previousPos.x, previousPos.y), Quaternion.identity) as GameObject;

                        if (numOfBeads < maxBeads)
                        {
                            if (Mathf.Abs(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, keyTask.transform.position)) >= 3)
                            {
                                GameObject instantiatedBead = Instantiate(Bead, new Vector3(previousPos.x + yOffset, previousPos.y - xOffset), Bead.transform.rotation) as GameObject;
                                if (Mathf.Abs(Vector3.Distance(Bead.transform.position, instantiatedBead.transform.position)) < 12)
                                {

                                    Destroy(instantiatedBead);
                                }
                                else
                                {
                                    Bead = instantiatedBead;
                                    numOfBeads++;

                                }
                            }


                        }

                        try {
                            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Statue").Length; i++)
                            {
                                if (Mathf.Abs(Vector3.Distance(GameObject.FindGameObjectsWithTag("Statue")[i].transform.position, instantiatedObject.transform.position)) <= 5)
                                {
                                    Destroy(instantiatedObject);
                                }
                            }
                       } catch (System.Exception e) {
                            Debug.LogException(e, this);
                        }  


                        routeUsed = true;
                    }
                }
                if (!routeUsed)
                {
                    x = previousPos.x + xOffset;
                    y = previousPos.y + yOffset;
                    GenerateSquare(x, y, roomSize);

                }
                
            }
            
        }

    }

    

    private void GenerateSquare(int x, int y, int radius)
    {
        

        for (int tileX = x - radius; tileX <= x + radius; tileX++)
        {
            for (int tileY = y - radius; tileY <= y + radius; tileY++)
            {
                Vector3Int tilePos = new Vector3Int(tileX, tileY, 0);
                int num = Random.Range(1, 100);
                if (num < 5) groundMap.SetTile(tilePos, secondGroundTile);
                else groundMap.SetTile(tilePos, groundTile);
            }
        }
    }

    public Tilemap getPitMap() {
        return this.pitMap;
    }

    public Tilemap getWallMap() {
        return this.wallMap;
    }

    public Tilemap getGroundMap() {
        return this.groundMap;
    }

    public Tile getPitTile() {
        return this.pitTile;
    }

    public Tile getGroundTile() {
        return this.groundTile;
    }

    public Tile getSecondGroundTile() {
        return this.secondGroundTile;
    }

    public Tile getTopWallTile() {
        return this.topWallTile;
    }

    public Tile getBotWallTile() {
        return this.botWallTile;
    }

    public int getMaxEnemies() {
        return this.maxEnemies;
    }
}