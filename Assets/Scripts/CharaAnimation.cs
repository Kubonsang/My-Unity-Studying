using UnityEngine;

public class CharaAnimation : MonoBehaviour
{
	Animator animator;
	CharacterStatus status;
	Vector3 prePosition;
	bool isDown = false;
	bool attacked = false;

	
	public bool IsAttacked()
	{
		return attacked;
	}
	
	void StartAttackHit()
	{
		Debug.Log ("StartAttackHit");
	}
	
	void EndAttackHit()
	{
		Debug.Log ("EndAttackHit");
	}
	
	void EndAttack()
	{
		attacked = true;
	}
	
	void Start ()
	{
		animator = GetComponent<Animator>();
		status = GetComponent<CharacterStatus>();
		
		prePosition = transform.position;
	}
	
	void Update ()
	{
		Vector3 delta_position = transform.position - prePosition;
		if(delta_position.magnitude / Time.deltaTime > 0.5 )
		{
			animator.SetBool("isMoving", true);
		}
		else
		{
			animator.SetBool("isMoving", false);
		}
		
		if(attacked && !status.attacking)
		{
			attacked = false;
		}
		animator.SetBool("Attacking", (!attacked && status.attacking));
		
		if(!isDown && status.died)
		{
			isDown = true;
			animator.SetTrigger("Down");
		}
		
		prePosition = transform.position;
	}
}