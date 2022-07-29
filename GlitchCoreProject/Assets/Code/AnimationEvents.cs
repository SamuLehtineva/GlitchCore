using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class AnimationEvents : MonoBehaviour
    {
        public GameObject bullet;
        public float shootSpeed;
        public Transform rightArm, leftArm;
        Transform target;
        Rigidbody rbLeft, rbRight;
        GameObject currentRightBullet, currentLeftBullet;

        private void Attack()
        {
            Debug.Log("attack");
            target = transform.parent.GetComponent<ShootingEnemyController>().player.transform;

            currentRightBullet = Instantiate(bullet, rightArm.position, rightArm.rotation);
            currentRightBullet.transform.LookAt(target);

            currentLeftBullet = Instantiate(bullet, leftArm.position, leftArm.rotation);
            currentLeftBullet.transform.LookAt(target);
        }
    }
}
