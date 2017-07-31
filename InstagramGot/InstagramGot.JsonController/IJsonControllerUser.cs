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
        IUser MapJsonToUser(JToken json);
        IMinifiedUser MapJsonToMinifiedUser(JToken json);
        List<IMinifiedUser> MapJsonToMinifiedUsers(string json);
        List<IUser> MapJsonToUsers(string json);

    }
}
