using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SpeedLord.App;
using SpeedLord.Models;
using SpeedLord.Interfaces.Repositories;

namespace SpeedLord.Controllers
{
    public class GameController : BaseController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICharacterRepository _characterRepository;

        public GameController(ICharacterRepository characterRepository, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _characterRepository = characterRepository;
        }

        //
        // GET: /Game/

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Play()
        {
            return new JsonResult {Data = string.Empty };
        }

        
        public JsonResult Initialize()
        {
            //if we are logged in but 
            if (StateManager.CurrentUser == null && User.Identity.IsAuthenticated)
            {
                StateManager.CurrentUser = _accountRepository.GetUserByUserName(User.Identity.Name);
            }

            //fetch their character or kick them to create a character loop
            var character = _characterRepository.GetCharacterForAccount(StateManager.CurrentUser.Id);
            if (character == null)
            {
                //go to character creation
                return new JsonResult { Data = string.Empty };
            }
            else
            {
                StateManager.CurrentCharacter = character;


                var screenResult = new ScreenResult
                    {
                        OutputText = string.Format("You have been initialized {0}. Go to the street.", character.Name),
                        ScreenOptions =
                            new List<ScreenOption>
                                {
                                    new ScreenOption
                                        {
                                            CommandKey = "S",
                                            Description = "Go To the [S]treet",
                                            PostUrl = "/Street"
                                        }
                                }
                    };

                return SerializeScreenResult(screenResult);
            }
        }
    }
}
