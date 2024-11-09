using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    bool isAttacking;
    bool isDefending;
    
    private void Update() {
        isAttacking = Input.GetMouseButtonDown(0);
        if(isAttacking) Debug.Log("Attack!");
        isDefending = Input.GetMouseButtonDown(1);
        if(isDefending) Debug.Log("Defend!");
    }
}
