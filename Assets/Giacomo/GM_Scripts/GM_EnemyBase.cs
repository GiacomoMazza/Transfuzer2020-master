using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_EnemyBase : MonoBehaviour
{
    [SerializeField]
    private EnemyType enemy_type;

    void Start()
    {
        
    }

    [SerializeField]
    public enum EnemyType
    {
        Big_TV,
        Small_Bin,
        Big_Bin,
    };

    void Update()
    {
        switch (enemy_type)
        {
            case EnemyType.Big_Bin:
                Debug.Log("This is a big bin");
                break;

            case EnemyType.Small_Bin:
                Debug.Log("This is a small bin");
                break;

            case EnemyType.Big_TV:
                Debug.Log("This is a big tv");
                break;

            default:
                Debug.Log("This is a bug");
                break;
        }
    }
}
