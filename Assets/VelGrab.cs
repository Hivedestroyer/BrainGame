using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformerRails;

public class VelGrab : MonoBehaviour
{
    public MoverOnRails playerMove;
    public MoverOnRails ballMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerMove.Velocity += ballMove.Velocity;
            Debug.Log(playerMove.Velocity);
        }
    }

}
