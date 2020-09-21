using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public bool cantripleShot = false;
    public bool isSpeedBoostActive = false;
    public bool shieldActive = false;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    [SerializeField]
    private int _lives = 3;

    [SerializeField]
    private  GameObject _laserPrefab;
    [SerializeField] 
    private  GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _explosaoPrefab;

    [SerializeField]
    private GameObject _shields;

    private UIManager _uiManager;
    private GameManager _gameManager;
    private Spawn _spawn;

    private AudioSource _audioSource;

    [SerializeField]
    private GameObject[] _motores;

    private int _tomoudHit = 0;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager != null)
        {
            _uiManager.AtualizarVidas(_lives);
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _spawn = GameObject.Find("ControllerSpawn").GetComponent<Spawn>();

        if (_spawn != null)
        {
            _spawn.IniciarSpawns();
        }

        _audioSource = GetComponent<AudioSource>();

        _tomoudHit = 0;
    }

    private void Atirar()
    {
        if (Time.time > _canFire)
        {
            _audioSource.Play();

            if (cantripleShot)
            {
                //Instantiate(_laserPrefab, transform.position + new Vector3(-0.55f, 0.06f, 0), Quaternion.identity);
                //Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                //Instantiate(_laserPrefab, transform.position + new Vector3(0.55f, 0.06f, 0), Quaternion.identity);

                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);

            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            }
            _canFire = Time.time + _fireRate;
        }
    }

    void Update()
    {
        Movimento();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Atirar();
        }
    }

    private void Movimento() {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (isSpeedBoostActive)
        {
            transform.Translate(Vector3.right * _speed * 1.5f * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * 1.5f * verticalInput * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
        }

        //meio tela e naão sai por baixo
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }


        //if (transform.position.x > 8)
        //{
        //    transform.position = new Vector3(8, transform.position.y, 0);
        //}
        //else if (transform.position.x < -8)
        //{
        //    transform.position = new Vector3(-8, transform.position.y, 0);
        //}


        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }


    public void IniciarTiroTriplo() {
        cantripleShot = true;
        StartCoroutine(PararTiroTriplo());
    }
    public IEnumerator PararTiroTriplo() {

        yield return new WaitForSeconds(5.0f);
        cantripleShot = false;
    }

    public void IniciarSpeedbostActive()
    {
        isSpeedBoostActive = true;
        StartCoroutine(PararSpeedBoost());
    }
    public IEnumerator PararSpeedBoost()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }

    public void AbilitarShields() {
        shieldActive = true;
        _shields.SetActive(true);
    }

    public void TomarDano()
    {
        if ( shieldActive)
        {
            shieldActive = false;
            _shields.SetActive(false);
            return;
        }

        _tomoudHit++;

        if (_tomoudHit == 1)
        {
            _motores[0].SetActive(true);
        }
        else if (_tomoudHit == 2)
        {
            _motores[1].SetActive(true);
        }

        _lives--;
        _uiManager.AtualizarVidas(_lives);

        if ( _lives == 0)
        {
            Instantiate(_explosaoPrefab, transform.position, Quaternion.identity);
            
            _gameManager.gameOver = true;
            _uiManager.MostrarTelaInicial();

            Destroy(this.gameObject);
        }
    }
}
