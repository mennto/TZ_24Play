using UnityEngine;
using System.Collections.Generic;


public class StartMove : MonoBehaviour
{
    public GameObject canvasStart;
    public GameObject canvasEnd;
    public GameObject trail;
    public float speed = 5f;
    private float movementDirectionX = 1f;
    private float movementDirectionZ = 1f;
    private bool firstTouch = false;

    private void Awake()
    {
        canvasEnd.SetActive(false);
        canvasStart.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            firstTouch = true;
            canvasStart.SetActive(false);
        }

        if (firstTouch)
        {
            transform.Translate(new Vector3(0, 0, movementDirectionZ) * Time.fixedDeltaTime * speed);
        }
        Vector3 pos = new Vector3(transform.position.x, 0.1f, transform.position.z);
        trail.transform.position = pos;
    }
    private void OnCollisionStay(UnityEngine.Collision collision)
    {
        float playerPos = Camera.main.WorldToScreenPoint(gameObject.transform.position).x;
        if (collision.gameObject.CompareTag("Ground") && Input.touchCount > 0)
        {
            if (Input.mousePosition.x > playerPos)
            {
                movementDirectionX = 1;
            }
            else if (Input.mousePosition.x < playerPos)
            {
                movementDirectionX = -1;
            }
            else
            {
                movementDirectionX = 0;
            }
            transform.Translate(new Vector3(movementDirectionX, 0, 0) * Time.fixedDeltaTime * speed);
        }

    }
}
