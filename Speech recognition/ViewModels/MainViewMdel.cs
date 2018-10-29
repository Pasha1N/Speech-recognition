using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition;
using Speech_recognition.Models;
using Speech_recognition.Utilities;

namespace Speech_recognition.ViewModels
{
    public class MainViewMdel:EventINotifyPropertyChanged
    {
        static private string text = "dsfvd";
       // static private TextInput text = new TextInput();
        public MainViewMdel()
        {
           ReadSpeaking();
         text="sdfsdfvsv";
        }

        static void AreSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.82)
            {
                // text.Text = e.Result.Text;
                text = e.Result.Text;
            }
        }

        public string TextInput
        {
            //get => text;
            //set => SetProperty(ref text, value);
            get => text;
            set => SetProperty(ref text, value);
        }

        public void ReadSpeaking()
        {
            TextInput = text;
            System.Globalization.CultureInfo ru = new System.Globalization.CultureInfo("ru-ru");
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(ru);
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(AreSpeechRecognized);
            OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(nameof(TextInput)));
            Choices words = InitialisingCommand();
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(words);

            Grammar grammar = new Grammar(grammarBuilder);

            recognizer.LoadGrammar(grammar);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private Choices InitialisingCommand()
        {
            Choices words = new Choices();
            words.Add("один");
            words.Add("два");
            words.Add("привет");
            words.Add("иди сюда");
            words.Add("пока");
            words.Add("выключи свет");
            words.Add("включи свет");
            return words;
        }
    }
}