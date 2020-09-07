using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject inimigosPrefab;

    [SerializeField]
    private GameObject[] powerUps;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnInimigosRoutine());
        StartCoroutine(spawnPowerUpsRoutine());
    }

    //Criar corotinas para criar inimigos de 5 em 5 segudos
    IEnumerator spawnInimigosRoutine()
    {
        while (true)
        {
            Instantiate(inimigosPrefab, new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator spawnPowerUpsRoutine()
    {
        while (true)
        {
            int randowPowerUps = Random.Range(0, 3);
            Instantiate(powerUps[randowPowerUps], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }


    void Update()
    {
        
    }
}
