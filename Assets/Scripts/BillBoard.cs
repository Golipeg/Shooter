using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position+_camera.forward);
    }
}
