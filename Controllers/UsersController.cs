using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebREST.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static User[] users = {
        new User(0,"testName1","testSurName1"),
        new User(1,"testName2","testSurName2"),
        new User(2,"testName3","testSurName3"),
        };

        // GET: api/
        [HttpGet]
        public User[] Get()
        {
            return users;
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            User user = FindById(id);
            if (user != null)
            {
                return JsonConvert.SerializeObject(user);
            }

            return null;
        }

        // POST api/<UsersController>
        [HttpPost("post")]
        public string Post([FromBody] User NewUser)
        {
            AddUser(NewUser);
            return JsonConvert.SerializeObject(users);
        }

        // PUT api/5
        [HttpPut("put/{id}")]
        public string Put(int id, [FromBody] User CurrentUser)
        {
            User user = FindById(id);
            if (user != null)
            {
                user.Name = CurrentUser.Name;
                user.SurName = CurrentUser.SurName;
            }

            return JsonConvert.SerializeObject(user);
        }

        // DELETE api/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public User[] AddUser(User newUser)
        {
            int UserCount = users.Length;
            for (int i = 0; i < UserCount; i++)
            {
                if (users[i].Id != newUser.Id && users[i].Name != newUser.Name && users[i].SurName != newUser.SurName)
                {
                    if (i == UserCount - 1)
                    {
                        Array.Resize(ref users, UserCount + 1);
                        users[^1] = newUser;
                    }
                    continue;
                }

                break;
            }

            return users;
        }

        public User FindById(int id)
        {
            foreach (User user in users)
            {
                if (id == user.Id)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
