using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerPrefText : MonoBehaviour
{

    public string namecik;


    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt(namecik) + "";
    }
}
