using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrachenController : MonoBehaviour
{
    [SerializeField] private float geschwindichkeit;
    private FixedJoystick fixedJoystick;
    private Rigidbody rigidbody;

    private void OnEnable()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;
        Vector3 movement = new Vector3(xVal, 0, yVal);
        rigidbody.linearVelocity = movement * geschwindichkeit;
        if (xVal != 0 && yVal != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal)*Mathf.Rad2Deg , transform.eulerAngles.z);

        }
    }
    
}
