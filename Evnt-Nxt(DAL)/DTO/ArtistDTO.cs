﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace Evnt_Nxt_DAL_.DTO;
    public class ArtistDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
