using UnityEngine;


namespace VehicleGame.Gameplay.Player
{
    public class FollowCamera : MonoBehaviour
    {
        public Transform target;
        public float smoothTime = 0.15f;
        public Vector3 offset;

        private Vector3 velocity = Vector3.zero;

        private void LateUpdate()
        {
            if (!target) return;

            Vector3 desiredPos = new Vector3(
                transform.position.x,
                transform.position.y,
                target.position.z + offset.z
            );

            transform.position = Vector3.SmoothDamp(
                transform.position,
                desiredPos,
                ref velocity,
                smoothTime
            );
        }
    }
}

