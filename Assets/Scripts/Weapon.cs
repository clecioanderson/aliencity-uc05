using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform bulletPoint;
    public GameObject bulletPrefab;



    private void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) { //Vai disparar quando pressionar o botão esquerdo
            Shoot(); //Cham a a função
        }
    }



    private void Shoot() {
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
    }

}
