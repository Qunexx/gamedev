using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float offset;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private FixedJoystick _ViewJStk;
    public GameObject bullet;
    public Transform shotpoint;

    


    //поворот модельки
    public bool FaceRight = true;

    // Update is called once per frame
    void Update()
    {

        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        float rotz ; //= (Mathf.Atan2(_ViewJStk.Vertical, _ViewJStk.Horizontal) * Mathf.Rad2Deg);
        if (_ViewJStk.Vertical == 0 && _ViewJStk.Horizontal == 0)
        {
            rotz = (Mathf.Atan2(0, 0) * Mathf.Rad2Deg);
        }
        else
        {
            rotz = (Mathf.Atan2(_ViewJStk.Vertical, _ViewJStk.Horizontal) * Mathf.Rad2Deg)+180;
        }

        /*if (rotz > 90 && rotz < 270)                 // «адатки поворота модельки
        {
            FaceRight = true;

            Quaternion rot = transform.rotation;              //ѕосле отпускани€ джойстика надо поставить флаг направо или налево, т.к. таким образом мы будем отслеживать последнее направление персонажа и следовательно rotz будет либо 0, либо 180
            rot.y = 0;
            transform.rotation = rot;
        }

        if (rotz < 90 && rotz > 270)
        {
            FaceRight = false;

            Quaternion rot = transform.rotation;
            rot.y = 180;
            transform.rotation = rot;
        }
        */
        transform.rotation = Quaternion.Euler(0, 0, rotz);


        if (_ViewJStk.Vertical != 0 && _ViewJStk.Horizontal != 0)
        {
            Instantiate(bullet, shotpoint.position, Quaternion.Euler(0, 0, rotz+90));
        }


        
        
    }
}
