using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for a button that triggers a "door" barricade
public class SwitchDoor : MonoBehaviour
{
    public GameObject door;     //track door object
    public Transform button;    //track button

    void Start()
    {
        //assign door and button objects
        door = gameObject.transform.GetChild(0).gameObject;
        button = this.gameObject.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //remove the barricade object
        door.SetActive(false);
        //change button shape to look pressed
        button.localScale = (new Vector3(1, 0.1f, 1));
        button.position = new Vector3(button.position.x,button.position.y - 0.1f,button.position.z);
    }
}
