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

        
        

        private void Attack()
        {
            currentRightBullet = Instantiate(bullet, rightArm.position, rightArm.rotation);
            

            currentLeftBullet = Instantiate(bullet, leftArm.position, leftArm.rotation);
            
        }
    }
}
