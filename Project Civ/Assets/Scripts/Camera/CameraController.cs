using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Camera Movement Script. Movement irrespective of fps(Time.deltaTime). Z position left untouched since game is in 2D*/
public class CameraController : MonoBehaviour
{
    //Camera scroll speed
    public float speed = 5f;

    void Update()
    {
        float xAxisVal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yAxisVal = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.position = new Vector3(
            transform.position.x + xAxisVal,
            transform.position.y + yAxisVal,
            transform.position.z
        );
    }
}
