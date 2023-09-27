using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackPickUps : MonoBehaviour
{
    public ParticleSystem particlePickUp;
    public GameObject pickUp;
    private float shiftY = 1f;
    Animator _anim;

    private void Awake()
    {
        GameObject player = transform.parent.gameObject;
        Transform stickMan = player.transform.Find("Stickman");
        _anim = stickMan.GetComponent<Animator>();
    }
    public void Stack(GameObject player)
    {
        float newY = player.transform.position.y + shiftY;
        player.transform.position = new Vector3(player.transform.position.x,newY, player.transform.position.z);

        GameObject newStack = Instantiate(pickUp, new Vector3(player.transform.position.x,0.5f, player.transform.position.z), Quaternion.identity);
        newStack.gameObject.transform.SetParent(player.transform);

        particlePickUp.Play();
        _anim.SetTrigger("Jump");
       
         Triggered triger = newStack.GetComponent<Triggered>();
        triger.triggered = true;
    }

}
