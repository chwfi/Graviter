using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperWind : MonoBehaviour, IAudioPlay
{
    [SerializeField]
    private float rayDistance;

    [SerializeField]
    private LayerMask _layerMask;

    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _clip;

    public void AudioPlay(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Stop();
        _audioSource.Play();
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position + Vector3.up, Vector2.up, rayDistance, _layerMask);

        if (hits != null)
        {
            foreach (RaycastHit2D hit in hits)
            {
                Vector2 jumpVec = Vector2.up * rayDistance;
                
                hit.rigidbody.AddForce(jumpVec);
                Debug.Log(hit.collider.gameObject.name);
                AudioPlay(_clip);
            }
        }
        else
        {
            _audioSource?.Stop();
        }

    }
}
