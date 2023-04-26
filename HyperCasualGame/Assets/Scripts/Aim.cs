using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private bl_Joystick Joystick;

    private void Start()
    {
        Joystick = GameObject.Find("Joystick").GetComponent<bl_Joystick>();
    }

    private void Update()
    {
        float v = Joystick.Vertical;
        float h = Joystick.Horizontal;

        Vector3 translate = (new Vector3(h, v) * Time.deltaTime) * 5;
        transform.Translate(translate);
    }
}
