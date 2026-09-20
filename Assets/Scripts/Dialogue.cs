using System;

[Serializable]
public class Dialogue
{
    public int id;
    public string page;
    public string message;
    public int bugs;
}

[Serializable]
public class DialogueList
{
    public Dialogue[] dialogues;
}