using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakp : MonoBehaviour
{
    public bool takip;
    public Transform hedef;
    public Vector3 duzeltme;

    [Range(0, 10)]
    public float positionyumusakl�g�;
    [Range(0, 10)]
    public float rotationyumusakl�g�;

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

            transform.position = Vector3.Lerp(transform.position, t_pos, Time.deltaTime * positionyumusakl�g�);
            transform.rotation = Quaternion.Lerp(k_rot, transform.rotation, Time.deltaTime * rotationyumusakl�g�);

            if (transform.position.y < 0.5f)
            {
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

            }

        }
    }
}