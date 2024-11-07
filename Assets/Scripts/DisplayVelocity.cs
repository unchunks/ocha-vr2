using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisplayVelocity : MonoBehaviour
{
    public GameObject shakeObserveObj;
    public TextMeshProUGUI text_mesh;
    private ShakeMove shakeMove;
    // private float coefficient = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        shakeMove = shakeObserveObj.GetComponent<ShakeMove>();
    }

    // Update is called once per frame
    void Update()
    {

        text_mesh.text = ( shakeMove.GetLeftHandVelocity()) .ToString() ;

    }
}
