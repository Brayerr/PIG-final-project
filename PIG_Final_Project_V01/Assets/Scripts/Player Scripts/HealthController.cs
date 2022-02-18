using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    //Variables for the UI.
    [SerializeField] private Player player;    
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;    

    private void Start()
    {       
        //Setting fill amount of the image according to the player Health at start of game.
        totalHealthBar.fillAmount = player.currentHealth / 10;
    }

    private void Update()
    {
        //Increase and decrease the fill amount of the image according to the player Health.
        currentHealthBar.fillAmount = player.currentHealth / 10;
    }
}
