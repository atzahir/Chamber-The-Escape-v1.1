using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManagement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject textObject;

    private void Start()
    {
        textObject.transform.localScale = new Vector3(0, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D textTriggerEnter)
    {
        if (textTriggerEnter.gameObject.name.Equals("Player"))
        {
            textObject.transform.localScale = new Vector3(1, 1, 0);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            textObject.transform.localScale = new Vector3(1, 1, 0);
        }
    }

    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D textTriggerExit)
    {
        textObject.transform.localScale = new Vector3(0, 0, 0);
    }
}
