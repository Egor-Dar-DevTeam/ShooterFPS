using NaughtyCharacter.Script;
using UnityEngine;

public class SkeletMove : MonoBehaviour
{
    [SerializeField] private GameObject skelet;
    [SerializeField] private AudioSource audioSource;
    private string skeletmove = "skeletmove";
    private Animator skeletAimator;
    private AudioClip audioClip;

    private void Reset()
    { 
        skeletAimator ??= GetComponent<Animator>();
    }

    private void Start()
    {
        audioClip = audioSource.clip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Character>(out var player))
        {
            skelet.SetActive(true);
            audioSource.PlayOneShot(audioClip);
            skeletAimator.Play(skeletmove);
            Invoke("Active",2);
        }
    }
    private void Active()
    {
        skelet.SetActive(false);
    }
}
