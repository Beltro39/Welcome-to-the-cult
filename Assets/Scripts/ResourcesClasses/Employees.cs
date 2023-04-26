using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employees : Resources{
    public Employees(int amount) : base(amount, 1000){
    }
}

public class Juniors: Employees{
    public Juniors(int amount) : base(amount){
    }
}
public class SemiSeniors: Employees{
    public SemiSeniors(int amount) : base(amount){
    }
}
public class Seniors: Employees{
    public Seniors(int amount) : base(amount){
    }
}
public class Architects: Employees{
    public Architects(int amount) : base(amount){
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
    }
    public ListEmployees(){
    }

    public int getCountEmployees() {
        int total = Juniors.getAmount() + SemiSeniors.getAmount()
        + Seniors.getAmount() + Architects.getAmount();
        return total;
    }
    public int getCountAvailableEmployees() {
        int total = Juniors.getCurrentAvailableResource() + SemiSeniors.getCurrentAvailableResource()
        + Seniors.getCurrentAvailableResource() + Architects.getCurrentAvailableResource();
        return total;
    }
    public Juniors getJuniors() { return Juniors;}
    public SemiSeniors getSemiSeniors() { return SemiSeniors;}
    public Seniors getSeniors() { return Seniors;}
    public Architects getArchitects() { return Architects;}

}