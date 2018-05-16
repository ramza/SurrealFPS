using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleController : MonoBehaviour {

    public float fireRate = 0.25f;
    public float hitForce = 10f;
    ParticleSystem shootParticles;

    private AudioSource _audio;
    private float timer;

	// Use this for initialization
	void Start () {
        shootParticles = GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if ( timer > fireRate && Input.GetButtonDown("Fire1"))
        {
            _audio.Play();
            shootParticles.Play();

            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if ( Physics.Raycast(ray, out hit))
            {
                if ( hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        if (hit.collider.gameObject.GetComponent<Rigidbody>())
                        {
                            hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(ray.direction * hitForce);
                        }
                    }
                }
            }
        }
	}
}
