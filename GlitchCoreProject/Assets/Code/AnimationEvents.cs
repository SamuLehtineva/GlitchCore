using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class AnimationEvents : MonoBehaviour
    {
        public GameObject bullet;
        GameObject currentRightBullet, currentLeftBullet;
        public float shootSpeed;
        public Transform rightArm, leftArm;
        Rigidbody rbLeft, rbRight;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Attack()
        {
            currentRightBullet = Instantiate(bullet, rightArm.position, rightArm.rotation);
            rbRight = currentRightBullet.GetComponent<Rigidbody>();

            rbRight.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);

            currentLeftBullet = Instantiate(bullet, leftArm.position, leftArm.rotation);
            rbLeft = currentLeftBullet.GetComponent<Rigidbody>();

            rbLeft.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
        }
    }
}
