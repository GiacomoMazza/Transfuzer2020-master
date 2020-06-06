using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Tooltip("This gameobject's animator with MainCharacter as Controller.")]
    [SerializeField]
    private Animator animator;

    [Header("DASH")]

    [Tooltip("Is the dash available for this character?")]
    [SerializeField]
    private bool bl_IsDash = true;

    [Tooltip("The seconds of invulnerability given by the dash.")]
    [SerializeField]
    private float fl_InvSec = 1f;

    [Tooltip("The dahs's speed.")]
    [SerializeField]
    private float fl_DashSpeed = 2f;

    [Tooltip("The key on the keyboard to press to dash.")]
    [SerializeField]
    private KeyCode DashKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //TODO: CHANGE THIS TO BE TRUE ONLY WHEN WE AREN'T DASHING

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime;

        //TODO: SET FLOAT AS ABOVE AND MAKE NEW BLEND TREE FOR ROLLING. MULTIPLY POSITION TIMES FL_DASHSPEED.

        if (movement.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movement.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKeyDown(DashKey))
        {
            if (bl_IsDash)
            {
                StartCoroutine("Invulnerable");             
            }
        }
    }

    private IEnumerator Invulnerable()
    {
        bl_IsDash = false;
        //TODO: CHANGE STATE TO ROLLING IN ANIMATOR
        //TODO: MAKE HEALTH STATIC
        yield return new WaitForSeconds(fl_InvSec);
        //TODO: UNDO INVULNERABILITY
        //TODO: CHANGE STATE TO RUNNING IN ANIMATOR
        bl_IsDash = true;
        yield return null;
    }
}
