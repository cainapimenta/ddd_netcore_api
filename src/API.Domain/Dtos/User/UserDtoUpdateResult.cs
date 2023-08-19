﻿using System;
using System.Collections.Generic;
using System.Text;

namespace API.Domain.Dtos.User
{
    public class UserDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
