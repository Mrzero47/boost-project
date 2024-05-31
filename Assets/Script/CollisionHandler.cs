using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip sucsses;
    [SerializeField] AudioClip crashed;

    [SerializeField] ParticleSystem sucssesParticle;
    [SerializeField] ParticleSystem crashedParticle;
    ParticleSystem ParticleSystem;
    AudioSource audioSucss;

    bool istransinon;
    private void Start()
    {
        audioSucss = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (istransinon) { return; }
        switch (other.gameObject.tag)
        {
            case "Finish":
                SuccesMethod();
                
                break;

            case "Launcher":
                break;

            default:
                Crash();
                
                break;

        }
    }

    private void SuccesMethod()
    {
        istransinon = true;
        sucssesParticle.Play();
        audioSucss.Stop();
        audioSucss.PlayOneShot(sucsses);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 2f);
        
    }

    void Crash()
    {
        istransinon = true;
        crashedParticle.Play();
        audioSucss.Stop();
        audioSucss.PlayOneShot(crashed);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", 2f);
        
    }
    void LoadNextLevel()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextSceneIndex = CurrentSceneIndex + 1;
        if (NextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextSceneIndex = 0;
        }
        SceneManager.LoadScene(NextSceneIndex);
    }

    void ReloadScene()
    {
        //it is can work by the index of the Scene or by the name 
        //SceneManager.LoadScene(0);

        //here it is take the index of the Scene that your are in (Auto)
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
}
