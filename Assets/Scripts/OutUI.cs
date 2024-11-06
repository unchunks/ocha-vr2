using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutUI : MonoBehaviour
{
    public GameObject UiObj;

    public void onOut()
    {

        UiObj.SetActive(false);
    }
}
