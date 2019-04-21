using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Nuke.Common.Tools.Twitter;
using FluentAssertions;

namespace Nuke.Common.Tests {
    public class TwitterTest {

        private Action<string, string, string, string> TweetAction =
            (consumerApiKey, consumerApiKeySecret, accessToken, accessTokenSecret) =>
                        TwitterTasks.SendTweet(x => x.
                        SetConsumerApiKey(consumerApiKey).
                        SetConsumerApiKeySecret(consumerApiKeySecret).
                        SetAccessToken(accessToken).
                        SetAccessTokenSecret(accessTokenSecret),
                        "Test tweet");


        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData("XX", null, null, null)]
        [InlineData(null, "XX", null, null)]
        [InlineData(null, null, "XX", null)]
        [InlineData(null, null, null, "XX")]
        public void TestNotInitializedApiKeys(string consumerApiKey, string consumerApiKeySecret, string accessToken, string accessTokenSecret) {
            Action tweetAction = () =>
                       TwitterTasks.SendTweet(x => x.
                       SetConsumerApiKey(consumerApiKey).
                       SetConsumerApiKeySecret(consumerApiKeySecret).
                       SetAccessToken(accessToken).
                       SetAccessTokenSecret(accessTokenSecret),
                       "Test tweet");

            tweetAction.Should().Throw<AggregateException>().WithMessage("*ConsumerApiKey, ConsumerApiKeySecret, AccessToken and AccessTokenSecret*");
        }

        [Fact]
        public void TestInvalidApiKeys() {
            Action tweetAction = () =>
                      TwitterTasks.SendTweet(x => x.
                                    SetConsumerApiKey("Dummy").
                                    SetConsumerApiKeySecret("Dummy").
                                    SetAccessToken("Dummy").
                                    SetAccessTokenSecret("Dummy"),
                                    "Test tweet");
            tweetAction.Should().Throw<AggregateException>().WithMessage("*invalid*token*");
        }

        /*
        [Fact]
        public void TestSendTweet() {
            // This test sends a test tweet. To uncomment this test, valid API Keys must be inserted first
            Action tweetAction = () =>
                      TwitterTasks.SendTweet(x => x.
                                    SetConsumerApiKey("Insert").
                                    SetConsumerApiKeySecret("valid").
                                    SetAccessToken("keys").
                                    SetAccessTokenSecret("here"),
                                    "Test tweet");
            tweetAction.Should().NotThrow();
        }
        */
    }
}
