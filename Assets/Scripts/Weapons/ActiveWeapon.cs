using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public static ActiveWeapon Instance { get; private set; }


    [SerializeField] private Sword sword;


    private void Awake() {
        Instance = this;
    }

    private void Update() {
        if (Player.Instance.IsAlive())
            FollowMousePosition();
    }
    public Sword GetActiveWeapon() {
        return sword;
    }

    private void FollowMousePosition() {
        Vector3 mousePos = GameInput.Instance.GetMousePositions();
        Vector3 playerPOS = Player.Instance.GetPlayerScreenPosition();

        if (mousePos.x < playerPOS.x) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
