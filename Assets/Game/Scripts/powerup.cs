using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;
    
    [SerializeField]
    private int powerID;

    [SerializeField] private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);

        if (other.tag.Equals("Player"))
        {
            player player = other.GetComponent<player>();

            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);

            if (player != null)
            {
                if (powerID == 0)
                {
                    //player.cantripleShot = true;
                    player.IniciarTiroTriplo();
                }
                else if (powerID == 1)
                {
                    player.IniciarSpeedbostActive();
                }
                else if (powerID == 2)
                {
                    player.AbilitarShields();
                }
            }

            //StartCoroutine(player.PararTiroTriplo());

            Destroy(this.gameObject);

        }
    }
}
