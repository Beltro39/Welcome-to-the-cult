using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : Resources
{
    public Abilities(int amount) : base(amount, 4){
    }    

}

public class Recruitment : Abilities{
    public Recruitment(int amount) : base(amount){
    }
}

public class Skillful : Abilities{
    public Skillful(int amount) : base(amount){
    }
}

public class Bargain : Abilities{
    public Bargain(int amount) : base(amount){
    }
}

public class Research : Abilities{
    public Research(int amount) : base(amount){
    }
}

public class ListAbilities{
    Recruitment Recruitment;
    Skillful Skillful;
    Bargain Bargain;
    Research Research;
    private int countAbilities;
    private int countAvailableAbilities;
    private int averageAbilities;
    private int averageAvailableAbilities;

    public ListAbilities(Recruitment Recruitment, Skillful Skillful, Bargain Bargain, Research Research){
        this.Recruitment= Recruitment;
        this.Skillful= Skillful;
        this.Bargain= Bargain;
        this.Research= Research;
        AddAbilities(Recruitment); AddAbilities(Skillful); AddAbilities(Bargain); AddAbilities(Research);
        calculateAverageAbilities();
    }

    public void AddAbilities(Abilities Abilities)
    {
        int amount= Abilities.getAmount();
        countAbilities+= amount;
        countAvailableAbilities+= amount;
    }

    public void calculateAverageAbilities(){
        averageAbilities= (int) (countAvailableAbilities)/4;
        averageAvailableAbilities= (int) (countAvailableAbilities)/4;
    }
    public int getAverageAvailableAbilities(){
        return averageAvailableAbilities;
    }
    public int getAverageAbilities(){
        return averageAbilities;
    }
    public ListAbilities(){
    }

    public Recruitment getRecruitment(){return Recruitment;}
    public Skillful getSkillful(){return Skillful;}
    public Bargain getBargain(){return Bargain;}
    public Research getResearch(){return Research;}

}