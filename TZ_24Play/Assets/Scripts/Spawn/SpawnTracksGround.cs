using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTracksGround : MonoBehaviour
{
    public GameObject trackGround;
    private LinkedList<GameObject> myTracksGround = new LinkedList<GameObject>();
    public int size = 10;
    private float sizeofTrackGround = 30;
    public float directionZ = 0;
    [HideInInspector] public bool deletePreviousBlock = false;

    public void SpawnTrackGround()
    {
        myTracksGround.AddLast(Instantiate(trackGround, new Vector3(0, 0, directionZ), Quaternion.identity));
        directionZ += sizeofTrackGround;

        if (deletePreviousBlock)
        {
            GameObject toDelete = myTracksGround.First.Value;
            myTracksGround.RemoveFirst();
            Destroy(toDelete);
        }
    }

    private void Awake()
    {
        for (int i = 0; i < size; i++)
            SpawnTrackGround();
    }
}
