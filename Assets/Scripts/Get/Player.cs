
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
    private Partner partner;
    private Supplier supplier;
    private string TurnOrder;
    private string CompanyDimension;
    private string Nickname;
    private int avatar;
    private int position;
    private bool actionComplete;
    private int value;
    private List<ProjectCard>[] projectLists = new List<ProjectCard>[]
    {
        new List<ProjectCard>(),
        new List<ProjectCard>(),
        new List<ProjectCard>()
    };

    public Player(ListEmployees ListEmployees, ListTechnologies ListTechnologies, 
    ListAbilities ListAbilities, Itilianos Itilianos, string CompanyDimension, string Nickname, int avatar){
        this.ListEmployees = ListEmployees;
        this.ListTechnologies = ListTechnologies;
        this.ListAbilities = ListAbilities;
        this.Itilianos = Itilianos;
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
    public Partner GetPartner(){return this.partner;}
    public int getPosition(){return position;}
    public Supplier GetSupplier(){return this.supplier;}
    public List<ProjectCard> GetProjects(int difficult){return this.projectLists[difficult];}
    public void setPosition(int position){this.position = position;}
    public bool getIsActionComplete(){return actionComplete;}
    public void setIsActionComplete(bool v){this.actionComplete = v;}
    public void setTurnOrder(string TurnOrder){this.TurnOrder = TurnOrder;}
    public void SetPartner(Partner partner){this.partner = partner;}
    public void SetSupplier(Supplier supplier){this.supplier = supplier;}
    public void addProject(ProjectCard card){this.projectLists[card.Difficulty].Add(card);}
    }
}
