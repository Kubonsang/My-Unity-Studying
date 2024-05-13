using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour
{

    //---------- ���� �忡�� ����Ѵ�. ----------
    // ü��.
    public int HP = 100;
    public int MaxHP = 100;

    // ���ݷ�.
    public int Power = 10;

    // �������� ������ ���.
    public GameObject lastAttackTarget = null;

    //---------- GUI �� ��Ʈ��ũ �忡�� ����Ѵ�. ----------
    // �÷��̾� �̸�.
    public string characterName = "Player";

    //--------- �ִϸ��̼� �忡�� ����Ѵ�. -----------
    // ����.
    public bool attacking = false;
    public bool died = false;

}
