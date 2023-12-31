using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform trans;
    //public bool test = false;
    public float coolDown = 0.5f;
    private float shootTimer;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        shootTimer = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float aroundZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, aroundZ);

        if (Input.GetMouseButton(0) && (Time.time > shootTimer))
        {
            Instantiate(bullet, trans.position, Quaternion.identity);
            shootTimer = Time.time + 0.3f;
        }
    }

}
