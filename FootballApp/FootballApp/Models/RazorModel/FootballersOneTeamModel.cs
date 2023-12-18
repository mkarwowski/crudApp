using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballApp.Models
{
    public class FootballersOneTeamModel
    {
        public List<Footballer> footballers = new List<Footballer>();
        public string teamName;
        public string message;

        public FootballersOneTeamModel(List<Footballer> l, string mess)
        {
            foreach (Footballer f in l)
            {
                footballers.Add(f);
            }
            teamName = l.First()._team.Name;
            message = mess;
        }
    }
}