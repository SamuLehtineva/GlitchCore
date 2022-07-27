using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GC.GlitchCoreProject
{
    public class Gun2 : MonoBehaviour
    {
        public Transform orientation;
        public float baseFireDelay = 20;
        public InputManager inputManager;
        public Transform muzzlePos;

        float fireDelay;
        private PlayerInput playerInput;
        private float fireTimer = 0.0f;
        private RaycastHit hit;
        
        void FixedUpdate()
		{
            fireDelay = baseFireDelay / PlayerStats.instance.fireDelayMod;
            if (fireTimer < fireDelay)
			{
                fireTimer += 1.0f;
			}
		}

        void Fire1(InputAction.CallbackContext context)
		{
            if (fireTimer >= fireDelay)
			{
                ViewModelController.instance.PlayFireAnim();
                Debug.DrawLine(transform.position, orientation.forward * 50, Color.black, 5f);
                if (Physics.Raycast(transform.position, orientation.forward, out hit, 50f))
				{
                    EffectManager.instance.SpawnEffect(0, hit.point, transform.rotation);
                    EnemyStats stats = hit.transform.gameObject.GetComponent<EnemyStats>();
                    if (stats != null)
					{
                        stats.Damage(4);
                        hit.rigidbody.AddForce(transform.forward * 600f);
					}
                    if (hit.transform.gameObject.layer == 6)
					{
                        DecalManager.instance.CreateDecal(hit, 0);
                    }
				}
                fireTimer = 0f;

                if (muzzlePos != null)
                {
                    EffectManager.instance.SpawnEffect(3, muzzlePos.position, transform.rotation);
                }
			}
		}

		private void OnEnable()
		{
            Debug.Log("OnEnable");
            playerInput = inputManager.playerInput;

            playerInput.Player.Fire1.Enable();
            playerInput.Player.Fire1.performed += Fire1;
            fireTimer = fireDelay * 0.75f;
        }

		private void OnDisable()
		{
            playerInput.Player.Fire1.Disable();
            playerInput.Player.Fire1.performed -= Fire1;
		}
	}
}
