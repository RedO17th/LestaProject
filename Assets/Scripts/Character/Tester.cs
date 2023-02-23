using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Character charact;

    // Start is called before the first frame update
    void Start()
    {
        charact = new Character();
        Debug.Log(charact);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log(charact);
        }
    }
}
