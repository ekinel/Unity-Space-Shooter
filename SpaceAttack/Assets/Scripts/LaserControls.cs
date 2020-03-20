using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControls : MonoBehaviour
{
    private int laserControl = 6;

    void Update()
    {
        transform.Translate(Vector3.up * laserControl * Time.deltaTime);

        if(transform.position.y >= 4.07)
            Destroy(this.gameObject, 1);
    }
}
