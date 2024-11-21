using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class textmain : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button Fix;
    [SerializeField] private Button Correct;
    [SerializeField] private Button peel;
    [SerializeField] private Button encr;
    [SerializeField] private Button decr;
    [SerializeField] private TMP_Text texta;
    private bool encrypted = false;


    private void Fixin(){
        texta.text = texta.text.Replace("*","u");
    }
    private void Correcting() {
        texta.text = texta.text.Replace(">","\n");
    }
    private void peeling(){
        texta.text = texta.text.Replace("$",string.Empty);
        texta.text = texta.text.Remove(1570);
    }
    private void encrypt(){
        if (!encrypted){
            string ttext = texta.text;
            char[] arr = ttext.ToCharArray();
            Array.Reverse(arr);
            for (int i=0; i<arr.Length; i++){
                char lettera = arr[i];
                switch (lettera) {
                    case '.': 
                        arr[i] = ',';
                        break;
                    case ',':
                        arr[i] = '.';
                        break;
                    case ';':
                        arr[i] = ':';
                        break;
                    case ':':
                        arr[i] = ';';
                        break;
                    case '?':
                        arr[i] = '!';
                        break;
                    case '!':
                        arr[i] = '?';
                        break;
                    case 'a':
                        arr[i] = 'u';
                        break;
                    case 'u':
                        arr[i] = 'y';
                        break;
                    case 'y':
                        arr[i] = 'a';
                        break;
                }
            }
            texta.text = new string(arr);
            encrypted = true;
        }
    }
    private void decrypt(){ //extra
        if (encrypted){
            string ttext = texta.text;
            char[] arr = ttext.ToCharArray();
            for (int i=0; i<arr.Length; i++){
                char lettera = arr[i];
                switch (lettera) {
                    case ',': 
                        arr[i] = '.';
                        break;
                    case '.':
                        arr[i] = ',';
                        break;
                    case ':':
                        arr[i] = ';';
                        break;
                    case ';':
                        arr[i] = ':';
                        break;
                    case '!':
                        arr[i] = '?';
                        break;
                    case '?':
                        arr[i] = '!';
                        break;
                    case 'a':
                        arr[i] = 'y';
                        break;
                    case 'u':
                        arr[i] = 'a';
                        break;
                    case 'y':
                        arr[i] = 'u';
                        break;
                }
            }
            Array.Reverse(arr);
            texta.text = new string(arr);
            encrypted = false;
        }
    }
    void Start()
    {
        Fix.onClick.AddListener(Fixin);
        Correct.onClick.AddListener(Correcting);
        peel.onClick.AddListener(peeling);
        encr.onClick.AddListener(encrypt);
        decr.onClick.AddListener(decrypt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
