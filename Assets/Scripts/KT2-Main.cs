using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KT2_Main : MonoBehaviour
{
    [Header("Setup stuff")]
    [Tooltip("Setup main button")]
    [SerializeField] private Button main_button;
    [SerializeField] private Image main_sprite;
    [Tooltip("Setup output text-text")]
    [SerializeField] private TMP_Text textout;
    [Tooltip("Setup upgrade button")]
    [SerializeField] private Button upgrade_button;
    [Header("Starting Attributes:")]
    [SerializeField] private float timertime = 2;
    [SerializeField] private double points = 0;
    [SerializeField] private double power = 1;
    private double cost = 5;
    private bool active = false;
    private int num = 0;
    private float ticks = 0;
    
   
    void upgrade(){
        if (points>=cost){
            points-=cost;
            cost*=3;
            power*=timertime>=1?1.5:4;
            power-=power%1; // to prevent numbers smaller than 1
            timertime = Math.Clamp(timertime-0.5f,0.1f,timertime);
        }
    }
    void main(){
        if (!active){
            num+=1;
            active = true;
            ticks = 0;
        }

    }
    void Start(){
        upgrade_button.onClick.AddListener(upgrade);
        main_button.onClick.AddListener(main);
    }
    void Update()
    {
        textout.text = $"Clicked: {num}\n (extra) \nPoints: {points}\nCost: {cost}\nPWR: {power}";

        if (active){
            ticks+=Time.deltaTime;
            if (ticks>=timertime){
                active = false;
                points += power;
                main_sprite.fillAmount = 1;
            } else {
                main_sprite.fillAmount = ticks/timertime;
            }
        }
    }
}
