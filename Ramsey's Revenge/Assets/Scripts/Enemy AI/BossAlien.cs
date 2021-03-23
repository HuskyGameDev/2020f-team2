using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlien : MonoBehaviour
{
    public Transform mothership;
    public int speed;

    private bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        movingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, mothership.position) < 10f)
        {
            if(movingRight == true)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
    }
}
