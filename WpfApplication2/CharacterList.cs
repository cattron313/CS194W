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

    private static void initializeList()
    {
        c_List = new List<Character>();
        String[] c_List_Paths = getEmptyPathsList();
        c_List_Paths[Character.HEAD] = "MeatWad_Images\\Meatwad.gif";
        Character c_0 = new Character("Meatwad", "MeatWad_Images\\Meatwad.gif", c_List_Paths, 0);
        c_List.Add(c_0);

        String[] c_List_Paths_1 = getEmptyPathsList();
        c_List_Paths_1[Character.HEAD] = "Optimusg1_Images\\head.gif";
        c_List_Paths_1[Character.FOOT_LEFT] = "Optimusg1_Images\\left_foot.gif";
        c_List_Paths_1[Character.FOOT_RIGHT] = "Optimusg1_Images\\right_foot.gif";
        c_List_Paths_1[Character.KNEE_LEFT] = "Optimusg1_Images\\left_knee.gif";
        c_List_Paths_1[Character.KNEE_RIGHT] = "Optimusg1_Images\\right_knee.gif";
        c_List_Paths_1[Character.HAND_LEFT] = "Optimusg1_Images\\left_hand.gif";
        c_List_Paths_1[Character.HAND_RIGHT] = "Optimusg1_Images\\right_hand.gif";
        c_List_Paths_1[Character.SHOULDER_LEFT] = "Optimusg1_Images\\left_shoulder.gif";
        c_List_Paths_1[Character.SHOULDER_RIGHT] = "Optimusg1_Images\\right_shoulder.gif";
        c_List_Paths_1[Character.SPINE] = "Optimusg1_Images\\torso.gif";

       // string[] obj_1 = {"Optimusg1_Images\\head.gif", "Optimusg1_Images\\left_knee.gif", "Optimusg1_Images\\left_foot.gif", "Optimusg1_Images\\left_hand.gif", "Optimusg1_Images\\left_shoulder.gif", "Optimusg1_Images\\right_foot.gif", "Optimusg1_Images\\right_hand.gif", "Optimusg1_Images\\right_knee.gif", "Optimusg1_Images\\right_shoulder.gif", "Optimusg1_Images\\torso.gif"};
        Character c_1 = new Character("OptimusPrime", "Optimusg1_Images\\Optimus.gif", c_List_Paths_1, 1);
        c_List.Add(c_1);

        String[] c_List_Paths_2 = getEmptyPathsList();
        c_List_Paths_2[Character.HEAD] = "SMoon_Images\\head.gif";
        c_List_Paths_2[Character.FOOT_LEFT] = "SMoon_Images\\left_foot.gif";
        c_List_Paths_2[Character.FOOT_RIGHT] = "SMoon_Images\\right_foot.gif";
        c_List_Paths_2[Character.KNEE_LEFT] = "SMoon_Images\\left_knee.gif";
        c_List_Paths_2[Character.KNEE_RIGHT] = "SMoon_Images\\right_knee.gif";
        c_List_Paths_2[Character.HAND_LEFT] = "SMoon_Images\\left_hand.gif";
        c_List_Paths_2[Character.HAND_RIGHT] = "SMoon_Images\\right_hand.gif";

        c_List_Paths_2[Character.ARM_LEFT] = "SMoon_Images\\left_arm.gif";
        c_List_Paths_2[Character.ARM_RIGHT] = "SMoon_Images\\right_arm.gif";
        c_List_Paths_2[Character.SPINE] = "SMoon_Images\\torso.gif";

        Character c_2 = new Character("SailorMoon", "SMoon_Images\\SailorMoon.gif", c_List_Paths_2, 2);
        c_List.Add(c_2);
    }

    private static String[] getEmptyPathsList()
    {
        String[] list = new String[22];
        for (int i = 0; i < 22; i++)
            list[i] = "";
        return list;
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
        if (c_List == null) {
            c_List = new List<Character>();
            initializeList();
        }
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
