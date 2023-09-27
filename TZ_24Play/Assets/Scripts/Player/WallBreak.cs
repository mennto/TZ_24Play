using UnityEngine;

public class WallBreak : MonoBehaviour
{
    private StartMove _move;
    private void Awake()
    {
        _move = GetComponent<StartMove>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Triggered triger = collision.gameObject.GetComponent<Triggered>();
            if (!triger.triggered)
            {
                Handheld.Vibrate();
                checkChildCollision(collision);
                triger.triggered = true;
            }
        }
    }

    public void checkChildCollision(Collision collision)
    {
        foreach (Transform child in transform)
        {
            Collider childCollider = child.GetComponent<Collider>();

            if (childCollider != null)
            {
                if (childCollider.bounds.Intersects(collision.collider.bounds))
                {
                    removeChild(child);
                }
            }
        }
    }

    public void removeChild(Transform child)
    {
        child.transform.SetParent(null);

        if (transform.childCount <= 2)
        {
            Death();
        }

        Destroy(child.gameObject, 2f);
    }
    public void Death()
    {
        _move.speed = 0;
        _move.canvasEnd.SetActive(true);
        Rigidbody rigid = _move.GetComponent<Rigidbody>();
        Destroy(rigid);
        _move.transform.DetachChildren();
    }
}
