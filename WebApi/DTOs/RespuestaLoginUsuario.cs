using System.Collections.Generic;

namespace WebApi.DTOs
{
    public class RespuestaLoginUsuario
    {
        public string Token { get; set; }
        public bool IsLogin { get; set; }
        public List<string> Errors { get; set; }

    }
}
