using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//great name!
public class Collectable : MonoBehaviour
{
    //Coin Value
    public int value = 5;
    //Coin rotation
    public Vector2 rotation;
    //Rotation speed
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //Coin rotation speed
        transform.Rotate(rotation * speed * Time.deltaTime);
    }

}
