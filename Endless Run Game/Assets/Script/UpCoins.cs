using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpCoins : MonoBehaviour {

    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!(other.tag == "UPcoins"))
        {
            if (AudioManger.ismute == false)
            {
                FindObjectOfType<AudioManger>().PlaySound("Pick coins");
            }
            PlayerManager.NumberOfCoins += 5;
            Destroy(gameObject);
        }
    }
}
