using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonStart : MonoBehaviour
{
    public GameObject cube;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void toggleCube()
    {
        if(cube.activeSelf == true)
        {
            cube.SetActive(false);
        }
        else
        {
            cube.SetActive(true);
        }
        Debug.Log("トグル！！！！！！！！！！");
    }

    public void StartGameFunc()
    {
        
        
        toggleCube();        
    }
}
