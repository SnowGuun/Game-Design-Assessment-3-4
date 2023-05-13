using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopIndicator : MonoBehaviour
{
    public float maxDistance = 10.0f;   // The maximum distance at which the cop can be detected.
    public Image dangerIndicator;       // A reference to the danger indicator image.
    public string[] copTags;            // An array of cop tags to search for.
    private GameObject player;          // A reference to the player game object.
    private GameObject[] cops;          // A reference to the cops game object.

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dangerIndicator.enabled = false;

        cops = new GameObject[copTags.Length];
        for (int i = 0; i < copTags.Length; i++)
        {
            cops[i] = GameObject.FindGameObjectWithTag(copTags[i]);
        }
    }

    void Update()
    {
        float closestDistance = Mathf.Infinity;

        // Find the closest cop.
        foreach (GameObject cop in cops)
        {
            float distance = Vector3.Distance(player.transform.position, cop.transform.position);
            closestDistance = Mathf.Min(closestDistance, distance);
        }

        // Calculate the alpha value based on the distance to the closest cop.
        float alpha = Mathf.Lerp(0.0f, 1.0f, (maxDistance - closestDistance) / maxDistance);

        // Update the danger indicator color and visibility.
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
