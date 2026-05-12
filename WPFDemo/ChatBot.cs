using System;
using System.Collections.Generic;
using System.Text;

namespace WPFDemo
{
    internal class ChatBot
    {
        public List<ChatbotModel> chatBotTopics = new List<ChatbotModel>();

        public ChatBot()
        {
            chatBotTopics.Add(new ChatbotModel { Topic = "phishing", Message = "Phishing is a cyberattack where attackers impersonate legitimate organizations to steal sensitive information like passwords, credit card numbers, or personal data.", Tips = "Always verify sender email addresses and look for suspicious links" });
            chatBotTopics.Add(new ChatbotModel { Topic = "phishing", Message = "Beware of phishing! Attackers often create fake websites that look identical to real ones to trick you into entering your credentials.", Tips = "Never click on links in unexpected emails. Go directly to the website instead" });
            chatBotTopics.Add(new ChatbotModel { Topic = "phishing", Message = "Common phishing red flags include urgent language, spelling errors, generic greetings, and requests for sensitive information via email.", Tips = "Be suspicious of emails creating a sense of urgency or threatening account closure" });
            chatBotTopics.Add(new ChatbotModel { Topic = "phishing", Message = "Phishing emails often contain malicious attachments that can install malware on your device when opened.", Tips = "Don't open attachments from unknown senders, even if they look legitimate" });

            chatBotTopics.Add(new ChatbotModel { Topic = "password", Message = "A strong password should be at least 12 characters long and include uppercase letters, lowercase letters, numbers, and special symbols (like !@#$%).", Tips = "Use a password manager to generate and store complex passwords securely" });
            chatBotTopics.Add(new ChatbotModel { Topic = "password", Message = "Never use personal information in your passwords such as your name, birthday, address, or pet names - these are easy for hackers to guess.", Tips = "Avoid using dictionary words or common patterns like '12345' or 'password'" });
            chatBotTopics.Add(new ChatbotModel { Topic = "password", Message = "Enable multi-factor authentication (MFA) whenever possible. This adds an extra layer of security beyond just your password.", Tips = "Use unique passwords for each account - never reuse passwords across sites" });
            chatBotTopics.Add(new ChatbotModel { Topic = "password", Message = "Change your passwords regularly, especially for important accounts like email, banking, and work systems.", Tips = "Consider using passphrases - long sentences are easier to remember and harder to crack" });
        }

        public string GetResponse(string input)
        {
            if (input.ToLower().Contains("phishing"))
            {
                var responses = chatBotTopics.Where(model => model.Topic == "phishing");
                if(responses.Any())
                {
                    var random = new Random();
                    int index = random.Next(responses.Count());
                    return responses.ElementAt(index).Message;
                }
            }
            if (input.ToLower().Contains("password"))
            {
                var responses = chatBotTopics.Where(x => x.Topic == "password");
                if (responses.Any())
                {
                    var random = new Random();
                    int index = random.Next(responses.Count());
                    return responses.ElementAt(index).Message;
                }
            }
            return "";
        }

    }
}
