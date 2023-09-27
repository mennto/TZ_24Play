using UnityEngine;
using System.Collections.Generic;

public class ActivateTriger : MonoBehaviour
{
    private SpawnPickUps _spawnPickUps;
    private SpawnTracksGround _spawnTracksGround;
    private SpawnWalls _spawnWalls;
    private StackPickUps _stackPickUps;

    private void Awake()
    {
        _spawnPickUps = GetComponent<SpawnPickUps>();
        _spawnTracksGround = GetComponent<SpawnTracksGround>();
        _spawnWalls = GetComponent<SpawnWalls>();
        _stackPickUps = transform.Find("CubeObject").GetComponent<StackPickUps>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TrigerZone"))
        {
            _spawnPickUps.SpawnPickUp();
            _spawnPickUps.deletePreviousBlock = true;
            _spawnTracksGround.SpawnTrackGround();
            _spawnTracksGround.deletePreviousBlock = true;
            _spawnWalls.SpawnWall();
            _spawnWalls.deletePreviousBlock = true;
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ToPickUp"))
        {
            Triggered triger = collision.gameObject.GetComponent<Triggered>();
            if (!triger.triggered)
            {
                Destroy(collision.gameObject);
                _stackPickUps.Stack(gameObject);
            }
        }
    }
}
