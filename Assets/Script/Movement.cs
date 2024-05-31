using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust= 350;
    [SerializeField] float rotation = 100;
    [SerializeField] AudioClip Engine;

    [SerializeField] ParticleSystem SideThrusterParticlesLeft;
    [SerializeField] ParticleSystem SideThrusterParticlesRight;
    [SerializeField] ParticleSystem RocketJetParticles;


    Rigidbody rigi;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        ProccesThrust();
        ProccesInput();
    }
    void ProccesThrust()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            

            rigi.AddRelativeForce(Vector3.up*mainThrust*Time.deltaTime);
            //the different is that when the body rotat the add force just go up with out give the rotat attenion
           // rigi.AddForce(Vector3.up);

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(Engine);
                RocketJetParticles.Play();

            }
            
        }
        else
        {
            audioSource.Stop();
            RocketJetParticles.Stop();
        }
    }

    void ProccesInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (!SideThrusterParticlesRight.isPlaying)
            {
                SideThrusterParticlesRight.Play();
            }
            
            //rotating to the left
            RotatingMethod(rotation);
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!SideThrusterParticlesLeft.isPlaying)
            {
                SideThrusterParticlesLeft.Play();
            }
            
            //rotating to the right
            RotatingMethod(-rotation);
        }
        else
        {
            SideThrusterParticlesLeft.Stop();
            SideThrusterParticlesRight.Stop();
        }
        
    }

    private void RotatingMethod(float RotationDir)
    {
        //we should freez the rigibody rotat becouse it is against our rotat 
        rigi.freezeRotation = true;  //here we are freezing the rotation of the rigi
        transform.Rotate(Vector3.forward * RotationDir * Time.deltaTime);
        rigi.freezeRotation = false;  //here we are unfreezing the rotation of the rigi
    }
}
