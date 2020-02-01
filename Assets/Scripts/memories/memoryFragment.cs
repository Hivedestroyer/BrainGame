using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memoryFragment : MonoBehaviour
{

    public int id;
    public memoryStorage storage;
    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //add id to array and destroy object
        storage.collected[storage.total++] = this.id;
        
        Destroy(this.gameObject);
    }
}
