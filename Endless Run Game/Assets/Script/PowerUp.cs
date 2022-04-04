using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (AudioManger.ismute == false)
        {
            FindObjectOfType<AudioManger>().PlaySound("Pick coins");
        }
        StartCoroutine(PlayerControl.PowerUp());
        Destroy(gameObject);
    }
}
