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
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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