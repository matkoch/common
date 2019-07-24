// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nuke.Common.Tools.CloudFoundry
{
    public partial class CloudFoundryCreateUserProvidedServiceSettings : ISerializable
    {
        [NonSerialized]
        private JObject _credentials = new JObject();

        public CloudFoundryCreateUserProvidedServiceSettings(SerializationInfo info, StreamingContext context)
        {
            var credentials = (string) info.GetValue(nameof(_credentials), typeof(string));
            
            if (credentials != null)
            {
                _credentials = JObject.Parse(credentials);
            }
            foreach (var property in GetType().GetProperties().Where(x => x.Name != nameof(Credentials) && x.CanWrite))
            {
                property.SetValue(this, info.GetValue(property.Name, property.PropertyType));
            }
        }

        public CloudFoundryCreateUserProvidedServiceSettings()
        {
        }

        internal string GetCredentials() => _credentials.ToString(Formatting.None);

        public virtual JObject Credentials
        {
            get => _credentials;
            set => _credentials = value;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(_credentials),GetCredentials());
            foreach (var property in GetType().GetProperties().Where(x => x.Name != nameof(Credentials)))
            {
                Console.WriteLine(property.Name);
                info.AddValue(property.Name, property.GetValue(this));
            }
            
        }
    }
}