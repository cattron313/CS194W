using System;

public class Character
{
    private string name;
    private string whole;
    private string[] paths;
    private int index;
    public static int HEAD = 0;
    public static int ANKLE_LEFT = 1;
    public static int ANKLE_RIGHT = 2;
    public static int ELBOW_LEFT = 3;
    public static int ELBOW_RIGHT = 4;
    public static int FOOT_LEFT = 5;
    public static int FOOT_RIGHT = 6;
    public static int HAND_LEFT = 7;
    public static int HAND_RIGHT = 8;
    public static int HIP_CENTER = 9;
    public static int HIP_LEFT = 10;
    public static int HIP_RIGHT = 11;
    public static int KNEE_LEFT = 12;
    public static int KNEE_RIGHT = 13;
    public static int SHOULDER_CENTER = 14;
    public static int SHOULDER_LEFT = 15;
    public static int SHOULDER_RIGHT = 16;
    public static int SPINE = 17;
    public static int WRIST_LEFT = 18;
    public static int WRIST_RIGHT = 19;
    public static int ARM_LEFT = 20;
    public static int ARM_RIGHT = 21;
    
	public Character(string c_name, string c_whole, string[] c_paths, int c_index)
	{
        name = c_name;
        paths = c_paths;
        index = c_index;
        whole = c_whole;
	}

    public void setIndex(int i)
    {
        index = i;
    }

    public string getName()
    {
        return name;
    }

    public string[] getParts()
    {
        return paths;
    }

    public string getPart(int bodyPartIndex)
    {
        return paths[bodyPartIndex];
    }

    public string getWhole()
    {
        return whole;
    }

    public int getIndex()
    {
        return index;
    }
}
