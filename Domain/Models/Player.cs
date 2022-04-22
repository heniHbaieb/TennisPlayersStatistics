﻿namespace Domain.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Shortname { get; set; }
        public Gender Sex { get; set; }
        public Country Country { get; set; }
        public string Picture { get; set; }
        public Data Data { get; set; }

    }
}
