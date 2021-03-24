//Chris Riordan
//6-14-2020
using UnityEngine;
//Controls generic gun behaviour
public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 3;
    public float impactForce = 30f;
    public float magSize = 30f;
    public float ammoAmount = 30f;
    public float reloadSpeed = 2f;
    public int weaponLevel = 1;
    public int upgradePrice = 2500;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject gun;
    public MoneyCounter money;
    public PackCol colis;

    private float nextTimeToFire = 0f;
    private float reloadTime = 0f;

    public bool isKnife = false;
    public bool isPistol = false;
    private bool isReloading = false;
    private bool isPacking = false;

    public Animator animator;
    //Responds to user inputs
    void Update()
    {
        //Determines and applies stats to currently equipped gun if player has enough money and triggers the upgrade
        isPacking = colis.getPack();
      if (gun.activeInHierarchy && money.money>=upgradePrice*weaponLevel && Input.GetKeyDown(KeyCode.E)&&isPacking)
            {
            if (!isKnife && !isPistol) {
                money.addMoney(-upgradePrice * weaponLevel);
                weaponLevel++;
                damage += 10;
                magSize += 5;
            }
            else if (!isKnife && isPistol)
            {
                money.addMoney(-upgradePrice * weaponLevel);
                weaponLevel++;
                fireRate +=100;
                reloadSpeed++;
            }
            }
      //Controls firing cycle for the guns
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && ammoAmount >= 0 && isReloading == false)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        //Controls reload cycle and animation for the guns
        if (isKnife == false)
        {
            if (Input.GetButtonDown("Reload") && ammoAmount < magSize)
            {
                animator.SetBool("Reloading", true);
                reloadTime = Time.time + reloadSpeed;
                ammoAmount = magSize;
                isReloading = true;
            }
            if (isReloading == true && Time.time >= reloadTime)
            {
                isReloading = false;
                animator.SetBool("Reloading", false);
            }
        }

    }
    //Handles muzzle flash when gun is shot then calculates point at which the gun is fired
    //Applies damage to an enemy if the enemy is hit
    void Shoot()
    {
        if(isKnife == false&&!muzzleFlash.isPlaying)
        {
            ammoAmount--;
            muzzleFlash.Play();
        }

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }

            if (hit.rigidbody)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
