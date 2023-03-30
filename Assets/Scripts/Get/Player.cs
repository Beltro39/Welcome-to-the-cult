
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lean.Gui{
public class Player 
{
    private ListEmployees ListEmployees;
    private ListTechnologies ListTechnologies;
    private ListAbilities ListAbilities;
    private Itilianos Itilianos;
    private string TurnOrder;
    private string CompanyDimension;
    private string Nickname;
    private int avatar;
    private int position;
    private bool actionComplete;

    public Player(ListEmployees ListEmployees, ListTechnologies ListTechnologies, 
    ListAbilities ListAbilities, Itilianos Itilianos, string TurnOrder, string CompanyDimension, string Nickname, int avatar){
        this.ListEmployees = ListEmployees;
        this.ListTechnologies = ListTechnologies;
        this.ListAbilities = ListAbilities;
        this.Itilianos = Itilianos;
        this.TurnOrder = TurnOrder;
        this.CompanyDimension = CompanyDimension;
        this.Nickname = Nickname;
        this.avatar = avatar;
    }

    public ListEmployees getListEmployees(){return ListEmployees;}
    public ListTechnologies getListTechnologies(){return ListTechnologies;}
    public ListAbilities getListAbilities(){return ListAbilities;}
    public Itilianos getItilianos(){return Itilianos;}
    public string getTurnOrder(){return TurnOrder;}
    public string getCompanyDimension(){return CompanyDimension;}
    public string getNickname(){return Nickname;}
    public int getAvatar(){return avatar;}
    public int getPosition(){return position;}
    public void setPosition(int position){this.position = position;}
    public bool getIsActionComplete(){return actionComplete;}
    public void setIsActionComplete(bool v){this.actionComplete = v;}
}
}
