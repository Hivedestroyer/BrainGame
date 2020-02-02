using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharFlipper : MonoBehaviour
{
    public PlayerMove pmove;
    Animator Canimator;
    public Vector3 v;
    public Vector3 a;
    public string current_rotation = "";
    // Start is called before the first frame update
    void Start()
    {
        
        Canimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (current_rotation != "v")
            {
                this.gameObject.transform.Rotate(a);
                current_rotation = "v";

            }

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (current_rotation != "a")
            {
                this.gameObject.transform.Rotate(a);
                current_rotation = "a";
            }
                
        }

    }
}
