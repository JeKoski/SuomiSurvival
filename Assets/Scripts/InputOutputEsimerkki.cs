using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOutputEsimerkki : MonoBehaviour
{
    [SerializeField] private int minimi;
    [SerializeField] private int maksimi;
    private int enemySpeed;

    private void Update()
    {
        enemySpeed = RandomNumero(minimi, maksimi);
    }


    int RandomNumero(int randomMin, int randomMax)
    {
        int randomNumero;
        
        randomNumero = Random.Range(randomMin, randomMax);

        return randomNumero;
    }
}
