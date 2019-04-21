﻿using Nuke.Common.Tooling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nuke.Common.Tools.Twitter {

    public static class TwitterTasks {
        public static string TwitterApiBaseUrl { get; set; } = "https://api.twitter.com/1.1/";

        public static void SendTweet(Configure<TwitterApiKeys> configurator, string tweet) {
            SendTweetAsync(configurator, tweet).Wait();
        }

        public static async Task SendTweetAsync(Configure<TwitterApiKeys> configurator, string tweet) {
            var apiKeys = configurator(new TwitterApiKeys());

            var data = new Dictionary<string, string>
                            {
                                { "status", tweet },
                                { "trim_user", "1" }
                            };

            await SendRequest(apiKeys, "statuses/update.json", data);
        }

        private static async Task SendRequest(TwitterApiKeys apiKeys, string url, Dictionary<string, string> data) {
            var fullUrl = TwitterApiBaseUrl + url;

            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(timestamp.ToString()));

            // Add all the OAuth headers we'll need to use when constructing the hash.
            data.Add("oauth_consumer_key", apiKeys.ConsumerApiKey);
            data.Add("oauth_signature_method", "HMAC-SHA1");
            data.Add("oauth_timestamp", timestamp.ToString());
            data.Add("oauth_nonce", nonce);
            data.Add("oauth_token", apiKeys.AccessToken);
            data.Add("oauth_version", "1.0");

            // Generate the OAuth signature and add it to our payload.
            data.Add("oauth_signature", GenerateSignature(apiKeys, fullUrl, data));

            // Build the OAuth HTTP Header from the data.
            var oAuthHeader = GenerateOAuthHeader(data);

            // Build the form data (exclude OAuth stuff that's already in the header).
            var formData = new FormUrlEncodedContent(data.Where(kvp => !kvp.Key.StartsWith("oauth_")));

            // Send the Tweet
            using (var http = new HttpClient()) {
                http.DefaultRequestHeaders.Add("Authorization", oAuthHeader);

                var httpResp = await http.PostAsync(fullUrl, formData);
                var respBody = await httpResp.Content.ReadAsStringAsync();

                ControlFlow.Assert(httpResp.StatusCode == System.Net.HttpStatusCode.OK, $"StatusCode != 200 - '{respBody}'");
            }
        }

        /// <summary>
        /// Generate an OAuth signature from OAuth header values.
        /// </summary>
        private static string GenerateSignature(TwitterApiKeys apiKeys, string url, Dictionary<string, string> data) {
            var sigString = string.Join(
                "&",
                data
                    .Union(data)
                    .Select(kvp => string.Format("{0}={1}", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))
                    .OrderBy(s => s)
            );

            var fullSigData = string.Format(
                "{0}&{1}&{2}",
                "POST",
                Uri.EscapeDataString(url),
                Uri.EscapeDataString(sigString.ToString())
            );

            var sigHasher = new HMACSHA1(new ASCIIEncoding().GetBytes(string.Format("{0}&{1}", apiKeys.ConsumerApiKeySecret, apiKeys.AccessTokenSecret)));

            return Convert.ToBase64String(sigHasher.ComputeHash(new ASCIIEncoding().GetBytes(fullSigData.ToString())));
        }

        /// <summary>
        /// Generate the raw OAuth HTML header from the values (including signature).
        /// </summary>
        private static string GenerateOAuthHeader(Dictionary<string, string> data) {
            return "OAuth " + string.Join(
                ", ",
                data
                    .Where(kvp => kvp.Key.StartsWith("oauth_"))
                    .Select(kvp => string.Format("{0}=\"{1}\"", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))
                    .OrderBy(s => s)
            );
        }
    }
}
