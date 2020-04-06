using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterAim : MonoBehaviour
{

    private Transform aimTransform;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Vector3 mouseDirection = (mousePos - transform.position).normalized;

        float aimAngle = Mathf.Atan2(mouseDirection.x, mouseDirection.y) * Mathf.Rad2Deg;

        aimTransform.eulerAngles = new Vector3(0, 0, aimAngle);

        Debug.Log(aimAngle);
    }
}
