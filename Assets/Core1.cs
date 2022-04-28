using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Spaceship>().AddCore1();
            Destroy(gameObject);
        }
    }
}
