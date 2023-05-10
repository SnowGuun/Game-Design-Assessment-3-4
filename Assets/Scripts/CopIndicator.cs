using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopIndicator : MonoBehaviour
{
    public float maxDistance = 10.0f;   // The maximum distance at which the cop can be detected.
    public Image dangerIndicator;       // A reference to the danger indicator image.

    private GameObject player;          // A reference to the player game object.

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dangerIndicator.enabled = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        float alpha = Mathf.Lerp(0.0f, 1.0f, (maxDistance - distance) / maxDistance);
        Color dangerColor = dangerIndicator.color;
        dangerColor.a = alpha;
        dangerIndicator.color = dangerColor;

        if (alpha > 0.0f)
        {
            dangerIndicator.enabled = true;
        }
        else
        {
            dangerIndicator.enabled = false;
        }
    }
}
