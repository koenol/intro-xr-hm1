using UnityEngine;

public class Rotate : MonoBehaviour
{
    void Update()
    {

        if (transform.parent != null)
        {
            float speed = 10f;

            transform.RotateAround(transform.parent.position, Vector3.up, speed * Time.deltaTime);
        }
    }
}