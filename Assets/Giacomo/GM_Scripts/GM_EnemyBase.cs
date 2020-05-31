using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_EnemyBase : MonoBehaviour
{
    [SerializeField]
    private GameObject go_Player;

    [SerializeField]
    private EnemyType enemy_type;

    private Logic enemy_stance;

    [Tooltip("Toggle this to true ONLY if picowind is the only way this object can be triggered.")]
    [SerializeField]
    private bool bl_IsWindTheOnlyTrigger = false;

    [Tooltip("Check if this is a ranged enemy. Uncheck if it is melee.")]
    [SerializeField]
    private bool bl_Ranged = false;

    //ENEMY STATS
    private float fl_ActivationRange = 0f;

    void Start()
    {
        enemy_stance = Logic.Inactive;
    }

    [SerializeField]
    public enum EnemyType
    {
        Big_TV,
        Small_Bin,
        Big_Bin
    };

    private enum Logic
    {
        Inactive,
        Sleeping,
        Attack,
        Retreat
    };

    void Update()
    {
        switch (enemy_type)
        {
            case EnemyType.Big_Bin:
                fl_ActivationRange = 10f;
                break;

            case EnemyType.Small_Bin:
                fl_ActivationRange = 5f;
                break;

            case EnemyType.Big_TV:
                fl_ActivationRange = 15f;
                break;

            default:
                Debug.Log("This is a bug");
                break;
        }
    }

    private void LateUpdate()
    {
        //Calculate distance over time and activate object when the distance is equal or less than the range given.
        if(Vector3.Distance(gameObject.transform.position, go_Player.transform.position) <= fl_ActivationRange)
        {
            if (!bl_IsWindTheOnlyTrigger)
            {
                RangedActivation(); 
            }
        }
    }

    /// <summary>
    /// Run this function to activate the enemy with PicoWind, provide time.
    /// </summary>
    public void PicoWind(float fl_TimeBeforeActivation)
    {
        StartCoroutine("PicoAnimation", fl_TimeBeforeActivation);
    }

    /// <summary>
    /// Pico-Animation based on the distance between the player and the enemy.
    /// </summary>
    private void RangedActivation()
    {
        if (bl_Ranged)
        {
            enemy_stance = Logic.Sleeping;
        }

        else if (!bl_Ranged)
        {
            enemy_stance = Logic.Attack;
        }
    }

    private IEnumerator PicoAnimation(float fl_Time)
    {
        yield return new WaitForSeconds(fl_Time);
        RangedActivation();
        yield return null;
    }
}
