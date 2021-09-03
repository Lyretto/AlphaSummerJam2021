using UnityEngine;

namespace Assets.Scripts
{
    public class CameraMovement : MonoBehaviour
    {
        private Vector3 refVelocity = Vector3.zero;

        [SerializeField] int maxOffset = 3;

        void Update()
        {
            Vector3 offset = transform.position - PlayerMovement.Instance.transform.position;
            Vector3 newCameraPosition = transform.position;
            if (offset.x < -maxOffset)
                newCameraPosition.x = PlayerMovement.Instance.transform.position.x - maxOffset;

            if (offset.x > maxOffset)
                newCameraPosition.x = PlayerMovement.Instance.transform.position.x + maxOffset;

            if (offset.y > maxOffset)
                newCameraPosition.y = PlayerMovement.Instance.transform.position.y - maxOffset;

            if (offset.y < maxOffset)
                newCameraPosition.y = PlayerMovement.Instance.transform.position.y + maxOffset;

            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Mathf.Max(0, newCameraPosition.x), Mathf.Max(0, newCameraPosition.y), -10f), ref refVelocity, 0.2f);
        }
    }
}