using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    public GameObject[] walls;
    public int size = 10;
    private float range = 30;
    public float directionZ = 0;
    [HideInInspector] public bool deletePreviousBlock = false;
    private LinkedList<GameObject> myWalls = new LinkedList<GameObject>();

    public void SpawnWall()
    {
        myWalls.AddLast(Instantiate(walls[Random.Range(0, walls.Length)], new Vector3(0, 0, directionZ), Quaternion.identity));
        directionZ += range;

        if (deletePreviousBlock)
        {
            GameObject toDelete = myWalls.First.Value;
            myWalls.RemoveFirst();
            Destroy(toDelete);
        }
    }

    private void Awake()
    {
        for (int i = 0; i < size; i++)
            SpawnWall();
    }
}
