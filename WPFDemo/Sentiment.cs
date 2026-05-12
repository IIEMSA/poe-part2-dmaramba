using System;
using System.Collections.Generic;
using System.Text;

namespace WPFDemo
{
    // Delegate for sentiment response processing
    public delegate string SentimentResponseHandler(string sentiment, string input);

    internal class Sentiment
    {
        // Event using the delegate for when sentiment is detected
        public event SentimentResponseHandler? OnSentimentDetected;

        public string GetSentiment(string input)
        {
            string sentimentResponse = "";

            if (input.ToLower().Contains("worried"))
            {
                sentimentResponse = ProcessSentiment("worried", input, 
                    (sentiment, userInput) => $"It seems you are {sentiment}. Don't worry, everything will be fine!");
            }
            else if (input.ToLower().Contains("happy"))
            {
                sentimentResponse = ProcessSentiment("happy", input, 
                    (sentiment, userInput) => $"It's great to hear that you are {sentiment}! Keep smiling!");
            }
            else if (input.ToLower().Contains("sad"))
            {
                sentimentResponse = ProcessSentiment("sad", input, 
                    (sentiment, userInput) => $"I'm sorry to hear that you are {sentiment}. Remember, it's okay to feel sad sometimes. Take care of yourself!");
            }

            return sentimentResponse;
        }

        // Method that uses the delegate to process sentiment
        private string ProcessSentiment(string sentiment, string input, SentimentResponseHandler handler)
        {
            // Invoke the event if there are subscribers
            OnSentimentDetected?.Invoke(sentiment, input);

            // Use the delegate to generate the response
            return handler(sentiment, input);
        }
    }
}
