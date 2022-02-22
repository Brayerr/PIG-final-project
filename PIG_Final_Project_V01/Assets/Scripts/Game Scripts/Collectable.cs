using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //Coin Variables.
    public int value = 5;
    public Vector2 rotation;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //Coin rotation speed.
        transform.Rotate(rotation * speed * Time.deltaTime);
    }

}
