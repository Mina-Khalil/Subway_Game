using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Name : MonoBehaviour {
    public static string NamePlayer;
    public  GameObject inputFailed;
    public void Name_Player()
    {
        NamePlayer = inputFailed.GetComponent<Text>().text;
    }
 
}
