// Generated from https://github.com/VolkmarR/common/blob/master/build/specifications/Twitter.json
// Generated with Nuke.CodeGeneration version LOCAL (Windows,.NETStandard,Version=v2.0)

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Twitter
{
    #region TwitterApiKeys
    /// <summary>
    ///   Used within <see cref="TwitterTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class TwitterApiKeys : ISettingsEntity
    {
        /// <summary>
        ///   The Consumer Api Key needed to access the Twitter API. To get this key, an App with read and write permissions must be created using the <a href='https://developer.twitter.com/en/apps'>Twitter Developer Page</a>
        /// </summary>
        [JsonProperty("consumerApiKey")]
        public virtual string ConsumerApiKey { get; internal set; }
        /// <summary>
        ///   The Consumer Api Key Secret needed to access the Twitter API. See ConsumerApiKey on how to get it.
        /// </summary>
        [JsonProperty("consumerApiKeySecret")]
        public virtual string ConsumerApiKeySecret { get; internal set; }
        /// <summary>
        ///   The Access Token needed to access the Twitter API. See ConsumerApiKey on how to get it.
        /// </summary>
        [JsonProperty("accessToken")]
        public virtual string AccessToken { get; internal set; }
        /// <summary>
        ///   The Access Token Secret needed to access the Twitter API. See ConsumerApiKey on how to get it.
        /// </summary>
        [JsonProperty("accessTokenSecret")]
        public virtual string AccessTokenSecret { get; internal set; }
    }
    #endregion
    #region TwitterApiKeysExtensions
    /// <summary>
    ///   Used within <see cref="TwitterTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class TwitterApiKeysExtensions
    {
        #region ConsumerApiKey
        /// <summary>
        ///   <p><em>Sets <see cref="TwitterApiKeys.ConsumerApiKey"/></em></p>
        ///   <p>The Consumer Api Key needed to access the Twitter API. To get this key, an App with read and write permissions must be created using the <a href='https://developer.twitter.com/en/apps'>Twitter Developer Page</a></p>
        /// </summary>
        [Pure]
        public static TwitterApiKeys SetConsumerApiKey(this TwitterApiKeys toolSettings, string consumerApiKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConsumerApiKey = consumerApiKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TwitterApiKeys.ConsumerApiKey"/></em></p>
        ///   <p>The Consumer Api Key needed to access the Twitter API. To get this key, an App with read and write permissions must be created using the <a href='https://developer.twitter.com/en/apps'>Twitter Developer Page</a></p>
        /// </summary>
        [Pure]
        public static TwitterApiKeys ResetConsumerApiKey(this TwitterApiKeys toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConsumerApiKey = null;
            return toolSettings;
        }
        #endregion
        #region ConsumerApiKeySecret
        /// <summary>
        ///   <p><em>Sets <see cref="TwitterApiKeys.ConsumerApiKeySecret"/></em></p>
        ///   <p>The Consumer Api Key Secret needed to access the Twitter API. See ConsumerApiKey on how to get it.</p>
        /// </summary>
        [Pure]
        public static TwitterApiKeys SetConsumerApiKeySecret(this TwitterApiKeys toolSettings, string consumerApiKeySecret)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConsumerApiKeySecret = consumerApiKeySecret;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TwitterApiKeys.ConsumerApiKeySecret"/></em></p>
        ///   <p>The Consumer Api Key Secret needed to access the Twitter API. See ConsumerApiKey on how to get it.</p>
        /// </summary>
        [Pure]
        public static TwitterApiKeys ResetConsumerApiKeySecret(this TwitterApiKeys toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConsumerApiKeySecret = null;
            return toolSettings;
        }
        #endregion
        #region AccessToken
        /// <summary>
        ///   <p><em>Sets <see cref="TwitterApiKeys.AccessToken"/></em></p>
        ///   <p>The Access Token needed to access the Twitter API. See ConsumerApiKey on how to get it.</p>
        /// </summary>
        [Pure]
        public static TwitterApiKeys SetAccessToken(this TwitterApiKeys toolSettings, string accessToken)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AccessToken = accessToken;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TwitterApiKeys.AccessToken"/></em></p>
        ///   <p>The Access Token needed to access the Twitter API. See ConsumerApiKey on how to get it.</p>
        /// </summary>
        [Pure]
        public static TwitterApiKeys ResetAccessToken(this TwitterApiKeys toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AccessToken = null;
            return toolSettings;
        }
        #endregion
        #region AccessTokenSecret
        /// <summary>
        ///   <p><em>Sets <see cref="TwitterApiKeys.AccessTokenSecret"/></em></p>
        ///   <p>The Access Token Secret needed to access the Twitter API. See ConsumerApiKey on how to get it.</p>
        /// </summary>
        [Pure]
        public static TwitterApiKeys SetAccessTokenSecret(this TwitterApiKeys toolSettings, string accessTokenSecret)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AccessTokenSecret = accessTokenSecret;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TwitterApiKeys.AccessTokenSecret"/></em></p>
        ///   <p>The Access Token Secret needed to access the Twitter API. See ConsumerApiKey on how to get it.</p>
        /// </summary>
        [Pure]
        public static TwitterApiKeys ResetAccessTokenSecret(this TwitterApiKeys toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AccessTokenSecret = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
