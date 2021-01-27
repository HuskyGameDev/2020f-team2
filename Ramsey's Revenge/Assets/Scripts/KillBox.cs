using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    //[SerializeField] Camera mainCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = new Vector3(-155, 31, 0);
        //mainCamera.transform.position = new Vector3(-90, 103, -1);
    }
}
