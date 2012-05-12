using System;
using System.Collections.Generic;

public class CharacterList
{
    private static List<Character> c_List;
    int curCharIndex = 0;

	public CharacterList()
	{
        initializeList();
	}

    private void initializeList()
    {
        c_List = new List<Character>();
        Character c_0 = new Character("Meatwad", "MeatWad_Images\\Meatwad.gif", null, 0);
        c_List.Add(c_0);

        string[] obj_1 = {"Optimusg1_Images\\head.gif", "Optimusg1_Images\\left_knee.gif", "Optimusg1_Images\\left_foot.gif", "Optimusg1_Images\\left_hand.gif", "Optimusg1_Images\\left_shoulder.gif", "Optimusg1_Images\\right_foot.gif", "Optimusg1_Images\\right_hand.gif", "Optimusg1_Images\\right_knee.gif", "Optimusg1_Images\\right_shoulder.gif", "Optimusg1_Images\\torso.gif"};
        Character c_1 = new Character("Optimus Prime", "Optimusg1_Images\\Optimus.gif", obj_1, 1);
        c_List.Add(c_1);

        string[] obj_2 = {"SMoon_Images\\head.gif", "SMoon_Images\\left_knee.gif", "SMoon_Images\\left_foot.gif", "SMoon_Images\\left_hand.gif", "SMoon_Images\\right_foot.gif", "SMoon_Images\\right_hand.gif", "SMoon_Images\\right_knee.gif", "SMoon_Images\\torso.gif", "SMoon_Images\\left_arm.gif", "SMoon_Images\\right_arm.gif"};
        Character c_2 = new Character("Sailor Moon", "SMoon_Images\\SailorMoon.gif", obj_2, 2);
        c_List.Add(c_2);
    }

    public int getNumChars()
    {
        return c_List.Count;
    }

    /*public String getCharacterName(string characterName) {
        foreach (Character c in c_List)
        {
            if (String.
       c.getName()
        }
        return c_List[index].getName();
    }*/

    public static Character getCharacter(string characterName)
    {
        foreach (Character c in c_List)
        {
            if (String.Compare(c.getName(), characterName) == 0) return c;
        }
        return null;
    }

    public void setCurCharIndex(int i)
    {
        curCharIndex = i;
    }

    public int getCurCharIndex()
    {
        return curCharIndex;
    }
}
