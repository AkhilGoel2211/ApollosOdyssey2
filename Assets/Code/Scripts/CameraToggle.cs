using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UI;

public class CameraToggle : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimCamera;
    [SerializeField] private float ZoomAimSensitivity;
    [SerializeField] private float NormalAimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] Transform debugTransform;
    [SerializeField] private Transform bulletObject;
    [SerializeField] private Transform bulletSpawnPoint;
    private Animator animator;

    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;
    private PlayerHealth playerHealth;
    private PlayerInventory playerInventory;
    [SerializeField] private Text mainMessages;

    private AudioSource playerAudioSource;
    [SerializeField] private AudioClip blasterSoundEffect;
    [SerializeField] private AudioClip emptyGunClick;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        playerHealth = GetComponent<PlayerHealth>();
        playerInventory = GetComponent<PlayerInventory>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused) 
        {
            //Debug.Log("Update is being called");
            Vector2 screenmid = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenmid);
            Vector3 mouse3DPosition = Vector3.zero;
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
            { 
                debugTransform.position = raycastHit.point;
                mouse3DPosition = raycastHit.point;
            }
        
            if (starterAssetsInputs.aim)
            {
                aimCamera.gameObject.SetActive(true);
                thirdPersonController.updateSensitivity(ZoomAimSensitivity);
                //Current Mouse Position
                Vector3 aimTarget = mouse3DPosition;
                aimTarget.y = transform.position.y;
                //Calculating Rotation --> (target - player pos) --> unit vector
                Vector3 aimDirection = (aimTarget - transform.position).normalized;
                //Rotating the rigid body of the player
                transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
                thirdPersonController.setRotateOnMove(false);
                animator.SetLayerWeight(1, 1f);
                //if (starterAssetsInputs.is_moving)
                //{
                //    animator.SetLayerWeight(1, 0.5f);
                //    starterAssetsInputs.is_moving = false;
                //}
                //else
                //{
                //    animator.SetLayerWeight(1, 1f);
                //}
                
            }
            else
            {
                aimCamera.gameObject.SetActive(false);
                thirdPersonController.updateSensitivity(NormalAimSensitivity);
                thirdPersonController.setRotateOnMove(true);
                animator.SetLayerWeight(1, 0f);
            }

            if (starterAssetsInputs.shoot && starterAssetsInputs.aim)
            {
                if(playerInventory.currentAmo > 0)
                {
                    Vector3 aimDir = (mouse3DPosition - bulletSpawnPoint.position).normalized;
                    Instantiate(bulletObject, bulletSpawnPoint.position, Quaternion.LookRotation(aimDir, Vector3.up));
                    playerAudioSource.PlayOneShot(blasterSoundEffect);
                    playerInventory.DecrementAmmo();
                }else{
                    playerAudioSource.PlayOneShot(emptyGunClick);
                }
                starterAssetsInputs.shoot = false;
            }

            if (starterAssetsInputs.medpack)
            {
                DisplayMainMessage("Consumed Med Kit");
                if (playerInventory.healthPacksCollected > 0)
                {
                    DisplayMainMessage("Consumed Med Kit");
                    playerHealth.currentHealth += 50;
                    if (playerHealth.currentHealth > 100)
                    {
                        playerHealth.currentHealth = 100;
                    }
                    playerInventory.DecrementHealthPacksCollected();   
                }
                starterAssetsInputs.medpack = false;
            }
        }
    }

    public void DisplayMainMessage(string message)
    {
        mainMessages.text = message;
    }
}
