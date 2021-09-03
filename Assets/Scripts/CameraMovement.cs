using UnityEngine;

namespace Assets.Scripts
{
    public class CameraMovement : MonoBehaviour
    {
        private Vector3 refVelocity = Vector3.zero;

        [SerializeField] int maxOffset = 3;

        void Update()
        {
            // Berechnet den Offset zwischen Kamera und Player
            Vector3 offset = transform.position - PlayerMovement.Instance.transform.position;
            // legt eine Variable für die neue Kameraposition an
            Vector3 newCameraPosition = transform.position;
            // bewegt die Kamera in x Richtung auf die Position des Players, falls der Offset zwischen beiden größer als $maxOffset ist
            // nur in der Vorwärtsbewegung
            if (offset.x < -maxOffset)
                newCameraPosition.x = PlayerMovement.Instance.transform.position.x - maxOffset;

            if (offset.x > maxOffset)
                newCameraPosition.x = PlayerMovement.Instance.transform.position.x + maxOffset;

            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Mathf.Max(0, newCameraPosition.x), 0, -10f), ref refVelocity, 0.2f);
        }
    }
}