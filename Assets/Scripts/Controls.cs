using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] private float sensitivity = 15f;

    void Update()
    {
        float axis = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        transform.Translate(axis, 0, 0);
    }
}
