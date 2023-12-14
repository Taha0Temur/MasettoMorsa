using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakp : MonoBehaviour
{
    public bool takip;
    public Transform hedef;
    public Vector3 duzeltme;

    [Range(0, 10)]
    public float positionyumusaklýgý;
    [Range(0, 10)]
    public float rotationyumusaklýgý;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (takip)
        {
            this.rb.velocity.Normalize();
            transform.LookAt(hedef);

            Quaternion k_rot = transform.rotation;
            Vector3 t_pos = hedef.position + hedef.TransformDirection(duzeltme);

            if (t_pos.y < hedef.position.y)
            {
                t_pos.y = hedef.position.y;
            }

            transform.position = Vector3.Lerp(transform.position, t_pos, Time.deltaTime * positionyumusaklýgý);
            transform.rotation = Quaternion.Lerp(k_rot, transform.rotation, Time.deltaTime * rotationyumusaklýgý);

            if (transform.position.y < 0.5f)
            {
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

            }

        }
    }
}