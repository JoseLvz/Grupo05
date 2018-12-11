using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspa_Trigger : MonoBehaviour {

    private void OnTriggerEnter(Collider c)
    {
        gameObject.GetComponentInParent<Fan>().pullTrigger(c);
    }
}
