using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedCombat : MonoBehaviour
{
    private Transform aimTransform;

    private Camera mainCam;

    public Transform firingOrigin; //where bullet is shot from
    public GameObject projectileToFire;

    private void Awake()
    {
        aimTransform = transform.Find("MainCharacterHand");
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 aimPoint = Camera.main.WorldToScreenPoint(aimTransform.localPosition); //get pos of aim obj in world

        Vector2 offset = new Vector2(mousePos.x - aimPoint.x, mousePos.y - aimPoint.y); //position of player in relation to mouse

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg; //conv from rads to degrees

        aimTransform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetMouseButtonDown(0)) //left click
        {
            Instantiate(projectileToFire, firingOrigin.position, transform.GetChild(0).rotation);
        }


    }
}
