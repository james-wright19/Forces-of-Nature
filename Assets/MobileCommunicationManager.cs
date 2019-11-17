using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCommunicationManager : MonoBehaviour
{
    public readonly string[] possibleMessages = { "Scorch the earth\n  (+Fire -Earth)", "Create a tornado\n  (+Wind -Fire)", "Flood the area\n  (+Water -Wind)", "Summon earthquake\n  (+Earth -Water)" };
    public string[] currentDisasters = { "Scorch the earth\n  (+Fire -Earth)", "Create a tornado\n  (+Wind -Fire)" };
    public List<string> numbers = new List<string>();
    float timeToNextMessage = 20;

    float secondTick = 1;

    void Start()
    {

    }

    void Update()
    {
        if(numbers.Count > 0)
            timeToNextMessage -= Time.deltaTime;

        if (timeToNextMessage < 0)
        {
            ProcessNewEvent();
        }

        secondTick -= Time.deltaTime;

        if (secondTick < 0)
        {
            secondTick = 1;
            if (TwilioIO.CheckForMessage())
            {
                string rawMessage = TwilioIO.ReadMessageFromPhone();

                string number = rawMessage.Split(new char[] { ' ' })[0];

                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                    GreetNewUser(number);
                }
                else
                {
                    string message = rawMessage.Split(new string[] { " SENDS " }, System.StringSplitOptions.None)[1];
                    
                    message.Trim(new char[] { '\'' });
                    if (int.TryParse(message, out int result))
                    {
                        if (result > 1 && result < 2)
                        {
                            TwilioIO.SendMessageToPhones(new List<string> { number }, "Typo error. Make sure to write \"1\" or \"2\".");
                        }
                        else
                        {
                            switch (currentDisasters[result - 1])
                            {
                                case "Scorch the earth\n  (+Fire -Earth)":
                                    ElementManager.current.ChangeFireValue(1);
                                    ElementManager.current.ChangeEarthValue(-1);
                                    disasters.current.FireDisaster();
                                    break;
                                case "Create a tornado\n  (+Wind -Fire)":
                                    ElementManager.current.ChangeFireValue(-1);
                                    ElementManager.current.ChangeWindValue(1);
                                    disasters.current.WindDisaster();
                                    break;
                                case "Flood the area\n  (+Water -Wind)":
                                    ElementManager.current.ChangeWaterValue(1);
                                    ElementManager.current.ChangeWindValue(-1);
                                    disasters.current.WaterDisater();
                                    break;
                                case "Summon earthquake\n  (+Earth -Water)":
                                    ElementManager.current.ChangeWaterValue(-1);
                                    ElementManager.current.ChangeEarthValue(1);
                                    disasters.current.EarthDisater();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        TwilioIO.SendMessageToPhones(new List<string> { number }, "Unknown command. Make sure to write \"1\" or \"2\".");
                    }

                }
            }
        }
    }

    void ProcessNewEvent()
    {
        ElementManager.current.TickNaturalErosion();
        if (numbers.Count == 0)
            return;

        int firstCommand = Random.Range(0, 4);
        int secondCommand;
        do
        {
            secondCommand = Random.Range(0, 4);
        } while (firstCommand == secondCommand);

        currentDisasters = new string[] { possibleMessages[firstCommand], possibleMessages[secondCommand] };

        TwilioIO.SendMessageToPhones(numbers, "You currently can:\n#1: " + possibleMessages[firstCommand] + ";\n#2: " + possibleMessages[secondCommand] + ".");
        timeToNextMessage = 20;
    }

    void GreetNewUser(string number)
    {
        string greetMessage = "Welcome to the game of the elements!\n" +
            "Your task is to help in survival of the player who deals with the monsters... By sending natural disasters on him.\n" +
            "Everything you do has a strong influence on the atmosphere of the world, which changes, reacting you your decisions.\n" +
            "If any of the four elements go too low or too high, it means imminent death for the unlucky guy.\n" +
            "Your powers change every 20 seconds, so be fast about your actions!";

        TwilioIO.SendMessageToPhones(new List<string> { number }, greetMessage);
    }
}
