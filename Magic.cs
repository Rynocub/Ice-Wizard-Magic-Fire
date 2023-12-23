using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Magic : MonoBehaviour
{
Vector3 mousePos;
private Camera mainCam;
private Rigidbody2D rb;
public float force;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotaion = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotaion.y, rotaion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
