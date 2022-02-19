using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to make an object shoot periodically
public class SpikeCannon : MonoBehaviour
{
    public GameObject projectile;       //projectile to use
    public float speed;                 //projectile horizontal speed
    public float firingDelay;           //time between shots
    private bool readyToFire = true;    //bool to delay shots
    Rigidbody2D rb;                     //track projectile rigidbody

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //check if ready to fire
        if (readyToFire)
        {
            //instantiate a projectile
            GameObject proj = Instantiate(projectile, transform.position, projectile.transform.rotation);
            //talk to the projectile riigidbody and give it velocity
            rb = proj.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.right * speed;
            //apply a cooldown by changing the ready bool
            StartCoroutine(Cooldown());
            readyToFire = false;
        }
    }

    //coroutine to reset readyToFire after the firing delay
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(firingDelay);
        readyToFire = true;
    }

}
