using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoIA : MonoBehaviour
{
    [SerializeField]
    private GameObject _inimigoExplosaoPrefab;

    public float speed = 5f;

    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.tag == "Laser")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
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
            Instantiate(_inimigoExplosaoPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
