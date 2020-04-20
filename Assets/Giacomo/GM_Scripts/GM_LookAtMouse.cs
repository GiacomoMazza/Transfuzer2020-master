using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_LookAtMouse : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The main camera in the scene. It focuses on the player.")]
    private Camera cam_MainCamera;

    // Update is called once per frame
    void LateUpdate()
    {
        //Get the direction vector between the mouse's position and the camera position on screen (pixels).
        Vector3 v3_Direction = Input.mousePosition - cam_MainCamera.WorldToScreenPoint(transform.position);

        //Compute the angle given by the x and y coordinates of the direction vector in degrees.
        float fl_Angle = Mathf.Atan2(v3_Direction.y, v3_Direction.x) * Mathf.Rad2Deg;

        //Rotate our pivot with an angle axis rotation around the z axis.
        transform.rotation = Quaternion.AngleAxis(fl_Angle, Vector3.forward);
    }
}
