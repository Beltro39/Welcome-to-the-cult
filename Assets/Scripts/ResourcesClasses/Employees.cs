using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employees : Resources{
    public Employees(int limitResourcePerRound, int amount, int cost) : base(limitResourcePerRound, amount, cost, 1000){
    }

    public void updateCost(){
    }

    public int getCostUpdated(){
        updateCost();
        return getCost();
    }
}

public class Juniors: Employees{
    public Juniors(int amount) : base(25, amount, 1){
    }
}
public class SemiSeniors: Employees{
    public SemiSeniors(int amount) : base(9, amount, 3){
    }
}
public class Seniors: Employees{
    public Seniors(int amount) : base(5, amount, 5){
    }
}
public class Architects: Employees{
    public Architects(int amount) : base(2, amount, 10){
    }
}

 public class ListEmployees{
    private Juniors Juniors;
    private SemiSeniors SemiSeniors;
    private Seniors Seniors;
    private Architects Architects;
    private int countEmployees= 0;
    private int countAvailableEmployees;
    public ListEmployees(Juniors Juniors, SemiSeniors SemiSeniors, Seniors Seniors, Architects Architects){
        this.Juniors = Juniors;
        this.SemiSeniors = SemiSeniors;
        this.Seniors = Seniors;
        this.Architects = Architects;
        AddEmployees(this.Juniors); AddEmployees(this.SemiSeniors); AddEmployees(this.Seniors); AddEmployees(this.Architects);
    }
    public ListEmployees(){
    }
     public void AddEmployees(Employees employees)
    {   int amount = employees.getAmount();
        countEmployees+= amount;
        countAvailableEmployees+= amount;
    }
     public int getCountEmployees() {
        return countEmployees;
    }
    public int getCountAvailableEmployees() {
        return countAvailableEmployees;
    }
    public Juniors getJuniors() { return Juniors;}
    public SemiSeniors getSemiSeniors() { return SemiSeniors;}
    public Seniors getSeniors() { return Seniors;}
    public Architects getArchitects() { return Architects;}

}