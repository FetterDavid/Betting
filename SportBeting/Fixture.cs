using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportBeting
{
    public class LiveFixture
    {
        public Fixture fixture { get; set; }
        public League league { get; set; }
        public Teams teams { get; set; }
        public Goals goals { get; set; }
        public Score score { get; set; }
        public Event[] events { get; set; }
    }

    public class Fixture
    {
        public int id { get; set; }
        public object referee { get; set; }
        public string timezone { get; set; }
        public DateTime date { get; set; }
        public int timestamp { get; set; }
        public Periods periods { get; set; }
        public Venue venue { get; set; }
        public Status status { get; set; }
    }
    public class Periods
    {
        public int first { get; set; }
        public int? second { get; set; }
    }
    public class Venue
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
    }
    public class Status
    {
        public string _long { get; set; }
        public string _short { get; set; }
        public int elapsed { get; set; }
    }
    public class League
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string logo { get; set; }
        public string flag { get; set; }
        public int season { get; set; }
        public string round { get; set; }
    }
    public class Teams
    {
        public Home home { get; set; }
        public Away away { get; set; }
    }
    public class Home
    {
        public int id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public bool? winner { get; set; }
    }
    public class Away
    {
        public int id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public bool? winner { get; set; }
    }
    public class Goals
    {
        public int home { get; set; }
        public int away { get; set; }
    }
    public class Score
    {
        public Halftime halftime { get; set; }
        public Fulltime fulltime { get; set; }
        public Extratime extratime { get; set; }
        public Penalty penalty { get; set; }
    }
    public class Halftime
    {
        public int home { get; set; }
        public int away { get; set; }
    }
    public class Fulltime
    {
        public object home { get; set; }
        public object away { get; set; }
    }
    public class Extratime
    {
        public object home { get; set; }
        public object away { get; set; }
    }
    public class Penalty
    {
        public object home { get; set; }
        public object away { get; set; }
    }
    public class Event
    {
        public Time time { get; set; }
        public Team team { get; set; }
        public Player player { get; set; }
        public Assist assist { get; set; }
        public string type { get; set; }
        public string detail { get; set; }
        public object comments { get; set; }
    }
    public class Time
    {
        public int elapsed { get; set; }
        public object extra { get; set; }
    }
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
    }
    public class Player
    {
        public object id { get; set; }
        public object name { get; set; }
    }
    public class Assist
    {
        public object id { get; set; }
        public object name { get; set; }
    }
}
