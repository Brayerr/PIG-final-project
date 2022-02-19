using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    public GameObject door;
    public Transform button;


    // Start is called before the first frame update
    void Start()
    {
        door = gameObject.transform.GetChild(0).gameObject;
        button = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("bruv");
        door.SetActive(false);
        button.localScale = (new Vector3(1, 0.1f, 1));
        button.position = new Vector3(button.position.x,button.position.y - 0.1f,button.position.z);
    }
}
