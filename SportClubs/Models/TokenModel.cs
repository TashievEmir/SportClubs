﻿using SportClubs.Helpers;

namespace SportClubs.Models
{
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
