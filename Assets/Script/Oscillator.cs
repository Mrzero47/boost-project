using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
     Vector3 startpos;
    [SerializeField] Vector3 movementpos;
    [SerializeField] [Range(0, 1)] float movementFactor;
    [SerializeField] float perid;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        //perid = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (perid == Mathf.Epsilon) { return; }
        float cycle = Time.time / perid;
        const float tau = Mathf.PI * 2;
        float sinwav = Mathf.Sin(cycle*tau);
        movementFactor = (sinwav + 1f) / 2f;//change the range to get back form 0-1
        Vector3 offset = movementpos * movementFactor;

        transform.position = startpos + offset;
    }
}
