using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animes : MonoBehaviour {

    private Vector3 direction;
    private CharacterController controller;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = 5;
    }
    private void FixedUpdate()
    {
        if (PlayerManager.IsGameStart)
        {
            controller.Move(-direction * Time.fixedDeltaTime);
        }
    }
}
