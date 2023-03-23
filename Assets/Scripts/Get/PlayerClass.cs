
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lean.Gui{
public class PlayerClass 
{
    private ListEmployees ListEmployees;
    private ListTechnologies ListTechnologies;
    private ListAbilities ListAbilities;
    private Itilianos Itilianos;
    private string position;
    private string TurnOrder;
    private string CompanyDimension;
    private string Nickname;
    private int avatar;

    public PlayerClass(ListEmployees ListEmployees, ListTechnologies ListTechnologies, 
    ListAbilities ListAbilities, Itilianos Itilianos, string position, string TurnOrder, string CompanyDimension, string Nickname, int avatar){
        this.ListEmployees = ListEmployees;
        this.ListTechnologies = ListTechnologies;
        this.ListAbilities = ListAbilities;
        this.Itilianos = Itilianos;
        this.position = position;
        this.TurnOrder = TurnOrder;
        this.CompanyDimension = CompanyDimension;
        this.Nickname = Nickname;
        this.avatar = avatar;
    }

    public ListEmployees getListEmployees(){return ListEmployees;}
    public ListTechnologies getListTechnologies(){return ListTechnologies;}
    public ListAbilities getListAbilities(){return ListAbilities;}
    public Itilianos getItilianos(){return Itilianos;}
    public string getPosition(){return position;}
    public string getTurnOrder(){return TurnOrder;}
    public string getCompanyDimension(){return CompanyDimension;}
    public string getNickname(){return Nickname;}
    public int getAvatar(){return avatar;}

}
}
