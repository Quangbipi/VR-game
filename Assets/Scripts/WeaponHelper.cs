using UnityEngine;
using System.Collections;
using CompleteProject;

public class WeaponHelper : MonoBehaviour {

   public PlayerShooting playerShooting;

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    internal void Shoot()
    {
        playerShooting.Shoot();
    }
}
