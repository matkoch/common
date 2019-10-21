using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nuke.Common.Tooling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nuke.Common.Tools.Nbgv
{
    public partial class NbgvTasks
    {
        // nbgv get-commits
        [CanBeNull]
        private static List<string> GetResult(IProcess process, NbgvGetCommitsSettings toolSettings)
        {
            return process.Output.EnsureOnlyStd().Select(x => x.Text).ToList();
        }


        // nbgv get-version
        private static readonly IContractResolver customContractResolver = new CustomContractResolver();

        [CanBeNull]
        private static Nbgv GetResult(IProcess process, NbgvGetVersionSettings toolSettings)
        {
            var output = process.Output.EnsureOnlyStd().Select(x => x.Text).ToList();

            // if output format is json
            if (toolSettings.Format == NbgvFormat.json)
            {
                var json = string.Join(EnvironmentInfo.NewLine, output);
                var settings = new JsonSerializerSettings { ContractResolver = customContractResolver };
                return JsonConvert.DeserializeObject<Nbgv>(json, settings);
            }

            // output is text            
            var nbgv = new Nbgv();
            // If we ask for a specific variable ie: nbgv get-version --variable Version
            // it will output the value of the Version variable
            if (!string.IsNullOrEmpty(toolSettings.Variable))
            {
                nbgv.SetPropertyValue(toolSettings.Variable, output.Single());
            }
            // If we want all variables then output is VariableName:VariableValue
            else
            {
                output.ForEach(o =>
                {
                    var splitted = o.Split(':');
                    nbgv.SetPropertyValue(splitted[0].Trim(), splitted[1].Trim());
                });
            }

            return nbgv;
        }

        private static void SetPropertyValue(this Nbgv nbgv, string propertyName, string propertyValue)
        {
            var propertyInfo = nbgv.GetType().GetProperty(propertyName);
            propertyInfo.SetValue(nbgv, Convert.ChangeType(propertyValue, propertyInfo.PropertyType), null);
        }

        private class CustomContractResolver : DefaultContractResolver
        {
            private const string InternalSuffix = "Internal";

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = member as PropertyInfo;
                var jProperty = base.CreateProperty(member, memberSerialization);
                jProperty.Writable = true;
                if (property != null && jProperty != null && memberSerialization != MemberSerialization.Fields && !jProperty.HasMemberAttribute)
                {
                    var replacementName = jProperty.UnderlyingName + InternalSuffix;

                    var replacementProperty = jProperty.DeclaringType.GetProperty(replacementName, BindingFlags.Instance | BindingFlags.NonPublic);
                    if (replacementProperty != null
                        && replacementProperty.GetGetMethod(true) != null && replacementProperty.GetSetMethod(true) != null
                        && ReplacementTypeCompatible(property, replacementProperty.PropertyType)
                        )
                    {
                        var replacementJProperty = base.CreateProperty(replacementProperty, memberSerialization);
                        replacementJProperty.PropertyName = jProperty.PropertyName;
                        if (!replacementJProperty.Readable && replacementProperty.GetGetMethod(true) != null)
                            replacementJProperty.Readable = true;
                        if (!replacementJProperty.Writable && replacementProperty.GetSetMethod(true) != null)
                            replacementJProperty.Writable = true;
                        return replacementJProperty;
                    }
                }

                return jProperty;
            }

            private static bool ReplacementTypeCompatible(PropertyInfo property, Type replacementType)
            {
                if (property.PropertyType.IsGenericType && typeof(IReadOnlyList<>).IsAssignableFrom(property.PropertyType.GetGenericTypeDefinition())
                    && replacementType.IsGenericType && typeof(List<>).IsAssignableFrom(replacementType.GetGenericTypeDefinition())
                    && replacementType.GetGenericArguments().SequenceEqual(property.PropertyType.GetGenericArguments()))
                    return true;

                if (property.PropertyType.IsGenericType && typeof(IReadOnlyDictionary<,>).IsAssignableFrom(property.PropertyType.GetGenericTypeDefinition())
                    && replacementType.IsGenericType && typeof(Dictionary<,>).IsAssignableFrom(replacementType.GetGenericTypeDefinition())
                    && replacementType.GetGenericArguments().SequenceEqual(property.PropertyType.GetGenericArguments()))
                    return true;

                return false;
            }
        }
    }
}
