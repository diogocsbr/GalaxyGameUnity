using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject inimigosPrefab;

    [SerializeField]
    private GameObject[] powerUps;

    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //StartCoroutine(spawnInimigosRoutine());
        //StartCoroutine(spawnPowerUpsRoutine());
    }

    public void IniciarSpawns()
    {
        StartCoroutine(spawnInimigosRoutine());
        StartCoroutine(spawnPowerUpsRoutine());
    }

    //Criar corotinas para criar inimigos de 5 em 5 segudos
    IEnumerator spawnInimigosRoutine()
    {
        while (!_gameManager.gameOver)
        {
            Instantiate(inimigosPrefab, new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator spawnPowerUpsRoutine()
    {
        while (!_gameManager.gameOver)
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
