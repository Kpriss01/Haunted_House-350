using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class CameraFlash : MonoBehaviour
{
    [SerializeField] private float PhotosLeft;
    [SerializeField] private float MaxPhotos = 6;
    [SerializeField] private GameObject flashup;
    [SerializeField] private GameObject flashright;
    [SerializeField] private GameObject flashdown;

    public Healthbar flashes;

    public float flashtime = 1f;
    private float timepass = 0;
    private bool nomovement = true;

    [SerializeField] private AudioClip cameraFlashSound; // Assign "camera_flash" sound clip in the Inspector
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        flashup.gameObject.SetActive(false);
        flashdown.gameObject.SetActive(false);
        flashright.gameObject.SetActive(false);
        flashes.SetMaxHealth(MaxPhotos);
        PhotosLeft = MaxPhotos;

        // Initialize the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing on CameraFlash object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Camera flash attack at "F"
        if (Input.GetKeyDown(KeyCode.F) && (PhotosLeft > 0))
        {
            PhotosLeft -= 1;
            flashes.SetHealth(PhotosLeft);
            timepass = flashtime;

            // Play the camera flash sound
            if (audioSource != null && cameraFlashSound != null)
            {
                audioSource.PlayOneShot(cameraFlashSound);
            }
        }

        if (timepass >= 0)
        {
            Flipping();
        }
        else
        {
            flashup.SetActive(false);
            flashright.SetActive(false);
            flashdown.SetActive(false);
            nomovement = true;
        }
    }

    void Flipping()
    {
        timepass -= Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            flashup.SetActive(true);
            flashright.SetActive(false);
            flashdown.SetActive(false);
            nomovement = false;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            flashup.SetActive(false);
            flashright.SetActive(false);
            flashdown.SetActive(true);
            nomovement = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            flashup.SetActive(false);
            flashright.SetActive(true);
            flashdown.SetActive(false);
            nomovement = false;
        }
        else if (nomovement)
        {
            flashright.SetActive(true);
        }
    }
}

