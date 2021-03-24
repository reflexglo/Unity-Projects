//Chris Riordan
//6-14-2020
using UnityEngine;
//Controls the weapons list and the weapon cycling
public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    //Sets the equipped weapon to the first weapon in the list on start
    void Start()
    {
        selectWeapon();
    }

    //Responds to mouse scrollwheel input to switch weapons
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }
        
            selectWeapon();
        
    }
    //Equips the weapon selected through the mouse scroll wheel
    public Transform selectWeapon()
    {
        int i = 0;
        Transform currentWeapon = null;
        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                currentWeapon = weapon;
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
        return currentWeapon;
    }
}
