using UnityEngine;
using System.Collections;
using CompleteProject;

public class CenterHelper : MonoBehaviour
{
    public WeaponHelper MyWeapon;
    GameHelper _gameHelper;
    // Use this for initialization
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position,
            transform.forward, out hit) &&
            hit.collider.GetComponent<HealthHelper>())
        {
            if (!_gameHelper.IsStartedGame)
                _gameHelper.StartGame();

            //print("Found an object - name: " + hit.collider.name);
            MyWeapon.Shoot();
            Debug.DrawLine(transform.position, transform.position +
            hit.point, Color.red);
        }
        else
            Debug.DrawLine(transform.position, transform.position +
            transform.forward * 10, Color.blue);
    }

}
