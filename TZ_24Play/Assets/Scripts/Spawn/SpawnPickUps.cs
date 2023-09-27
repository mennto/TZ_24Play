using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickUps : MonoBehaviour
{
    public GameObject pickUp;
    public int size = 10;
    private int range = 15;
    private float sizeofPickUps = 5;
    public float directionZ = 0;
    [HideInInspector] public bool deletePreviousBlock = false;
    private LinkedList<GameObject> myPickUps = new LinkedList<GameObject>();


    public void SpawnPickUp()
    {
        for (int i = 0; i < 3; i++)
        {
            myPickUps.AddLast(Instantiate(pickUp, new Vector3(Random.Range(-1.5f, 1.5f), 0.5f, directionZ), Quaternion.identity));
            directionZ += sizeofPickUps;

            if (deletePreviousBlock)
            {
                GameObject toDelete = myPickUps.First.Value;
                myPickUps.RemoveFirst();
                Destroy(toDelete);
            }
        }
        directionZ += range;
    }

    private void Awake()
    {
        for(int i = 0; i < size; i++)
        {
            SpawnPickUp();
        }
    }
}
