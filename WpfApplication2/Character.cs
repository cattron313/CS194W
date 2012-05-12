using System;

public class Character
{
    private string name;
    private string whole;
    private string[] model;
    private int index;

	public Character(string c_name, string c_whole, string[] c_model, int c_index)
	{
        name = c_name;
        model = c_model;
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
        return model;
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
