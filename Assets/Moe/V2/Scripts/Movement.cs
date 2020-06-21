using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("GENERAL")]

    [Tooltip("This gameobject's animator with MainCharacter as Controller.")]
    [SerializeField]
    private Animator animator;

    [Tooltip("This gameobject's Sprite Renderer Component.")]
    [SerializeField]
    private SpriteRenderer sr_Renderer;

    [Header("DASH")]

    [Tooltip("Is the dash ability available for this character?")]
    [SerializeField]
    private bool bl_DashAbility = false;

    /// <summary>
    /// Is the character currently dashing?
    /// </summary>
    private bool bl_IsDash = false;

    [Tooltip("The seconds of invulnerability given by the dash.")]
    [SerializeField]
    [Range(0.5f, 2f)]
    private float fl_InvSec = 1f;

    [Tooltip("The dash's speed.")]
    [Range(1f, 3f)]
    [SerializeField]
    private float fl_DashSpeed = 2f;

    [Tooltip("The dash's cooldown.")]
    [Range(1f, 5f)]
    [SerializeField]
    private float fl_CooldownDash = 3f;

    private bool bl_IsDashCool = true;

    [Tooltip("The key on the keyboard to press to dash.")]
    [SerializeField]
    private KeyCode DashKey = KeyCode.Space;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(DashKey))
        {
            if (bl_IsDashCool)
            {
                if (!bl_IsDash)
                {
                    StartCoroutine("Invulnerable");
                    //TODO: GET ANOTHER COROUTINE TO INSTANTIATE THE DIFFERENT DASH SPRITES /TIME
                } 
            }
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        if (bl_DashAbility == true)
        {
            if (!bl_IsDash || !bl_IsDashCool)
            {
                transform.position = transform.position + movement * Time.deltaTime;
            }

            else if (bl_IsDash)
            {
                transform.position = transform.position + movement * fl_DashSpeed * Time.deltaTime;
            }
        }

        else if (bl_DashAbility == false) transform.position = transform.position + movement * Time.deltaTime;

        if (movement.x < 0)
        {
            sr_Renderer.flipX = true;
        }
        else if (movement.x > 0)
        {
            sr_Renderer.flipX = false;
        } 
    }

    private IEnumerator Invulnerable()
    {
        bl_IsDash = true;
        animator.SetBool("bl_Dash", true);
        yield return new WaitForSeconds(0.75f);
        //TODO: MAKE HEALTH STATIC
        yield return new WaitForSeconds(fl_InvSec);
        //TODO: UNDO INVULNERABILITY
        animator.SetBool("bl_Dash", false);
        bl_IsDash = false;
        bl_IsDashCool = false;
        StartCoroutine("DashCooldown");
        yield return null;
    }

    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(fl_CooldownDash);
        bl_IsDashCool = true;
        yield return null;
    }
}
