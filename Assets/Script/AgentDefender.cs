using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class AgentDefender : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    private AudioSource _audioSource;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (target)
        {
            agent.destination = target.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}






