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
    private bool bl_IsDash = false;

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
        if (Input.GetKeyDown(DashKey))
        {
            if (!bl_IsDash)
            {
                StartCoroutine("Invulnerable");
            }
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        if (!bl_IsDash)
        {
            transform.position = transform.position + movement * Time.deltaTime;
        }

        else if (bl_IsDash)
        {
            transform.position = transform.position + movement * fl_DashSpeed * Time.deltaTime;
        }

        //TODO: SET FLOAT AS ABOVE AND MAKE NEW BLEND TREE FOR ROLLING. MULTIPLY POSITION TIMES FL_DASHSPEED.

        if (movement.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movement.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        } 
    }

    private IEnumerator Invulnerable()
    {
        bl_IsDash = true;
        //TODO: CHANGE STATE TO ROLLING IN ANIMATOR
        //TODO: MAKE HEALTH STATIC
        yield return new WaitForSeconds(fl_InvSec);
        //TODO: UNDO INVULNERABILITY
        //TODO: CHANGE STATE TO RUNNING IN ANIMATOR
        bl_IsDash = false;
        yield return null;
    }
}
