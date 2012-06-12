using System;
using System.Collections.Generic;

public class Character
{
    private String name;
    private string whole;
    private string[] paths;
    private int index;
    private double positionX = 1500 / 2;
    private double positionY = 900 / 2;
    private List<System.Windows.Point> offsetList = new List<System.Windows.Point>();

    public static int HEAD = 0;
    public static int ANKLE_LEFT = 17;
    public static int ANKLE_RIGHT = 12;
    public static int ELBOW_LEFT = 13;
    public static int ELBOW_RIGHT = 6;
    public static int FOOT_LEFT = 3;
    public static int FOOT_RIGHT = 4;
    public static int HAND_LEFT = 7;
    public static int HAND_RIGHT = 8;
    public static int HIP_CENTER = 9;
    public static int HIP_LEFT = 10;
    public static int HIP_RIGHT = 11;
    public static int KNEE_LEFT = 1;
    public static int KNEE_RIGHT = 2;
    public static int SHOULDER_CENTER = 14;
    public static int SHOULDER_LEFT = 15;
    public static int SHOULDER_RIGHT = 16;
    public static int SPINE = 5;
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
        createOffsetList();
    }

    public Character(Character c) //string c_name, string c_whole, string[] c_paths, int c_index)
    {
        name = c.getName();
        paths = c.getParts();// c_paths;
        index = c.getIndex();// c_index;
        whole = c.getWhole();
        offsetList = c.getOffsetList();
    }

    private void createOffsetList()
    {
        for (int i = 0; i < 22; i++)
            offsetList.Add(new System.Windows.Point(0, 0));
    }

    public void setOffset(int bodyPart, double x, double y)
    {
        System.Windows.Point p = new System.Windows.Point(x, y);
        offsetList[bodyPart] = p;
    }

    public System.Windows.Point getOffset(int bodyPart)
    {
        return offsetList[bodyPart];
    }

    public int getOffsetX(int bodyPart)
    {
        return Convert.ToInt32(offsetList[bodyPart].X);
    }

    public int getOffsetY(int bodyPart)
    {
        return Convert.ToInt32(offsetList[bodyPart].Y);
    }
    public List<System.Windows.Point> getOffsetList()
    {
        return offsetList;
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

    public double getXPos()
    {
        return positionX;
    }
    public double getYPos()
    {
        return positionY;
    }
    public void setPosition(double x, double y)
    {
        positionX = x;
        positionY = y;
    }
}
