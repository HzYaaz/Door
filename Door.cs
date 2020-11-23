using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{

	[SerializeField] private float distance;
	[SerializeField] private GameObject player;
	private Ray ray;
	private bool dondur = true;
	[SerializeField] private bool opened = false;
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{

		if (opened == false)
        {
			distance = Vector3.Distance(transform.position, player.transform.position);
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Input.GetKeyDown(KeyCode.Mouse0) && distance < 2 && Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Door")
			{
				gameObject.GetComponent<Animation>().Play("DoorOpen");
				StartCoroutine(DoorAnimOpen());
			}
		}		
		else
        {
			distance = Vector3.Distance(transform.position, player.transform.position);
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Input.GetKeyDown(KeyCode.Mouse0) && distance < 2 && Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Door")
			{
				gameObject.GetComponent<Animation>().Play("DoorClose");
				StartCoroutine(DoorAnimClose());
			}
		}
	}
	IEnumerator DoorAnimOpen()
    {
			yield return new WaitForSeconds(2f);
			opened = true;	
	}
	IEnumerator DoorAnimClose()
	{
			yield return new WaitForSeconds(2f);
			opened = false;		
	}
}
