using System;
using System.Collections.Generic;

namespace EchoService
{
    public class EchoServiceRequest
    {
        public string Version;
        public EchoSession Session;
        public EchoRequest Request;
    }
    public class EchoSession
    {
        public string SessionId;
    }
    public class EchoRequest
    {
        public EchoIntentValue Intent;
    }
    public class EchoIntentValue
    {
        public string Name;
    }
    public class EchoServiceResponse
    {
        public string Version = "1.0";
        public Dictionary<string, dynamic> SessionAttributes = new Dictionary<string, dynamic>();
        public EchoResponse Response;
    }
    public class EchoResponse
    {
        public EchoSpeech OutputSpeech;
        public bool ShouldEndSession = true;
    }
    public class EchoSpeech
    {
        public string Type = "PlainText";
        public string Text = "";
    }
    public abstract class EchoBaseIntentInfo
    {
        public string Intent = "";
    }
    public class EchoBuiltinIntentInfo : EchoBaseIntentInfo
    {
    }
    public class EchoIntentInfo : EchoBaseIntentInfo
    {
        public EchoIntentSlot[] Slots = new EchoIntentSlot[0];
    }
    public class EchoIntentSlot
    {
        public string Name = "";
        public string Type = "";
    }
    public class EchoIntentSchema
    {
        public EchoBaseIntentInfo[] Intents = new EchoIntentInfo[0];
    }
    public class EchoSkill
    {
        public EchoIntentSchema IntentSchema;
        public EchoCustomSlotType CustomSlotTypes;
        public EchoSampleUtterance[] SampleUtterances = new EchoSampleUtterance[0];
    }
    public class EchoSampleUtterance
    {
        public string Intent = "";
        public string Utterance = "";
    }
    public class EchoCustomSlotType
    {
        public string Name = "";
        public string[] Values = new string[0];
    }
}
