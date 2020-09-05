using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoIA : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(this.gameObject);
        }
    }
}
