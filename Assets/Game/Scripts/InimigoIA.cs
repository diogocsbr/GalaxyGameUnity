using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoIA : MonoBehaviour
{
    [SerializeField]
    private GameObject _inimigoExplosaoPrefab;

    public float speed = 5f;

    private UIManager _uiManager;

    private GameManager _gameManager;


    //tocar um clip pois, o audio da explosão não sai pois, o objeto esta sendo destruido
    [SerializeField]private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        //_clip = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if ( transform.position.y < -7)
        {
            float randomX = Random.Range(-7, 7);
            transform.position = new Vector3(randomX, 7, 0);
        }

        if (_gameManager.gameOver)
        {
            Debug.Log("destruiu pois ainda estava ativo");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.tag == "Laser")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }

            //_audioSource.Play();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);

            Instantiate(_inimigoExplosaoPrefab, transform.position, Quaternion.identity);
            
            _uiManager.AtualizarScore();
            
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if (other.tag == "Player")
        {
            player player = other.GetComponent<player>();
            if (player != null)
            {
                player.TomarDano();
            }

            //_audioSource.Play();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);

            Instantiate(_inimigoExplosaoPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
