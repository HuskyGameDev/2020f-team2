using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    //[SerializeField] Camera mainCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponentInParent<PlayerHealth>().health = 0;
        //mainCamera.transform.position = new Vector3(-90, 103, -1);
    }
}
