using Mandiri.Data;
using Mandiri.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mandiri
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, User user);

        bool IsTokenValid(HttpContext context, string key, string issuer, string token);
    }
}
