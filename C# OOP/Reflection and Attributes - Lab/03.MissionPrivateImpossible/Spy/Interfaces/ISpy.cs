namespace _02.High_Quality_Mistakes.Spy.Interfaces
{
    public interface ISpy
    {
        string StealFieldInfo(string investigatedClass, params string[] namesToInvistigate);
        string AnalyzeAccessModifiers(string className);
        string RevealPrivateMethods(string className);
    }
}
