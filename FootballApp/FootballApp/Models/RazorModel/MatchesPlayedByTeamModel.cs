using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballApp.Models
{
    public class MatchesPlayedByTeamModel
    {
        public List<PlayedMatch> playedMatches = new List<PlayedMatch>();
        public string teamName;
        public string message;

        public MatchesPlayedByTeamModel(List<PlayedMatch> pm, string msg) {
            foreach (PlayedMatch p in pm) {
                playedMatches.Add(p);
            }
            teamName = pm.First()._team.Name;
            message = msg;
        }
    }
}