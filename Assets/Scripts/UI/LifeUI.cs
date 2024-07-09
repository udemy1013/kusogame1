using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeUI : MonoBehaviour
{
    public Player player;
    public GameObject[] hearts;
    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
           if (i < GameManager.instance.playerData.currentLife)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}
