using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using EchoService;

namespace WebApplication.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        static readonly ReflectedSkill skill = new ReflectedSkill ();
        static readonly Session session;

        static HomeController()
        {
            session = new My.MySession (skill);
        }

        [HttpGet]
        public ActionResult Index()
        {
            session.InitIfNeeded();
            var settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            ViewData["intentSchema"] = JsonConvert.SerializeObject(skill.EchoSkill.IntentSchema, settings);
            ViewData["sampleUtterances"] = string.Join("\n", skill.EchoSkill.SampleUtterances.Select(x => x.Intent + " " + x.Utterance));
            ViewData["customSlotTypes"] = skill.EchoSkill.CustomSlotTypes;
            return View();
        }

        [HttpPost]
        public EchoServiceResponse Post([FromBody]EchoServiceRequest request)
        {
            //Console.WriteLine("GOT REQUEST " + request.Request.Intent.Name);
            return session.HandleRequest(request);
        }
    }
}

