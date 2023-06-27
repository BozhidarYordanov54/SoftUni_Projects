using _02.High_Quality_Mistakes.Spy.Interfaces;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy : ISpy
    {
        public string StealFieldInfo(string investigatedClass, params string[] namesToInvistigate)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            object classInstance = Activator.CreateInstance(classType, new object[] { });

            stringBuilder.AppendLine($"Class under investigation {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => namesToInvistigate.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return stringBuilder.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classField = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] classMethodPrivate = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo[] classMethodPublic = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);


            StringBuilder stringBuilder = new StringBuilder();

            foreach (FieldInfo field in classField)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo methodPrivate in classMethodPrivate.Where(g => g.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{methodPrivate.Name} must have to be public!");
            }

            foreach (MethodInfo methodPublic in classMethodPublic.Where(s => s.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{methodPublic.Name} must have to be public!");
            }

            return stringBuilder.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] privateMethodInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"All Private Methods of Class: {className}");
            stringBuilder.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo privateMethod in privateMethodInfo)
            {
                stringBuilder.AppendLine(privateMethod.Name);
            }

            return stringBuilder.ToString().Trim();
        }
    }
}