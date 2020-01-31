using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantFeet : MonoBehaviour
{
    float EaseSpeed = 5f;
    Quaternion beforeRotation;
    public PlayerMove playermove;
    private RaycastHit hit;
    public Transform raycastPoint;
    public GameObject Gcamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        beforeRotation = transform.rotation;
    }


    // Update is called once per frame
    void Update()
    {        
        Physics.Raycast(raycastPoint.position, Vector3.down, out hit);
        transform.up -= (transform.up - hit.normal) * 0.1f;

    }
}
