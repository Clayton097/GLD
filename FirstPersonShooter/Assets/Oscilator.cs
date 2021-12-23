using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{
    [SerializeField] bool start = false;

    Vector3 startingPos;
    [SerializeField]
    Vector3 target;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startingPos, target);

        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start) { return; }

        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(transform.position, target, fractionOfJourney);

        if (Vector3.Distance(transform.position, target) < 0.01f) start = false;
    }

    public void TryOpenGate(bool open)
    {
        start = open;
    }
}
