using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(0,50 * Time.deltaTime, 0);
	}
    private void OnTriggerEnter(Collider other)
    {
        if (!(other.tag == "Obstacle"))
        {
            if (AudioManger.ismute == false)
            {
                FindObjectOfType<AudioManger>().PlaySound("Pick coins");
            }
            PlayerManager.NumberOfCoins += 1;
            Destroy(gameObject);
        }
    }
}
