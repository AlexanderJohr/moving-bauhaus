using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float dampTime;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    public Transform target;

    private void Awake()
    {
        if (MenuAudioDon.Instance != null)
        {
            MenuAudioDon.Instance.gameObject.GetComponent<AudioSource>().Stop();
        }
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp (transform.position, desiredPosition, ref velocity, dampTime);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }

}
