using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace PushButton1
{
    public class Program
    {
        public static void Main()
        {
            // write your code here
            OutputPort led = new OutputPort(Pins.GPIO_PIN_D0, false);
            InputPort button = new InputPort(Pins.GPIO_PIN_D1, false, Port.ResistorMode.PullUp);
            OutputPort ledLight = new OutputPort(Pins.GPIO_PIN_D2, false);
            InputPort buttonLight = new InputPort(Pins.GPIO_PIN_D3, false, Port.ResistorMode.PullUp);
            AnalogInput pot = new AnalogInput(Pins.GPIO_PIN_A0);
            bool buttonState = false;
            bool isDark = false;
            int potValue = 0;

            while (true)
            {
                buttonState = !button.Read();
                isDark = buttonLight.Read() || buttonState;
                ledLight.Write(isDark);
                led.Write(buttonState);
                if (buttonState)
                {
                    //while (buttonState)
                    //{
                    //    potValue = pot.Read();
                    //    led.Write(true);
                    //    Thread.Sleep(potValue*10);
                    //    led.Write(false);
                    //    Thread.Sleep(potValue*10);
                    //    buttonState = !button.Read();
                    //}
                }
            }

        }

    }
}
