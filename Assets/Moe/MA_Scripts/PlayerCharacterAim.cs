using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterAim : MonoBehaviour
{
    [SerializeField]
    private Transform aimTransform;

    [SerializeField]
    private Camera mainCam;

    [SerializeField]
    private Transform firingOrigin; //where bullet is shot from

    [SerializeField]
    private GameObject projectileToFire;

    //private void Awake()
    //{
    //    //aimTransform = transform.Find("Aim");
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    //mainCam = Camera.main;
    //}

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePos = Input.mousePosition;

        //Vector3 aimPoint = Camera.main.WorldToScreenPoint(aimTransform.localPosition); //get pos of aim obj in world

        //Vector2 offset = new Vector2(mousePos.x - aimPoint.x, mousePos.y - aimPoint.y); //position of player in relation to mouse

        //float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg; //conv from rads to degrees

        //aimTransform.rotation = Quaternion.Euler(0f, 0f, angle);

        if(Input.GetMouseButtonDown(0)) //left click
        {
            Instantiate(projectileToFire, firingOrigin.position, aimTransform.rotation);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Get the direction vector between the mouse's position and the camera position on screen (pixels).
        Vector3 v3_Direction = Input.mousePosition - mainCam.WorldToScreenPoint(transform.position);

        //Compute the angle given by the x and y coordinates of the direction vector in degrees.
        float fl_Angle = Mathf.Atan2(v3_Direction.y, v3_Direction.x) * Mathf.Rad2Deg;

        //Rotate our pivot with an angle axis rotation around the z axis.
        aimTransform.rotation = Quaternion.AngleAxis(fl_Angle, Vector3.forward);
    }
}
