using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int butnid;
    [SerializeField] public int stars;
    [SerializeField] public bool locked;
    [SerializeField] private GameObject lockicon;
    [SerializeField] private TMP_Text taxt;
    [SerializeField] GameObject[] starsarr; 
    void Start()
    {
        taxt.text = $"{butnid}";
        if (!locked){
            if (stars > 0){
                for (int i=0;i<Math.Clamp(stars,0,starsarr.Length);i++){
                    if (starsarr[i] != null){
                      starsarr[i].SetActive(true);
                    }
                }
            }
        } else lockicon.SetActive(true);
    }

    // Update is called once per frame
}
