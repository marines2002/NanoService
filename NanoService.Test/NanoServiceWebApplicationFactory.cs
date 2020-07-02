using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace NanoService.Test
{
    public class NanoServiceWebApplicationFactory : WebApplicationFactory<Startup>
    {
        public NanoServiceWebApplicationFactory()
        {
        }
    }
}
