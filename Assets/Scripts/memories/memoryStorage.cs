using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class memoryStorage : MonoBehaviour
{
    public int[] collected;
    public int total = 0; //counter for how many collected. used to set array index and for triggering ending
    // Start is called before the first frame update
    void Start()
    {
        collected = new int[6];
    }

    // Update is called once per frame
    void Update()
    {
        if (this.total == 6)
        {
            selectEnding();
        }


    }

    void selectEnding()
    {
        var correctOrder = new int[] {1, 2, 3, 4, 5, 1};
        Debug.Log(correctOrder[0]);
        Debug.Log(collected[0]);
        if (CheckArrays(correctOrder, collected))
        {
            SceneManager.LoadScene("goodEnding");
        }
        else
        {
            SceneManager.LoadScene("badEnding");
        }
    }

    bool CheckArrays( int[] array1, int[] array2)
    {
        for (int i = 0; i < array1.Length; i++)
            if (array1[i] != array2[i]) return false;
        return true;
    }
}
