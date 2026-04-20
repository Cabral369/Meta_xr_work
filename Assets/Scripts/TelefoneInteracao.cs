using UnityEngine;
public class TelefoneInteracao : MonoBehaviour
{
	[Header("Referências")]
	public Transform monofone;
	public AudioSource audioSource;
	[Header("Animação")]
	public float alturaSubida = 0.1f;
	public float velocidade = 2f;
	private bool atendendo = false;
	private Vector3 posicaoOriginal;
	private Vector3 posicaoAlvo;
	void Start()
	{
		posicaoOriginal = monofone.localPosition;
		posicaoAlvo = posicaoOriginal + new Vector3(0, alturaSubida, 0);
	}
	void Update()
	{
		if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) ||
			OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
		{
			Transform rightHand = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch) != Vector3.zero
				? GameObject.Find("RightHandAnchor")?.transform
				: null;
			Transform origin = rightHand != null ? rightHand : Camera.main.transform;
			Ray ray = new Ray(origin.position, origin.forward);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform == this.transform || hit.transform.IsChildOf(this.transform))
				{
					AlternarEstado();
				}
			}
		}
		Vector3 destino = atendendo ? posicaoAlvo : posicaoOriginal;
		monofone.localPosition = Vector3.Lerp(monofone.localPosition, destino, Time.deltaTime * velocidade);
	}
	void AlternarEstado()
	{
		atendendo = !atendendo;
		if (atendendo)
		{
			audioSource.loop = true;
			audioSource.Play();
		}
		else
		{
			audioSource.Stop();
		}
	}
}