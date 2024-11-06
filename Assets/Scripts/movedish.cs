using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedish : MonoBehaviour
{
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            transform.position += new Vector3(0, 0, 0.003f);
        }
    }

    public void toggleMove()
    {
        isMoving = !isMoving;
    }
}
