using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Player player;    
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {       
        totalHealthBar.fillAmount = player.currentHealth / 10;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = player.currentHealth / 10;
    }
}
