using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerShooting : MonoBehaviour
    {
        public int damagePerShot = 20;                  // sat thuong
        public float timeBetweenBullets = 0.15f;        // thoi gian 1 lan ban
        public float range = 100f;                      // tầm bắn


        float timer;                                    // A timer to determine when to fire.
        Ray shootRay;                                   // 1 tia raycast
        RaycastHit shootHit;                            // nhan thong tin ve doi tuong ban trúng
        int shootableMask;                              // 
        ParticleSystem gunParticles;                    // hieu ung ban
        LineRenderer gunLine;                           // ve duong dan cua dan
        AudioSource gunAudio;                           // am thanh ban
        Light gunLight;                                 // 
        public Light faceLight;								// Duh
        float effectsDisplayTime = 0.2f;                //


        void Awake()
        {
            // 
            shootableMask = LayerMask.GetMask("Shootable");

            // Set up the references.
            gunParticles = GetComponent<ParticleSystem>();
            gunLine = GetComponent<LineRenderer>();
            gunAudio = GetComponent<AudioSource>();
            gunLight = GetComponent<Light>();
            //faceLight = GetComponentInChildren<Light> ();
        }


        void Update()
        {
            // thoi gian sau moi khung hinh
            timer += Time.deltaTime;

#if !MOBILE_INPUT
            // If the Fire1 button is being press and it's time to fire...
            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                // ... shoot the gun.
                //  Shoot ();
            }
#else
            // neu co su di chuyen chuot
            if ((CrossPlatformInputManager.GetAxisRaw("Mouse X") != 0 || CrossPlatformInputManager.GetAxisRaw("Mouse Y") != 0) && timer >= timeBetweenBullets)
            {
                // ... shoot the gun
                Shoot();
            }
#endif
            // turn off efect
            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                // ... disable the effects.
                DisableEffects();
            }
        }


        public void DisableEffects()
        {
            // Disable the line renderer and the light.
            gunLine.enabled = false;
            faceLight.enabled = false;
            gunLight.enabled = false;
        }


        public void Shoot()
        {
            // check thoi gian giua cac lan ban va game co bị pause
            if (timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                // Reset the timer.
                timer = 0f;

                // turn on sound effect
                gunAudio.Play();

                // anh sang sung
                gunLight.enabled = true;
                faceLight.enabled = true;

                // Hieu ung sung
                gunParticles.Stop();
                gunParticles.Play();

                // ve duong dan
                gunLine.enabled = true;
                gunLine.SetPosition(0, transform.position);

                // thiet lap diem bat dau va ket thuc cua tia raycast
                shootRay.origin = transform.position;
                shootRay.direction = transform.forward; // huong ve phia trc cua sung

                // xu ly va cham voi zombie
                if (Physics.Raycast(shootRay, out shootHit, range)) //, shootableMask
                {
                    // lay ra doi tuong ma tia raycast cham phai
                    HealthHelper enemyHealth = 
                        shootHit.collider.GetComponent<HealthHelper>();

                    // ktra phai la zombie thi tru hp
                    if (enemyHealth != null)
                    {
                        //zombie do nhan hp
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }

                    // thiet lap vi tri ket thuc cua raycast 
                    gunLine.SetPosition(1, shootHit.point);
                }
                // Neu raycast khong cham vao zombie
                else
                {
                    // do dai tia raycast 
                    gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
                }
            }
        }
    }
}