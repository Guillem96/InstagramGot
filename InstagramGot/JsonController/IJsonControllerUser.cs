using InstagramGot.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGot.JsonController
{
    interface IJsonUserController
    {
        IUser MapJsonToUser(string json);
        IUserFrom MapJsonToUser(JToken json);

    }
}
