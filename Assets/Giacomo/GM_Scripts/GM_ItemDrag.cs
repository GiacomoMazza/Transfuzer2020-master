using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class GM_ItemDrag : MonoBehaviour
{
    [Tooltip("The Graphics Raycaster Component in the Canvas.")]
    [SerializeField]
    private GraphicRaycaster gr_Raycaster;

    private PointerEventData ped_Data;

    //Alternates between them. Maybe have an Invoke to achieve the same effect with 1 click.
    private bool bl_ItemPicked = false;

    [Tooltip("The EventSystem in the hierarchy.")]
    [SerializeField]
    private EventSystem es_System;

    //result of the graphics raycast
    private GameObject go_Result;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Change bool once the mouse has been clicked
            bl_ItemPicked = !bl_ItemPicked;

            //Initialise Data
            ped_Data = new PointerEventData(es_System);

            //Give position for the raycast
            ped_Data.position = Input.mousePosition;

            //List for all the objects hit
            List<RaycastResult> results = new List<RaycastResult>();

            //FIRE!
            gr_Raycaster.Raycast(ped_Data, results);

            foreach(RaycastResult result in results)
            {
                //If the object hit is the item, and if there are no objects being carried atm, pick the item up
                if (bl_ItemPicked)
                {
                    if (result.gameObject.layer == LayerMask.NameToLayer("Item"))
                    {
                        if (go_Result == null)
                        {
                            go_Result = result.gameObject; 
                        }
                    }
                }

                //If it hits the slot, snap into position and nullify.
                if (!bl_ItemPicked)
                {
		            if (result.gameObject.layer == LayerMask.NameToLayer("Slot"))
                    {
                        go_Result.transform.position = result.gameObject.transform.position;
                        go_Result = null;
                    } 
                }
            }
        }      
    }

    private void LateUpdate()
    {        
        //Follow the mouse, you item!
        if (go_Result != null)
        {
            if (go_Result.GetComponent<Image>().isActiveAndEnabled)
            {
                go_Result.transform.position = Input.mousePosition;
            } 
        }       
    }
}
