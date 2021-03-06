using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image totalLivesBar;
    [SerializeField] private Image currentLivesBar;

    // Start is called before the first frame update
    void Start()
    {
        //Setting the fill amount of the image according to the player Lives.
        totalLivesBar.fillAmount = player.currentLives / 10;
    }

    // Update is called once per frame
    void Update()
    {
        //Increase and decrease the fill amount of the image according to the player Lives.
        currentLivesBar.fillAmount = player.currentLives / 10;
    }
}
