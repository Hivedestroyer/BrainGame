using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformerRails;

public class collisions : MonoBehaviour
{
    public MoverOnRails collide;
    private Rigidbody collisionBody;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("TEST1");
        obj = collision.gameObject;

        StartCoroutine("Debounce");
        
    }

    IEnumerator Debounce()
    {
        Debug.Log("TESTHIT");
        collide = obj.GetComponent<MoverOnRails>();
        collisionBody = collide.rigidbody;

        collide.Velocity.y = 10f;
        collide.Velocity.x = 4f;
        yield return new WaitForSeconds(1);
    }
}
