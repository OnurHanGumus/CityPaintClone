using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class EnemyPhysicsController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables
    [SerializeField] private P3dPaintDecal decal;
    [SerializeField] private EnemyManager manager;

    #endregion

    #region Private Variables

    #endregion
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            DrawRay();
            transform.parent.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            manager.OutOfMap();
        }
    }

    private void DrawRay()
    {
        Debug.Log("DrawRay");
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit))
        {
            var priority = 0; // If you're painting multiple times per frame, or using 'live painting', then this can be used to sort the paint draw order. This should normally be set to 0.
            var pressure = 1.0f; // If you're using modifiers that use paint pressure (e.g. from a finger), then you can set it here. This should normally be set to 1.
            var seed = 0; // If this paint uses modifiers that aren't marked as 'Unique', then this seed will be used. This should normally be set to 0.
            var rotation = Quaternion.LookRotation(-hit.normal); // Get the rotation of the paint. This should point TOWARD the surface we want to paint, so we use the inverse normal.

            decal.Color = manager.GetMeshRenderer();
            decal.HandleHitPoint(false, priority, pressure, seed, hit.point, rotation);
        }

    }

}
