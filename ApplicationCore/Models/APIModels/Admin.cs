using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models.APIModels
{
    public class Admin : Account
    {
        public int TokenId { get; set; }
    }
}
