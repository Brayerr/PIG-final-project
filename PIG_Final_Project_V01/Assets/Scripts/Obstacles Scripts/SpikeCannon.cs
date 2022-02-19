using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCannon : MonoBehaviour
{
    public GameObject projectile;
    public float speed;
    public float firingDelay;
    private bool readyToFire = true;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (readyToFire)
        {

            GameObject go = Instantiate(projectile, transform.position,projectile.transform.rotation);
            rb = go.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.right * speed;
            StartCoroutine(Cooldown());
            readyToFire = false;
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(firingDelay);
        readyToFire = true;
    }

}
